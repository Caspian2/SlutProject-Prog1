using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public Rigidbody2D rb2D;

    private float speed = 20f;
    private float bulletAlive;

    
    void FixedUpdate() 
    {   //Tar bort bulleten efter 3 sekunder
        bulletAlive += 1f * Time.deltaTime;
        if(bulletAlive >= 3)
        {
            GameObject.Destroy(gameObject);
        }

        rb2D.velocity = transform.right * speed;
        
    }
        //Tar bort bulleten när den går in i något
    void OnTriggerEnter2D() 
    {
        Destroy(gameObject);
    }
}
