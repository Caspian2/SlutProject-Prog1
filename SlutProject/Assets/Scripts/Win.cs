using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
  
  private void OnTriggerEnter2D(Collider2D other) {
      if(other.gameObject.name == ("Player")) 
      {
        CompleteLevel();
      }
  }


  private void CompleteLevel()
  {
    SceneManager.LoadScene("Win");
    
  }
}
