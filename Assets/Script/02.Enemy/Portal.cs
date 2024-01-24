using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        PlayerHealth player=other.GetComponent<PlayerHealth>();
        if(player!=null) 
        {
            GameManager.Instance.portalCount -= 1;
            GameSceneUIManager.Instance.PortalCurrentCount(GameManager.Instance.portalCount);
            Destroy(gameObject);
        }
    }
    private void OnDestroy()
    {
        if (GameManager.Instance.portalCount <= 0)
        {
            GameManager.Instance.LastGoPortal();
        }
    }
}
