using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldBomb : MonoBehaviour
{
    //폭탄 오브젝트 받아오기
    //파티클 받아오기 
    //피격시 폭탄은 사라지고 불길이 시작되며 Enemy에게 공격을 가함 5초간 지속 시간이 지나면 파괴되면서 폭탄개수 차감 
    [SerializeField]
    GameObject bomb;
    [SerializeField]
    ParticleSystem boomFire;
    AudioSource fireAudio;
    [SerializeField]
    AudioClip audioClip;
    public bool startBoom;
    float DestroyTime;
    private void Awake()
    {
        startBoom = false;
        fireAudio=GetComponent<AudioSource>();
        GameManager.Instance.fieldBobmCount--;
    }
    private void FixedUpdate()
    {
        if(startBoom)
        {
            DestroyTime += Time.deltaTime;
            if(DestroyTime>=5)
            {
                Destroy(gameObject);
            }
        }
    }

    public void boom()
    {
        fireAudio.PlayOneShot(audioClip);
        bomb.SetActive(false);
        boomFire.gameObject.SetActive(true);
        startBoom= true;
        Debug.Log("터져라");
    }
    private void OnTriggerStay(Collider other)
    {
        EnemyHealth enemy=other.GetComponent<EnemyHealth>();
        if(enemy != null )
        {
            enemy.OnDamage(1,transform.position,transform.position,transform);
        }
    }
    private void OnDestroy()
    {
        GameManager.Instance.fieldBobmCount++;
    }
}
