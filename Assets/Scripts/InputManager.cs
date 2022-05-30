/* Chandler, May 30 
initialized the input manager
added methods to disable and enable the onfoot actions from the input manager 
initialized player motor 
player now moves according to value in player motor 
initialized jump action to player motor jump function 
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput; 
    private PlayerInput.OnFootActions onFoot; 

    private PlayerMotor motor; 


    // Start is called before the first frame update
    void Awake()
    {
        playerInput = new PlayerInput(); 
        onFoot = playerInput.OnFoot; 
        motor = GetComponent<PlayerMotor>(); 
        onFoot.Jump.performed += ctx => motor.Jump(); 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //tell the playermotor to move using the value from our movement action 
        motor.ProcessMove(onFoot.Movement.ReadValue<Vector2>()); 
    }

    private void OnEnable()
    {
        onFoot.Enable(); 
    }

    private void OnDisable()
    {
        onFoot.Disable(); 
    }

}
