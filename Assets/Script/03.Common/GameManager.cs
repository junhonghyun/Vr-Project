using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
            }
            return instance;
        }
    }
    //���� �������� 
    public int currenStage;
    public event Action stage2;
    public Action playerDie;
    public Action GameFin;
    public bool GameClear;
    //���� �� ���� ����
    public int enemyCount;
    //���� ���� ���� ����
    public int currentEnemyCount;
    //��ź ī��Ʈ�� ���� 
    public int bombCount;//4���� ��ġ�ؾ��� 
    //��ġ ��ź �ִ� ����
    public int MaxBomb;
    //�ʵ� ��ġ ��ź ī��Ʈ ����
    public int fieldBobmCount;
    //��Ż �� ����
    public int portalCount; 
    //��Ż ���� ����
    public int cureentPortalCount;
    //�÷��̾� ��Ȱ��ȭ
    public GameObject player;
    //ī�޶� �Ҵ�
    public GameObject iscamera;
    //��ƼŬ �Ҵ�
    public GameObject finalParticle;
    //������ ��Ż 
    public GameObject LastPortal;
    //���������� ����
    public GameObject Stage1;
    public GameObject Stage2;

    public GameObject bombPosiiton;
    
    [SerializeField]
    [Header("MaterialColor")]
    Material skybox;

    [SerializeField]
    private GameObject hiddenStageDoor;
    public int shotCount;


    private void Awake()
    {
        fieldBobmCount = 4;
        GameSceneUIManager.Instance.PortalAllCount(fieldBobmCount);
        GameClear=false;
        currenStage = 1;
        fieldBobmCount = 0;
        bombCount = 0;
        //GameFin += () => LoadSceneManager.Instance.GoScene("ResultScene");
        GameFin += isGameClear;
        stage2 += () => GameSceneUIManager.Instance.StageTime += 120;
    }

    private void Start()
    {
   
    }
    private void Update()
    {
   
    }
    public void isGameClear()
    {
        iscamera.gameObject.SetActive(true);
        player.gameObject.SetActive(false);
        finalParticle.SetActive(true);
        StartCoroutine(GoResult());
    
       
    }
    public void OffConsole()
    {
        GameSceneUIManager.Instance.OffConsole();
    }
    public void OnStage2()
    {
        Stage1.gameObject.SetActive(false);
        Stage2.gameObject.SetActive(true);

        stage2?.Invoke();
        currenStage = 2;
        RenderSettings.skybox = skybox;
        Destroy(hiddenStageDoor.gameObject);
        GameSceneUIManager.Instance.OnColsole();
        GameSceneUIManager.Instance.Console("������ �����´� ��Ż�� �ı��ϰ� ���� óġ����");
        GameSceneUIManager.Instance.RightImage();
        Invoke("OffConsole", 10.0f);
        Destroy(bombPosiiton);
        if (stage2 != null) 
        {

        }
      
    }
    public void LastGoPortal()
    {
        GameSceneUIManager.Instance.OnColsole();
        GameSceneUIManager.Instance.Console("������ ��Ż�� ���� �� ����.\n��Ż�� �ı��ϰ� ���ư���..");
        LastPortal.gameObject.SetActive(true);
        Invoke("OffConsole", 5.0f);
    }
    public void NotClear()
    {
        GameSceneUIManager.Instance.OnColsole();
        GameSceneUIManager.Instance.Console("���� ���� �����ִ� �� ���� .óġ�ϰ� ���ƿ���");
        Invoke("OffConsole", 5.0f);
    }
    IEnumerator GoResult()
    {
        yield return new WaitForSeconds(6);
        LoadSceneManager.Instance.GoScene("ResultScene");
    }
    private void OnGUI()
    {
        if (GUI.Button(new Rect(40, 40, 350, 60), "�׽�Ʈ ��ư2"))
        {
            GameManager.Instance.enemyCount--;
            GameManager.Instance.currentEnemyCount--;
            GameManager.Instance.portalCount--;
            GameManager.Instance.cureentPortalCount--;
            Debug.Log($"���� enemyCount{GameManager.Instance.enemyCount}");

        }
    }

}
