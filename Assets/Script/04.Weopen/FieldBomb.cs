using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldBomb : MonoBehaviour
{
    //��ź ������Ʈ �޾ƿ���
    //��ƼŬ �޾ƿ��� 
    //�ǰݽ� ��ź�� ������� �ұ��� ���۵Ǹ� Enemy���� ������ ���� 5�ʰ� ���� �ð��� ������ �ı��Ǹ鼭 ��ź���� ���� 
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
        Debug.Log("������");
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
