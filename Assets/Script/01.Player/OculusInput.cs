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
    InputActionAsset[] inputAsset;//이걸 가지고올 필요가 없었구만...
    [SerializeField]
    InputActionReference valueRGrip;//트리거를 지속적으로 눌렀을때의 액션
    [SerializeField]
    InputActionReference valueRTrigger;//트리거를 지속적으로 눌렀을때의 액션 
    [SerializeField]
    public InputActionReference FullView;
    [SerializeField]
    public InputActionReference installFieldBomb;//Enemy 처리용 폭탄 설치 변수 
    [SerializeField]
    Camera mainCamera1;
 
    [SerializeField]
    Transform cameraPosition;

    public bool shotBullet;
    public bool installBomb;
    
    InputAction trigger;

    //어떻게 진행해야할까. 일단 하나만 존재하는 스크립트이니..싱글톤?
    //그런데 여러곳에서 쓰이는게 아니라 플레이어에만 쓰이니 게임오브젝트 인스펙터에 할당하는걸로 하자.
    //어..뭐지 내가 생각했던대로는 안되네
    //인풋액션레퍼런스로 바로 받아오면 업데이트에서 지속적으로 돌려야한다. 현재 렉이 너무 심해서 최적화에 신경을 써야 하는데 다른 방법은 없을까?
    //1.인풋 에셋에서 하나씩 값들을 받아온다..? 하나하나 적어여 하는게 많지만 초반에 데이터 사용랴이 많은 것 뺴고는 장기적으로 좋아보임.
    //2.그렇다면 이걸 하나하나 받기에는 무리니 배열로 받아 깔끔하게 진행한다.
    //뭔가 잘못알고 있었다 ...ㅎ..쉬운 방법이 있었는데 이상하게 해놨네
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
     
   

        Debug.Log("오큘러스 인풋 실행");
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
        Debug.Log("꾹 누르는중");
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
