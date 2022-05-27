using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{

   public GameObject breakableWall;
   
   private void Start() {
   
   }
   // Om du skjuer laser försvinner den
   void OnTriggerEnter2D(Collider2D other)
   {    
      GameObject.Destroy(gameObject);
      
   }

  
}
