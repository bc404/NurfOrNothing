/* Chandler, May 30 
initialized the input manager
added methods to disable and enable the onfoot actions from the input manager 
initialized player motor 
player now moves according to value in player motor 
initialized jump action to player motor jump function 
player now looks around according to value in player motor 
June 8 
added a gun fire coroutine 
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
    private PlayerLook look; 

    [SerializeField] Gun gun; 

    Coroutine fireCoroutine;

    // Start is called before the first frame update
    void Awake()
    {
        playerInput = new PlayerInput(); 
        onFoot = playerInput.OnFoot; 

        motor = GetComponent<PlayerMotor>(); 
        look = GetComponent<PlayerLook>(); 

        onFoot.Jump.performed += ctx => motor.Jump();
        onFoot.Crouch.performed += ctx => motor.Crouch();
        onFoot.Sprint.performed += ctx => motor.Sprint();
        onFoot.Shoot.started += _ => StartFiring(); 
        onFoot.Shoot.canceled += _ => StopFiring(); 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //tell the playermotor to move using the value from our movement action 
        motor.ProcessMove(onFoot.Movement.ReadValue<Vector2>()); 
    }

    private void LateUpdate()
    {
        look.ProcessLook(onFoot.Look.ReadValue<Vector2>()); 
    }

    void StartFiring()
    {
        fireCoroutine = StartCoroutine(gun.RapidFire()); 
    }

    void StopFiring()
    {
        if (fireCoroutine != null)
        {
            StopCoroutine(fireCoroutine); 
        }
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
