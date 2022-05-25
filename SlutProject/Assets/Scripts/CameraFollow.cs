using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform playerTransform;
    public float offset;
    
    // Start is called before the first frame update
    
   
   
    void Start()
    {
       
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        offset = 1.2f;
    }
 

    //Jag använder LateUpdate eftersom jag vill att kameran ska röra sig efter Playern och LateUpdate callar efter Update och FixedUpdate
    void LateUpdate() 
    {
        //Jag sparar kamerans position i en temp variable
        Vector3 temp = transform.position;
        
        //Jag sätter kamerans position till player position
        temp.x = playerTransform.position.x;
        temp.y = playerTransform.position.y;

        //Ökar offseten till kamera positionen
        temp.x += offset;
        temp.y += offset;
        

        //Jag sätter tillbaka kamerans temp poition till kamerans nuvarande position
        transform.position = temp;
    }
}
