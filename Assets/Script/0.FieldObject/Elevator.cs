using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    /*���������� ��ũ��Ʈ   
+ ���� ������ �����϶����� ī�޶� ������ 
    +�浹�ҋ� ���̾� üũ�� �ȵǾ ��Ʈ���� �ȵǴ��� 
    ���� �� ���� ����� ������?
    �ϴ��� �ٸ��͵鵵 �����ؾ��ϴ� ������ �Ʒ��� �����ϴ� ������� ����

    =>���� �����Ұ�
    ī�޶� �������� ���� ,ĳ���� �������� 
     */
    Rigidbody elvRgb;//������ٵ� 
    public int moveDirection;
    public bool stopElevator;
    public bool goMove;
    //[SerializeField]
    //[Header("���������� Ʈ����")]
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
