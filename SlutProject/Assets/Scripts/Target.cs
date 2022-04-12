using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{

    public GameObject breakableWall;

   void OnTriggerEnter2D(Collider2D other)
   {    
     Destroy(breakableWall);
   }

  
}
