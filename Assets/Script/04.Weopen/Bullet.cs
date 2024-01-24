using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private bool hit;

    Vector3 hitPosition;
    GameObject referenceShotPivot;
  
    
   

    private void Awake()
    {
        hit = false;

    }
    private void OnEnable()
    {

        hit = false;
        Debug.Log("총알 다시 활성화");
    }
    private void FixedUpdate()
    {
     

        transform.position=transform.position+transform.forward*800*Time.deltaTime;
    }
    private void OnTriggerStay(Collider other)
    {
        
        EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
        Debug.Log(enemyHealth.name);
        if(!hit&&enemyHealth!=null)
        {
            //enemyHealth.OnDamage(1,enemyHealth.transform.position,enemyHealth.transform.forward);
        }
    }

}
