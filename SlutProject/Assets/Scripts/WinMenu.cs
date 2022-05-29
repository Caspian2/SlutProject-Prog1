using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinMenu : MonoBehaviour
{ 

  public Text time;
  public Text time2;


  public void ToMainMenu()
   {
       SceneManager.LoadScene("MainMenu");
   }

  // visar bästa tiden
   private void Start() {
      time.text = PlayerPrefs.GetFloat("BestTime").ToString();
      time2.text = PlayerPrefs.GetFloat("BestTime2").ToString();
   }
}
