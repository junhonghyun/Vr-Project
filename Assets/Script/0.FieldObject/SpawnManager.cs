using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyObject;
    [SerializeField]
    private GameObject portal;
    

    private List<GameObject> enemyList = new List<GameObject>();
    int controlCount;

    // Start is called before the first frame update
    void Start()
    {
        Spawn();
        GameManager.Instance.stage2 += ClearMonster;
    }
    private void ClearMonster()
    {
        for (int i = 0; i < enemyList.Count;i++)
        {
            if (enemyList[i].gameObject != null)
            {
               
                Destroy(enemyList[i].gameObject);

                if (i==enemyList.Count-1)
                {
                    GameManager.Instance.enemyCount=0;
                    GameManager.Instance.currentEnemyCount=0;
                    Stage2Spawn();
                }
            }
        }
        
    }
    private void Spawn()
    {
        Transform parentTransform = transform;

        Vector3[] childPositions = new Vector3[parentTransform.childCount];

        for (int i = 0; i < parentTransform.childCount; i++)
        {
            childPositions[i] = parentTransform.GetChild(i).position;
        }

        // 배열에 저장된 자식 객체들의 위치를 출력
        foreach (Vector3 position in childPositions)
        {
            controlCount++;
            if (controlCount % 2 == 0)
            {
                enemyList.Add(Instantiate(enemyObject, position, Quaternion.identity));
                GameManager.Instance.enemyCount++;
                GameManager.Instance.currentEnemyCount++;
            }
        }
        GameSceneUIManager.Instance.EnemyCurrenCount(GameManager.Instance.currentEnemyCount);
        GameSceneUIManager.Instance.EnemyMaxCount(GameManager.Instance.enemyCount);

    }
    private void Stage2Spawn()
    {
       
        Transform parentTransform = transform;

        Vector3[] childPositions = new Vector3[parentTransform.childCount];

        for (int i = 0; i < parentTransform.childCount; i++)
        {       
                childPositions[i] = parentTransform.GetChild(i).position;
            
        }

        // 배열에 저장된 자식 객체들의 위치를 출력
        foreach (Vector3 position in childPositions)
        {
                Instantiate(enemyObject, position, Quaternion.identity);
                GameManager.Instance.enemyCount++;
                GameManager.Instance.currentEnemyCount++;
             Instantiate(portal, position, Quaternion.identity);
             GameManager.Instance.portalCount++;
                GameManager.Instance.cureentPortalCount++;
               
            
        }

        GameSceneUIManager.Instance.EnemyCurrenCount(GameManager.Instance.currentEnemyCount);
        Debug.Log($"현재 몬스터 카운트는?{GameManager.Instance.currentEnemyCount}");
        GameSceneUIManager.Instance.EnemyMaxCount(GameManager.Instance.enemyCount);
        Debug.Log($"총 몬스터 카운트는?{GameManager.Instance.enemyCount}");
        GameSceneUIManager.Instance.PortalAllCount(GameManager.Instance.portalCount);
        GameSceneUIManager.Instance.PortalCurrentCount(GameManager.Instance.portalCount);


    }    
    
}
