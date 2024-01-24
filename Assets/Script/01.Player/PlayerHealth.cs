using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour,IDamageable
{
    int playerHealth;
    private void Awake()
    {
        playerHealth = 3;
        GameSceneUIManager.Instance.PlayerHP(playerHealth);
    }
    public void OnDamage(int damage, Vector3 hitposition, Vector3 direction, Transform playerPosition)
    {
        if (playerHealth > 0)
        {
            playerHealth -= damage;
            GameSceneUIManager.Instance.PlayerHP(playerHealth);
            Debug.Log($"�÷��̾� ü��{playerHealth}");
            if (playerHealth <=0)
            {
                GameManager.Instance.playerDie?.Invoke();
                Debug.Log("ĳ���� ���!");
            }
        }
    
    }

  
}
