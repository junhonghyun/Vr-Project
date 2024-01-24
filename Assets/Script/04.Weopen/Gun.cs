using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;

enum State
{
    shot,
    reload,
    stop,
    InstallBomb
}
public class Gun : MonoBehaviour
{
    [SerializeField]
    Transform shotPosition;//총알 발사 포지션 
    [SerializeField]
    Transform reloadPosition;//탄알집 넣을 포지션
    [SerializeField]
    GameObject RiflePosition;//라이플 포지션 전용 변수  
    [SerializeField]
    GameObject ammo;//탄알집 게임 오브젝트 
    [SerializeField]
    GameObject bullet;
    [SerializeField]
    GameObject gun;
    [SerializeField]
    GameObject player;
    [SerializeField]
    GameObject Bomb;
    [SerializeField]
    GameObject FiledBomb;
    //[SerializeField]
    //ParticleSystem shotEffect;
    AudioSource shotSound;
    [SerializeField]
    AudioClip shotSounds;
    [SerializeField]
    AudioClip reloadClip;
    [SerializeField]
    ParticleSystem outBullet;
    [SerializeField]
    TextMeshProUGUI bulletCounting;
    OculusInput input;
    private LineRenderer lineRenderer;
    List<GameObject> bulletContainor=new List<GameObject>();
    State state;
    int shotController;
    int bulletCount;
    int reloadReadycount;
    float shotTime;
    bool gunMode;
    float bombchk;

    private void Awake()
    {
        bulletCount = 30;
        BulletCounting(bulletCount);
        gunMode=true;
        RiflePosition = GameObject.Find("RiflePosition").gameObject;
        ///라인렌더러
        lineRenderer = GetComponent<LineRenderer>();
 
        lineRenderer.positionCount = 2;

        player = GameObject.Find("Player").gameObject;
        ///라인렌더러
        shotSound = GetComponent<AudioSource>();

        input = player.GetComponent<OculusInput>();
        input.installFieldBomb.action.performed += ChangePickup;
        shotController = 0;
    }
    private void FixedUpdate()
    {
        shotTime += Time.deltaTime;
        Shot();//오큘러스 인풋에 구독을 할까?
        Debug.Log(input.name);
        if(input==null)
        {
            Debug.Log("인풋 널값임");
        }
        if(state==State.reload)
        {
            ammo.transform.position = ammo.transform.position + transform.up * -1 * Time.deltaTime * 2;
        }
     
    }
    private void ChangePickup(InputAction.CallbackContext obj)
    {    
        if(gunMode)
        {
            gunMode=false;
            state = State.InstallBomb;
            gun.gameObject.SetActive(false);
            Bomb.gameObject.SetActive(true);
        }
        else if (!gunMode)
        {
            gunMode= true;
            state = State.shot;
            gun.gameObject.SetActive(true);
            Bomb.gameObject.SetActive(false);
        }
              
        
    }
  
    private void Shot()
    {
        if(input.shotBullet && shotTime >= 0.1)
        {
            if (state == State.InstallBomb&&GameManager.Instance.fieldBobmCount==0)
            {
                goboom();
            }
            if (state == State.shot)
            {
                RaycastHit target;
                if (Physics.Raycast(shotPosition.transform.position, shotPosition.forward, out target, 50.0f))
                {
                    EnemyHealth enemy = target.collider.GetComponent<EnemyHealth>();
                    HeadShot head = target.collider.GetComponent<HeadShot>();
                    FieldBomb bomb = target.collider.GetComponent<FieldBomb>();
                    Portal portal = target.collider.GetComponent<Portal>();
                    if (enemy != null)
                    {

                        enemy.OnDamage(1, target.point, target.normal, transform);
                        StartCoroutine(shotDeirection(target.point));

                    }
                    else if (head != null)
                    {
                        head.OneKill(10, target.point, target.normal, transform);
                        StartCoroutine(shotDeirection(target.point));
                    }
                    else if (bomb != null)
                    {
                        bomb.boom();
                        Debug.Log("붐 찾는데 성공");
                        StartCoroutine(shotDeirection(bomb.transform.position));
                    }
                    else
                    {
                        StartCoroutine(shotDeirection(shotPosition.transform.position + shotPosition.transform.forward * 50));
                    }
                    Debug.Log("발사!");
                    shotTime = 0;
                    bulletCount--;
                    BulletCounting(bulletCount);
                    if (bulletCount <= 00)
                    {
                        state = State.reload;
                        StartCoroutine(reloadAni());
                    }
                }
            }
    

        }
    }
    void goboom() 
    {    
        Instantiate(FiledBomb, transform.position+transform.forward, Quaternion.identity);
    }
    IEnumerator reloadAni()
    {
        Debug.Log("첫번째 리로드 실행");          
        yield return new WaitForSeconds(2.0f);
        reload();
     
        
    }
    public void reload()
    {
      
        Debug.Log("리로드 레츠고");
        shotSound.PlayOneShot(reloadClip);
        //추후 애니메이션,소리등 추가 해야함 
        bulletCount = 30;
        BulletCounting(bulletCount);
        state =State.shot;
        ammo.transform.position = reloadPosition.transform.position;

    }
    IEnumerator shotDeirection(Vector3 hitPoint)
    {
        //shotEffect.Play();
        outBullet.Play();
        shotSound.PlayOneShot(shotSounds);

        transform.position = transform.position + transform.up * Time.deltaTime;
        lineRenderer.enabled = true;
        lineRenderer.SetPosition(0, shotPosition.transform.position);
        lineRenderer.SetPosition(1, hitPoint);
  

        yield return new WaitForSeconds(0.02f);

        transform.position = RiflePosition.transform.position;




        lineRenderer.enabled = false;
        Debug.Log("비활성화 완료");
    }
    public void BulletCounting(int bullet)
    {
        bulletCounting.text = bullet.ToString() + "/30";
    }
    //지속적으로 총알을 파괴하고 소환하고 한다면 무리가감

}
