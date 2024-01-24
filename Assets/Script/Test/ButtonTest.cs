using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;

public class ButtonTest : MonoBehaviour
{
    public InputActionReference jump;
    CharacterController characterController;
    public LayerMask Ground;
    float jumpPower;

    private void Awake()
    {
        characterController= GetComponent<CharacterController>();
    
    }
    void Update()
    {

    }
    private void FixedUpdate()
    {
        jump.action.performed += Onjump;
        //if (!OnGround())
        //{
        //    transform.position = transform.position + transform.up * -9.8f*Time.deltaTime;
        //}
    }
    void Onjump(InputAction.CallbackContext obj)
    {
        jumpPower = 100f;
    }
    //public bool OnGround()
    //{
    //    Collider[] chk = Physics.OverlapSphere(transform.position, 0.2f, Ground);
    //    return chk.Length > 0;
    //}
}
