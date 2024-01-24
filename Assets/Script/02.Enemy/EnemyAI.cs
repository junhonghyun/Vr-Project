using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    //Enemy AI
    //�׺�޽� �������
    //�������� ��ź ��ġ���� 
    //ù ������ ��ź��ġ�������� �޸��ٰ�
    //���̿� ĳ���͸� �����ϸ� ��ǥ�� ĳ���ͷ� ������.
    //�̵��Ҷ� �� �ִϸ����� ����ؾ���.
    //1.���������� ��ġ�� �޴´� .
    //2.6���� ��ġ�� �Ѱ��� ���� �޴´�.
    //3.Enemy �̵�  ���⼭ �ΰ����� ��������
    //4.�������� ������ ���ο� �������� �Ҵ��Ͽ� �̵��ϰ� �����.
    //5.���࿡ �÷��̾ �߽߰� �Ѿư���. �� ���� ������Ʈ �ڿ� ���´ٸ� ���� ã�� �÷��̾��� ��ġ���� �ʱ�ȭ�ȴ�.�ٽ� ��ź�������� �̵�.
    Animator enemyAnimator;
    NavMeshAgent enemyNav;
    [SerializeField]
    Transform[] movePosition;//��ź��ġ���� ��ġ���� �޾ƿ� ���� 
    public Transform nowposition;
    private bool dead;//���߿� EnemyHealth���� �޾ƿ;��� �����̴�.
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
        nowposition = movePosition[count];//���� ��ȣ�� ��ġ�� �������� �Ҵ���.
        Debug.Log("�������� 2�Ѿ���鼭 �����ũ ����");
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
               
               //�������Ҷ� ���� �� ��ġ�� �ؾ���� 
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
                    nowposition = movePosition[count];//���� ��ȣ�� ��ġ�� �������� �Ҵ���.


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
                    nowposition = movePosition[count];//���� ��ȣ�� ��ġ�� �������� �Ҵ���.
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
