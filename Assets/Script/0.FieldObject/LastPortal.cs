using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastPortal : MonoBehaviour
{
    [SerializeField]
    ParticleSystem particle;
    private void Awake()
    {
        particle.Play();
    }
    private void OnTriggerEnter(Collider other)
    {
        PlayerHealth player = other.GetComponent<PlayerHealth>();
        if (player != null&&GameManager.Instance.currentEnemyCount<=0)
        {
            Debug.Log($"현재 enemy카운트{GameManager.Instance.enemyCount}");
            GameManager.Instance.portalCount -= 1;
            GameSceneUIManager.Instance.PortalCurrentCount(GameManager.Instance.portalCount);
            Destroy(gameObject);
        }
        else
        {
            GameManager.Instance.NotClear();
        }
    }
    private void OnDestroy()
    {
        GameManager.Instance.GameFin?.Invoke();
    }
}
