using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private BoxCollider2D coll;

    [SerializeField] LayerMask jumpableGround;

    private float moveSpeed;
    private float runSpeed;
    private float walkSpeed;
    private float jumpForce;
    private float moveInput;

    private bool jumped = false;
    private  bool canDoubleJump;
    

    // Start is called before the first frame update
    void Start()
    {   
        rb2D = GetComponent<Rigidbody2D>(); 
        coll = GetComponent<BoxCollider2D>();    

        moveSpeed = 3f;
        walkSpeed = 3f;
        runSpeed = 6f;
        jumpForce = 13f;
    
    }

    void Update()
    {
        //Kollar om jag tycker space och är grounded, detta gör att jumped är sant vilket gör att jag hoppar
        if(IsGrounded())
        {
            canDoubleJump = true;
        }
        /*Om jag trycker space kollar den om jag är groundad om jag är det kan jag hoppa, om jag inte är det kollar den om jag kan dubbelhoppa
        om jag kan det hoppar jag och sen sätter att jag inte längre kan dubbelhoppa*/
        if(Input.GetButtonDown("Jump"))
        {
            if(IsGrounded())
            {
               jumped = true;
            }else
                {
                if(canDoubleJump)
                    {
                    jumped = true;
                    canDoubleJump = false;
                    }
                }
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

        /*Jag kan inte bara ha min hoppfunktion i FixedUpdate eftersom då hoppas jag bara ibland pågrund av att fixedupdate
        Callar inte varje Frame, men genom att kolla buttondown i update och sen cala den i fixedupdate så löser de sig och jag har fortfarande rätt physics*/
        if(jumped)
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpForce);
            jumped = false;
        }
    }   
    //Kollar om spelaren är på ett jumpableGround eller inte
    private bool IsGrounded()
    {
        RaycastHit2D BoxcastHit = Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .2f, jumpableGround);
        return BoxcastHit.collider != null;
    }
}   
