using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    // startar spelet
   public void PlayGame()
   {
       SceneManager.LoadScene("Level 1");
   } 

   public void LevelSelect()
   {
       SceneManager.LoadScene("LevelSelect");
   }


    //Stänger av spelet
   public void QuitGame()
   {
       Application.Quit();
   }

   
}
