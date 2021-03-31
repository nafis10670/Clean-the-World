using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public float startingTime = 00f;
    

    public Text  TimerText;
   // public Text highscoreText;


    void Awake()
    {
        //highscoreText.text =  GetHighScore().ToString();
    }
    void SetScore()
    {
        
        startingTime +=1 * Time.deltaTime;
        TimerText.text = startingTime.ToString("00");
        
        if (startingTime > GetHighScore()) { 
            PlayerPrefs.SetInt("HighScore", (int) startingTime);
           // highscoreText.text =  startingTime.ToString("00");
        }
    }
    void Update()
    {
        
        if (GameManager.instance.gameStarted)
        {   
            SetScore();
        }
        
    }
    
    
    public int GetHighScore()
    {
        int i = PlayerPrefs.GetInt("HighScore");
        return i;
    }
}
