using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bJump : MonoBehaviour
{
    public float fallMultiplier = 2.5f;


    Rigidbody2D rb;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }
    // Gör så när man har nått sin hösta punkt i hoppet så faller man snabbare
    private void  Update() {
        if(rb.velocity.y < 0){
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        } 
    }

}
