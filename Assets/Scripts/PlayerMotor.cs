/* Chandler, May 30 
initialized the players character controller
created method that receives inputs from input manager and applies them to the character controller
added gravity 
now detects if player is on ground
*/ 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller; 
    private Vector3 playerVelocity; 
    private bool isGrounded; 
    public float speed = 5f; 
    public float gravity = -9.8f; 

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>(); 
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = controller.isGrounded; 
    }

    //receive the inputs for our InputManager.cs and apply them to our character controller
    public void ProcessMove(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero; 
        //translates input x direction to movement across the x axis (left and right)
        moveDirection.x = input.x; 
        //translates input y direction to movement across the z axis (forward and backward)
        moveDirection.z = input.y; 
        controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime); 
        playerVelocity.y += gravity * Time.deltaTime; 
        if(isGrounded && playerVelocity.y < 0 )
              playerVelocity.y = -2f; 
        controller.Move(playerVelocity * Time.deltaTime); 
        Debug.Log(playerVelocity.y); 
    }

}
