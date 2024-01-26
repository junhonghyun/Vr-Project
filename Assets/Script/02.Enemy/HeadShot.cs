using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeadShot : MonoBehaviour
{
    [SerializeField]
    EnemyHealth enemy;
    [SerializeField]
    GameObject headShotImage;

    public void OneKill(int damage,Vector3 hitposition, Vector3 direction, Transform playerPosition)
    {
        headShotImage.SetActive(true);
       enemy.OnDamage(damage, hitposition, direction, playerPosition);
        ScoreContainer.Instance.headShot++;
        Invoke("Off", 1.0f);
        Debug.Log("Çìµå¼¦!");
    }
    public void Off()
    {
        headShotImage?.SetActive(false);
    }
}
