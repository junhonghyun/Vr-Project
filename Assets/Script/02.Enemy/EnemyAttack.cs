using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    int attack;
    private void Awake()
    {
        attack = 0;
    }
    private void OnEnable()
    {
        attack = 0;
    }
    private void OnTriggerStay(Collider other)
    {
        PlayerHealth player=other.GetComponent<PlayerHealth>();
        if(player != null&&attack==0)
        {
            attack = 1;
            player.OnDamage(1, transform.position, transform.position, transform);
            player=null;
            Debug.Log("데미지 입히기 성공!");
        }
    }
}
