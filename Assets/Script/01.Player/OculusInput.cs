using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;

public class OculusInput : MonoBehaviour
{
    [SerializeField]
    InputActionAsset[] inputAsset;//�̰� ������� �ʿ䰡 ��������...
    [SerializeField]
    InputActionReference valueRGrip;//Ʈ���Ÿ� ���������� ���������� �׼�
    [SerializeField]
    InputActionReference valueRTrigger;//Ʈ���Ÿ� ���������� ���������� �׼� 
    [SerializeField]
    public InputActionReference FullView;
    [SerializeField]
    public InputActionReference installFieldBomb;//Enemy ó���� ��ź ��ġ ���� 
    [SerializeField]
    Camera mainCamera1;
 
    [SerializeField]
    Transform cameraPosition;

    public bool shotBullet;
    public bool installBomb;
    
    InputAction trigger;

    //��� �����ؾ��ұ�. �ϴ� �ϳ��� �����ϴ� ��ũ��Ʈ�̴�..�̱���?
    //�׷��� ���������� ���̴°� �ƴ϶� �÷��̾�� ���̴� ���ӿ�����Ʈ �ν����Ϳ� �Ҵ��ϴ°ɷ� ����.
    //��..���� ���� �����ߴ���δ� �ȵǳ�
    //��ǲ�׼Ƿ��۷����� �ٷ� �޾ƿ��� ������Ʈ���� ���������� �������Ѵ�. ���� ���� �ʹ� ���ؼ� ����ȭ�� �Ű��� ��� �ϴµ� �ٸ� ����� ������?
    //1.��ǲ ���¿��� �ϳ��� ������ �޾ƿ´�..? �ϳ��ϳ� ��� �ϴ°� ������ �ʹݿ� ������ ��뷪�� ���� �� ����� ��������� ���ƺ���.
    //2.�׷��ٸ� �̰� �ϳ��ϳ� �ޱ⿡�� ������ �迭�� �޾� ����ϰ� �����Ѵ�.
    //���� �߸��˰� �־��� ...��..���� ����� �־��µ� �̻��ϰ� �س���
    // Start is called before the first frame update\
    private void Awake()
    {
        installBomb = false;
        //inputAsset[0].FindActionMap("XRI LeftHand Interaction").FindAction("Select").performed += thistest;
        //inputAsset[0].FindActionMap("XRI LeftHand Interaction").FindAction("Select").canceled += thistest2;
        valueRGrip.action.performed += OnInstallBomb;
        valueRGrip.action.canceled += OffInstallBomb;
        valueRTrigger.action.performed += OnShot;
        valueRTrigger.action.canceled += OffShot;
     
   

        Debug.Log("��ŧ���� ��ǲ ����");
    }
    void Start()
    {

    }
    void Update()
    {
    }
    private void ThrowBomb()
    {
        
    }
    public void ZoomIn(InputAction.CallbackContext obj)
    {
        mainCamera1.fieldOfView = 10f;
    }
    public void ZoomOut(InputAction.CallbackContext context)
    {
        mainCamera1.fieldOfView = 90f;
    }
    public void OnInstallBomb(InputAction.CallbackContext obj)
    {
        installBomb = true;
        Debug.Log("�� ��������");
    }
    public void OffInstallBomb(InputAction.CallbackContext obj)
    {
        installBomb = false;
    }
    public void OnShot(InputAction.CallbackContext obj)
    {
        shotBullet=true;
    }
    public void OffShot(InputAction.CallbackContext obj)
    {
        shotBullet = false;
    }
    // Update is called once per frame
}
