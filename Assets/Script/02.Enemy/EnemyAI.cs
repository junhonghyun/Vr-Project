using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    //Enemy AI
    //네비메시 기반제작
    //목적지는 폭탄 설치구역 
    //첫 시작은 폭탄설치구역으로 달리다가
    //사이에 캐릭터를 감지하면 목표를 캐릭터로 변경함.
    //이동할때 쓸 애니메이터 사용해야함.
    //1.목적지들의 위치를 받는다 .
    //2.6개의 위치중 한곳의 값을 받는다.
    //3.Enemy 이동  여기서 두가지로 나뉘어짐
    //4.목적지에 도착시 새로운 목적지를 할당하여 이동하게 만든다.
    //5.만약에 플레이어를 발견시 쫓아간다. 단 방해 오브젝트 뒤에 숨는다면 현재 찾은 플레이어위 위치값이 초기화된다.다시 폭탄구역으로 이동.
    Animator enemyAnimator;
    NavMeshAgent enemyNav;
    [SerializeField]
    Transform[] movePosition;//폭탄설치구역 위치값을 받아올 변수 
    public Transform nowposition;
    private bool dead;//나중에 EnemyHealth에서 받아와야할 변수이다.
    public PlayerHealth player;
    public LayerMask playermask;
    public LayerMask wallObj;
    public GameObject isplayer;
    float time;
    Rigidbody rb;
    EnemyHealth enemyHealth;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        enemyHealth = GetComponent<EnemyHealth>();
        dead = false;
        enemyAnimator = GetComponent<Animator>();
        enemyNav = GetComponent<NavMeshAgent>();
        int count = (int)Random.RandomRange(0,5);
        nowposition = movePosition[count];//랜덤 번호로 위치를 랜덤으로 할당함.
        Debug.Log("스테이지 2넘어오면서 어웨이크 실행");
        enemyAnimator.SetTrigger("Stop");
        enemyHealth.die += Die;
    }
   
    private void Start()
    {
        StartCoroutine(StartAI());
    }
    private void FixedUpdate()
    {
        time += Time.deltaTime;
    }

    private IEnumerator StartAI()
    {
        while(!dead)
        {
            Collider[] collider = Physics.OverlapSphere(transform.position, 5f, playermask);
            if (player == null&& enemyNav.isActiveAndEnabled)
            {
               
               //리스폰할때 기존 길 위치를 잊어버림 
                NavMeshPath path = new NavMeshPath();
                enemyNav.CalculatePath(nowposition.position, path);
                enemyNav.SetPath(path);
    
            
                
                enemyAnimator.SetBool("Find", true);
                enemyAnimator.SetBool("FinFind", false);

                for (int i = 0; i<collider.Length; i++)
                {
                    player = collider[i].GetComponent<PlayerHealth>();
                    if(player != null) 
                    {
                        break;
                    }//
                }
                if (enemyNav.remainingDistance < 0.5f&&player==null)
                {
                    int count = (int)Random.RandomRange(0, 5);
                    nowposition = movePosition[count];//랜덤 번호로 위치를 랜덤으로 할당함.


                }
            }
            else if(player!=null)
            {
                enemyAnimator.SetBool("Find", false);
                enemyAnimator.SetBool("FinFind", true);
         
                NavMeshPath path = new NavMeshPath();
                enemyNav.CalculatePath(player.gameObject.transform.position, path);
                enemyNav.SetPath(path);
                if (enemyNav.remainingDistance < 1f)
                {
                    enemyAnimator.SetTrigger("Attack");
                    enemyNav.isStopped = true;                
                    int count = (int)Random.RandomRange(0, 5);
                    nowposition = movePosition[count];//랜덤 번호로 위치를 랜덤으로 할당함.
                    player = null;
                    yield return new WaitForSeconds(2);
                    isplayer.gameObject.SetActive(false);
          
                    enemyNav.isStopped=false;
           
                }
            }
            yield return new WaitForSeconds(0.5f);
         
        }

    }

    public void Die()
    {
        dead=true;
        enemyNav.isStopped = true;
        enemyNav.enabled = false;
        rb.isKinematic = true;
        StopCoroutine(StartAI());
    }
    public void Attack()
    {
        isplayer.gameObject.SetActive(true);
    }
    
    private void FindPlayer()
    {
        
    }
}
