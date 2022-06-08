/* Chandler, May 30 
initialized the players character controller
created method that receives inputs from input manager and applies them to the character controller
added gravity 
now detects if player is on ground
added jump function 
May 31 
added crouch function 
added sprint function 
June 7
game pauses if enemy collides with player 
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
    public float jumpHeight = 1.5f;
    public bool crouching;
    public bool sprinting; 
    public bool lerpCrouch;
    public float crouchTimer;
    public float bumpNumber; 


    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>(); 
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = controller.isGrounded; 

        if (lerpCrouch)
        {
            crouchTimer += Time.deltaTime;
            float p = crouchTimer / 1;
            p *= p;
            if (crouching)
                controller.height = Mathf.Lerp(controller.height, 1, p);
            else
                controller.height = Mathf.Lerp(controller.height, 2, p); 
            if (p > 1)
            {
                lerpCrouch = false;
                crouchTimer = 0f; 
            }
        }
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
        //Debug.Log(playerVelocity.y); 
    }

    public void Jump() {
        if (isGrounded)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity); 
        }
    }

    public void Crouch()
    {
        crouching = !crouching;
        crouchTimer = 0;
        lerpCrouch = true; 
    }

    public void Sprint()
    {
        sprinting = !sprinting;
        if (sprinting)
            speed = 8;
        else
            speed = 5; 
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //Time.timeScale = 0;
            Debug.Log("Bumped");
            bumpNumber++; 
            if (bumpNumber > 2)
            {
                Time.timeScale = 0; 
            }

        }
    }

}
