using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    // Går du in i målet klarar du banan
  private void OnTriggerEnter2D(Collider2D other) {
      if(other.gameObject.name == ("Player")) 
      {
        CompleteLevel();
      }
  }

 // Ny scen
  private void CompleteLevel()
  { 
    SceneManager.LoadScene("Win");
    
  }
}
