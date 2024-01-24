using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//엘레베이터에 접근해서 컨트롤하는 스크립트 
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
