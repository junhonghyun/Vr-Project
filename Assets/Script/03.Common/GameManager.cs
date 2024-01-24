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
    //현재 스테이지 
    public int currenStage;
    public event Action stage2;
    public Action playerDie;
    public Action GameFin;
    public bool GameClear;
    //몬스터 총 숫자 변수
    public int enemyCount;
    //현재 몬스터 숫자 변수
    public int currentEnemyCount;
    //폭탄 카운트용 변수 
    public int bombCount;//4개를 설치해야함 
    //설치 폭탄 최대 개수
    public int MaxBomb;
    //필드 설치 폭탄 카운트 변수
    public int fieldBobmCount;
    //포탈 총 개수
    public int portalCount; 
    //포탈 현재 개수
    public int cureentPortalCount;
    //플레이어 비활성화
    public GameObject player;
    //카메라 할당
    public GameObject iscamera;
    //파티클 할당
    public GameObject finalParticle;
    //마지막 포탈 
    public GameObject LastPortal;
    //스테이지별 음악
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
        GameSceneUIManager.Instance.Console("적들이 몰려온다 포탈을 파괴하고 적을 처치하자");
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
        GameSceneUIManager.Instance.Console("마지막 포탈이 생긴 것 같다.\n포탈을 파괴하고 돌아가자..");
        LastPortal.gameObject.SetActive(true);
        Invoke("OffConsole", 5.0f);
    }
    public void NotClear()
    {
        GameSceneUIManager.Instance.OnColsole();
        GameSceneUIManager.Instance.Console("아직 적이 남아있는 것 같다 .처치하고 돌아오자");
        Invoke("OffConsole", 5.0f);
    }
    IEnumerator GoResult()
    {
        yield return new WaitForSeconds(6);
        LoadSceneManager.Instance.GoScene("ResultScene");
    }
    private void OnGUI()
    {
        if (GUI.Button(new Rect(40, 40, 350, 60), "테스트 버튼2"))
        {
            GameManager.Instance.enemyCount--;
            GameManager.Instance.currentEnemyCount--;
            GameManager.Instance.portalCount--;
            GameManager.Instance.cureentPortalCount--;
            Debug.Log($"현재 enemyCount{GameManager.Instance.enemyCount}");

        }
    }

}
