/* Chandler, May 30 
initialized the players character controller
created method that receives inputs from input manager and applies them to the character controller
*/ 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller; 
    private Vector3 playerVelocity; 
    public float speed = 5f; 

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
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
    }

}
