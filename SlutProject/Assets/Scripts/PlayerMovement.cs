using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb2D;

    private float walkSpeed;
    private float runSpeed;
    private float jumpForce;
    private bool isJumping;
    private float moveVertical;
    private float moveHorizontal;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();

        walkSpeed = 0.2f;
        runSpeed = 0.5f;
        jumpForce = 10f;
        isJumping = false;
    }

    // Update is called once per frame
    void Update()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        if (moveHorizontal >0.1f || moveHorizontal < -0.1f)
        {
            rb2D.AddForce(new Vector2(moveHorizontal * walkSpeed, 0f), ForceMode2D.Impulse);
        }    
        if (!isJumping && moveVertical >0.1f)
        {
            rb2D.AddForce(new Vector2(0f, moveVertical * jumpForce), ForceMode2D.Impulse);
        }    

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isJumping = false;
        }
    }

    void OnTriggerExit2D(Collider2D collision) 
    {
       if(collision.gameObject.tag == "Ground")
        {
            isJumping = true;
        }  
    }
}
