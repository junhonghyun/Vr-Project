using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    /*엘레베이터 스크립트   
+ 현재 문제점 움직일때마다 카메라 움직임 
    +충돌할떄 레이어 체크가 안되어서 컨트롤이 안되는중 
    조금 더 쉬운 방법은 없을까?
    일단은 다른것들도 구현해야하니 무조건 아래로 고정하는 방식으로 진행

    =>추후 수정할것
    카메라 떨림현상 수정 ,캐릭터 끼임현상 
     */
    Rigidbody elvRgb;//리지드바디 
    public int moveDirection;
    public bool stopElevator;
    public bool goMove;
    //[SerializeField]
    //[Header("엘레베이터 트리거")]
    //private LayerMask elevatorTrigger;

    private void Awake()
    {
        elvRgb = GetComponent<Rigidbody>();
        moveDirection = 0;
        stopElevator = false;
    }
    private void FixedUpdate()
    {
        if (goMove)
        {

            MoveElv();
        }
  
    }
    private void MoveElv()
    {
        transform.position = transform.position + transform.up * moveDirection * Time.deltaTime*5;
    }
    private void OnTriggerEnter(Collider other)
    {
        CharacterController character = other?.GetComponent<CharacterController>();
        if (character != null)
        {
            goMove = true;

        }
    }
    private void OnTriggerStay(Collider other)
    {
        CharacterController character = other?.GetComponent<CharacterController>();
        if (character != null)
        {         
            if(goMove) 
            {
                character.transform.position = transform.position + transform.up * moveDirection * Time.deltaTime * 5;
            }

        }
    }

    //private void OnTriggerExit(Collider other)
    //{
    //    CharacterController character = other.GetComponent<CharacterController>();
    //    if (character != null)
    //    {            
    //        moveDirection = -1;
    //    }
    //}
}
