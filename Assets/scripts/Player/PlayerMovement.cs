using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : PlayerAttributes
{

    // ===== VARIABLES =====

    public float speed = 7f;
    public float gravity = 9.81f;
    public float jumpHeight = -5f;
    float x;
    float z;
    

    // groundCheck is a sphere at the bottom of the player, it's set to search for whatever is in the
    // ground layer and if it interects with one, we can stop the player's y velocity plummeting while
    // they're on the ground, helps with the gravity stuff.
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;
    bool isSprinting;

    public Vector3 currentPos;
    Vector3 move;
    Vector3 velocity;
    CharacterController playerController;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        
        PlayerGravity();
        PlayerInput();
        currentPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
       
    }


    void PlayerInput()
    {
        isSprinting = Input.GetKey(KeyCode.LeftShift);
        // if we're on the ground, the player can move with WASD, no more weird movement when in the air!
        if (isGrounded)
        {
            x = Input.GetAxisRaw("Horizontal");
            z = Input.GetAxisRaw("Vertical");
          
        }
        switch(isSprinting)
        {
            case true:
                speed = 14f;
                break;
            case false:
                speed = 7f;
                break;
            default:
                print("If you got this, something went horrible wrong in PlayerMovement!");
                break;
        }
            
                    
        // setting the move vector3 var with the player input that was plugged into x and z.
        move = transform.right * (x * speed * Time.deltaTime) + transform.forward * (z * speed * Time.deltaTime);
        // handy lil function from unity! Make's life a whole lot easier :D
        playerController.Move(move);
    }

    void PlayerGravity()
    {
        // so if the ground check sphere is intersecting with the ground, it sets the isGrounded bool to true
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);


        // and if it's true we set our y velocity to a nice small number.
        if (isGrounded && velocity.y < 0)
        {
 
            velocity.y = 0.2f;
        }

        // jumpy jumpy! But only if we're on the ground! otherwise we'd be able to jump up forever by spamming space.
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            // some math formula for how jumps work
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);

            // i think these are redundant now?
            x = 0;
            z = 0;
        }

        // okay so we're constantly minus our y velocity to the gravity strength, without the ground check setting it to 0.2 every time we're on the ground
        // this value would just exponentially decrease, leading to crazy fast falls!
        velocity.y -= gravity * Time.deltaTime;
        playerController.Move(velocity * Time.deltaTime);

    }


}
