using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{   // Start is called before the first frame update
    private void Awake()
    {
        GameManager.Instance.bombCount += 1;
        GameSceneUIManager.Instance.PortalCurrentCount(GameManager.Instance.bombCount);
        if(GameManager.Instance.bombCount == 4 )
        {
            GameManager.Instance.OnStage2();
        }
    }

    private void OnGUI()
    {
        if (GUI.Button(new Rect(10, 10, 150, 30), "�׽�Ʈ ��ư"))
        {
            // ��ư�� Ŭ���Ǿ��� �� ������ ����
            GameManager.Instance.bombCount += 1;
            if (GameManager.Instance.bombCount == 4)
            {
                GameManager.Instance.OnStage2();
           
            }
        }
    }
}
