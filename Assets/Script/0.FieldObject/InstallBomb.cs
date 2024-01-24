using Michsky.UI.Heat;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstallBomb : MonoBehaviour
{
    private float time;
    [SerializeField]
    [Header("Bomb")]
    private GameObject bomb;

    private bool installBomb;
    private void OnTriggerEnter(Collider other)
    {
        OculusInput player = other.GetComponent<OculusInput>();
        if (player != null)
        {
            GameSceneUIManager.Instance.InBombposition();
            GameSceneUIManager.Instance.OnColsole();
            if (!installBomb)
            {
                GameSceneUIManager.Instance.Console("���� �׸��� ���� ��ź�� ��ġ���ּ���");
            }
            else if (installBomb)
            {
                GameSceneUIManager.Instance.Console("��ź ��ġ�� �Ϸ�� ���� �Դϴ�.");
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        OculusInput player=other.GetComponent<OculusInput>();
        if(player!=null)
        {
            if (player.installBomb&&!installBomb)
            {
                time += Time.deltaTime;
                GameSceneUIManager.Instance.InstallBomb(time);
            }
            else
            {
                time = 0;
                GameSceneUIManager.Instance.InstallBomb(time);
            }
            Debug.Log(time);
            if(time>5&&!installBomb)
            {
                GameSceneUIManager.Instance.Console("��ź ��ġ�� �Ϸ�� ���� �Դϴ�.");
                Instantiate(bomb,transform.position+transform.up*-1, Quaternion.identity);
                installBomb= true;
                GameSceneUIManager.Instance.InstallBomb(time);

            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        OculusInput player = other.GetComponent<OculusInput>();
        if (player != null)
        {
            GameSceneUIManager.Instance.InBombposition();
            GameSceneUIManager.Instance.InstallBomb(0);
            GameSceneUIManager.Instance.OffConsole();
        }
    }

    private void OnDestroy()
    {
        GameSceneUIManager.Instance.OutBombposition();
    }
}
