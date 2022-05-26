using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float time;
    public Text textbox;
    public Text bestTime;
    

     void Start() {
        time = 0;
        textbox.text = time.ToString("F2");
        if(PlayerPrefs.HasKey("BestTime") == true){
            bestTime.text = PlayerPrefs.GetFloat("BestTime").ToString();
        } else{
            bestTime.text = "No best time";
        }
    }

    void Update() {
        time += Time.deltaTime;
        textbox.text = time.ToString("F2");
    }

    public void StartTimer () 
    {
        time = 0;
        InvokeRepeating("IncrimentTime", 1, 1); 
    }
    
    public void StopTimer()
    {
        CancelInvoke();
        if (time < PlayerPrefs.GetFloat("BestTime")){
            SetBestTime();
        }
    }


    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.name == ("Player")) {
            Debug.Log("TIMESTE");
            StopTimer();
        }
    }


    void IncrimentTime () 
    {
        time += 1;
        textbox.text = "Time: " + time;
    }
    
    public void SetBestTime(){
        PlayerPrefs.SetFloat("BestTime", time);
        bestTime.text = PlayerPrefs.GetFloat("BestTime").ToString();
    }    
}
