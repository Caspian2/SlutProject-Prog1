using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public static bool isPaused = false;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
           if(isPaused == true)
           {
               resumeGame();
           }
           else
           {
               pauseGame();
           } 

        }
    }


    //Pausar tiden och aktiverar pausemenun
    public void pauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    //Tar bort pausmenun och sätter igång timern
    public void resumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    //Tar en tillbaka till mainmenu
    public void ToMainMenu()
   {
       Time.timeScale = 1f;
       SceneManager.LoadScene("MainMenu");
       isPaused = false;
   }
}
