using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//���������Ϳ� �����ؼ� ��Ʈ���ϴ� ��ũ��Ʈ 
public class ElevatorTrigger : MonoBehaviour
{
    [SerializeField]
    private string moveDirection;

    private void OnTriggerEnter(Collider other)
    {
        Elevator elevator =other.GetComponent<Elevator>();
        if (elevator != null) 
        {         
            if(moveDirection =="up") 
            {
                elevator.moveDirection = 1;
                elevator.goMove = false;
            }
            if(moveDirection=="down")
            {
                elevator.moveDirection = -1;
                elevator.goMove = false;
            }
                
            
        }
    }
    //private void OnTriggerExit(Collider other)
    //{
    //    Elevator elevator = other.GetComponent<Elevator>();
    //    if (elevator != null)
    //    {
    //        elevator.stopElevator = false;
    //    }
    //}

}
