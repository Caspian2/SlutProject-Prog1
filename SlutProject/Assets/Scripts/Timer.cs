using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float time1;
    public Text textbox;
    public Text bestTime;
    
        //Om det finns en bästatid visar den det i textrutan
     void Start() {
        time1 = 0;
        textbox.text = time1.ToString("F2");
        if(PlayerPrefs.HasKey("BestTime") == true){
            bestTime.text =  PlayerPrefs.GetFloat("BestTime").ToString();
        } else{
            bestTime.text = "No best time";
        }
    }
    // Timer som räknar up varje sekund
    void Update() {
        time1 += Time.deltaTime;
        textbox.text = time1.ToString("F2");
    }

    //Om tiden du klarade banan på är lägre än din bästa tid sätter den en ny bästa tid
    public void StopTimer()
    {       
        if (time1 < PlayerPrefs.GetFloat("BestTime1")){
            SetBestTime();
        }
    }
    // När man går in i målet kör den StopTimer 
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.name == ("Player")) {
            StopTimer();
        }
    }

    // SetFloat besttime som tiden du klarade det på.
    public void SetBestTime(){
        PlayerPrefs.SetFloat("BestTime1", time1);
        bestTime.text = PlayerPrefs.GetFloat("BestTime1").ToString();
    }    
}
