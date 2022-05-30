using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput; 
    private PlayerInput.OnFootActions onFoot; 

    // Start is called before the first frame update
    void Awake()
    {
        playerInput = new PlayerInput(); 
        onFoot = playerInput.OnFoot; 


    }

    // Update is called once per frame
    void Update()
    {
        
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
