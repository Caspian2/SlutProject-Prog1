using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb2D;
    [SerializeField]private BoxCollider2D coll;
    [SerializeField]private BoxCollider2D crouchingcoll;
    [SerializeField] LayerMask jumpableGround;

    public Animator animator;

    public float moveSpeed;
    private float runSpeed;
    private float walkSpeed;
    private float crouchSpeed;
    private float jumpForce;
    private float moveInput;
    

    private bool jumped = false;
    private bool canDoubleJump;
    private bool crouching;
    public bool facingRight = true;
    

    // Start is called before the first frame update
    void Start()
    {   
        rb2D = GetComponent<Rigidbody2D>(); 
        coll = GetComponent<BoxCollider2D>(); 
        crouchingcoll = GetComponent<BoxCollider2D>(); 
        animator = GetComponent<Animator>();   

        moveSpeed = 0f;
        walkSpeed = 3f;
        runSpeed = 6f;
        crouchSpeed = 1.5f;
        jumpForce = 13f;
    
    }

    private void Update()
    {

        SetAnimationState();

        //Kollar om jag tycker space och är grounded, detta gör att jumped är sant vilket gör att jag hoppar
        if(IsGrounded())
        {
            canDoubleJump = true;
        }

        if(moveInput<0 && facingRight) // Om jag går åt vänster och kollar höger så byter det till vänster
        {
            flip();
        }
        else if(moveInput>0 && !facingRight) // Om jag går åt höger och kollar vänster byter det till höger
        {
            flip(); 
        }


        /*Om jag trycker space kollar den om jag är groundad om jag är det kan jag hoppa, om jag inte är det kollar den om jag kan dubbelhoppa
        om jag kan det hoppar jag och sen sätter att jag inte längre kan dubbelhoppa*/
        if(Input.GetButtonDown("Jump"))
        {
            if(IsGrounded())
            {
               jumped = true;
               canDoubleJump = true;
            }else if(canDoubleJump)
            {
                jumped = true;
                canDoubleJump = false;
                    
            }
        }

        //När jag crouchar tas min standingcoll bort men min crouching coll är kvar, när jag släpper crouch blir det normalt igen
        if(Input.GetButtonDown("Crouch"))
        {     
            crouching = true;
            coll.enabled = false; 
    
        } 
        else if(Input.GetButtonUp("Crouch")) 
            {
                crouching = false;   
                coll.enabled = true;
                
            }
      
    
        //Kollar om man trycker "a" eller "d" om man trycker "a" får moveInput ett värde på -1 om man trycker "d" får den 1
        moveInput = Input.GetAxisRaw("Horizontal");
    }

    // Jag använder FixedUpdate istället för Update eftersom jag använder Unitys Physics
    void FixedUpdate()
    { 
       
        //Ger movement beronde på moveInput
        rb2D.velocity = new Vector2(moveInput * moveSpeed, rb2D.velocity.y);

        //Om man trycker shift springer man istället för att gå
        if(Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = runSpeed;
        }else{
            moveSpeed = walkSpeed;
        }
        
        if(Input.GetButton("Crouch"))
        {
            moveSpeed = crouchSpeed;
        }  

        /*Jag kan inte bara ha min hoppfunktion i FixedUpdate eftersom då hoppas jag bara ibland pågrund av att fixedupdate
        Callar inte varje Frame, men genom att kolla buttondown i update och sen cala den i fixedupdate så löser de sig och jag har fortfarande rätt physics*/
        if(jumped)
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpForce);
            jumped = false;
        }
    }   

    void SetAnimationState()
    {
        if(moveInput == 0f)
        {
            animator.SetBool("isWalking", false);
            animator.SetBool("isRunning", false);
        }

        if(jumped == false)
        {
            animator.SetBool("isJumping", false);
        }

        if(rb2D.velocity.y > 1)
        {
            animator.SetBool("isJumping", true);
        }

        if(Mathf.Abs(moveInput) == 1 && jumped == false)
        {
            animator.SetBool("isWalking", true); 
        } 
        
         if(Mathf.Abs(moveSpeed) == 6 && jumped == false)
        {
            animator.SetBool("isRunning", true);
        } else{
            animator.SetBool("isRunning", false);
        }

        if(Input.GetButtonDown("Crouch"))
        {
            animator.SetBool("isCrouching", true);
        } 
        else if(Input.GetButtonUp("Crouch"))
        {
            animator.SetBool("isCrouching", false);
        }
    }

    ///<summary>
    ///Kollar om spelaren är på ett jumpableGround eller inte
    ///</summary>  
    private bool IsGrounded()
    {
        RaycastHit2D BoxcastHit = Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .2f, jumpableGround);
        return BoxcastHit.collider != null;
    }
    ///<summary>
    /// Skapar en Box över crouchingcoll för att kolla om något är över
    ///</summary>
    private bool IsCrouching()
    {
        RaycastHit2D crouchBoxcastHit = Physics2D.BoxCast(crouchingcoll.bounds.center, crouchingcoll.bounds.size, 0f, Vector2.up, 0.1f, jumpableGround);
        return crouchBoxcastHit.collider != null;
    }
  
    ///<summary>
    /// Flipar spriten genom att använda facingright
    ///</summary>
    public void flip()
    {
        facingRight = !facingRight; // Detta gör att när vi callar flip() så byts facingRight från true till false eller false till true
        transform.Rotate(0f, 180f, 0f);
    }
}   
