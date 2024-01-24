using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyHealth : MonoBehaviour, IDamageable
{

    Animator animator;
    CapsuleCollider bodycollider;
    public int health;
    public event Action die;
    public event Action reSpawn;
    EnemyAI enemyAI;
    public bool zeroHp;
    [SerializeField]
    ParticleSystem hitEffect;
    private float reSpawnTime;

    private void Awake()
    {
        zeroHp = false;
        enemyAI = GetComponent<EnemyAI>();
        health = 10;
        bodycollider = GetComponent<CapsuleCollider>();
        animator = GetComponent<Animator>();
        die += Die;
    }
    private void OnEnable()
    {
        health = 10;
    }
    public void OnDamage(int damage, Vector3 hitposition, Vector3 direction,Transform playerPosition)
    {
        if (!zeroHp)
        {

            hitEffect.transform.position = hitposition;
            hitEffect.transform.rotation = Quaternion.LookRotation(direction);
            hitEffect.Play();
            enemyAI.nowposition = playerPosition; //타격을 입을시 플레이어 위치를 받아 따라옴 

            //피격 효과음 실행 해야함 
            health -= damage;
            if (health <= 0)
            {

                die?.Invoke();
            }
        }
    }

    private void Die()
    {
        zeroHp=true;
        animator.SetTrigger("Die");
        hitEffect.gameObject.SetActive(false);
        
        bodycollider.enabled = false;    
        GameManager.Instance.enemyCount--;
        GameManager.Instance.currentEnemyCount--;
        GameSceneUIManager.Instance.EnemyCurrenCount(GameManager.Instance.currentEnemyCount);
        Debug.Log("사망");
    }
  

}
