using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{

    public GameObject breakableWall;

   void OnCollisionEnter2D(Collision2D collision) 
   {
        Destroy(breakableWall);
   }
}
