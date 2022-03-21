using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private BoxCollider2D coll;
    [SerializeField] private LayerMask Ground;
    [SerializeField] Transform groundCheckCollider;

    [SerializeField]private bool isGrounded;
    
    const float groundCheckRadius = 0.1f;
    private float moveSpeed;
    private float runSpeed;
    private float walkSpeed;
    private float jumpForce;
    
    private float horizontalMove;
    private float verticalMove;
 

    // Start is called before the first frame update
    void Start()
    {   //Gör så att när jag använder rb2D så gör gameObjectet det. I detta fall är det playern
        rb2D = gameObject.GetComponent<Rigidbody2D>();     

        moveSpeed = 3f;
        walkSpeed = 3f;
        runSpeed = 6f;
        jumpForce = 13f;
        isGrounded = false;
    


    }

    // Update is called once per frame
    void Update()
    {   // Sätter floatsen till unitys inbyggda knappar för movement
        horizontalMove = Input.GetAxisRaw("Horizontal");
        verticalMove = Input.GetAxisRaw("Jump");
    }
    // Jag använder FixedUpdate istället för Update eftersom jag använder Unitys Physics
    void FixedUpdate()
    { 

        GroundCheck();

        void GroundCheck()
        {
            isGrounded = false;
            //Kollar om Groundcheck är på mark eller inte
            Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheckCollider.position, groundCheckRadius, Ground);
            if(colliders.Length > 0)
            {
                isGrounded = true;
            }
        } 
        
        //Om man trycker shift springer man istället för att gå
        if(Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = runSpeed;
        }
        else
        {
            moveSpeed = walkSpeed;
        }
        //Ger Rigidbodyn en movement åt sidan
        rb2D.velocity = new Vector2(horizontalMove * moveSpeed, rb2D.velocity.y);
        //Get Movement uppåt
        if(verticalMove > 0.1f && isGrounded == true)
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, verticalMove * jumpForce);
        }   

        
    }    

  
}   
