using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public bool stopWatchActive = false;
    public static float currentTime;
    public Text currentTimeText;
    public Text levelTime;
    public Enabled_Disabled gameOver;
    //public float levelTime;


    // Start is called before the first frame update
    void Start()
    {
        stopWatchActive = true;
        currentTime = 0;
        Time.timeScale = 0.8f;
        loadTimeData();

        gameOver = GameObject.FindGameObjectWithTag("GameOver").GetComponent<Enabled_Disabled>();
        if (gameOver != null)
        {
            gameOver.DisableGameOver();
        }
        //Invoke("GameOver", 60);
    }

    
    // Update is called once per frame
    void Update()
    {
        if (stopWatchActive == true)
        {
            currentTime += Time.deltaTime;
            TimeSpan time = TimeSpan.FromSeconds(currentTime);
            currentTimeText.text = time.ToString(@"mm\:ss");
            saveTimeData(currentTimeText);

            if (currentTime >= 30) // Example: if the timer reaches 60 seconds
            {
                GameOver();
            }
        } 
        /*
        if (stopWatchActive == true)
        {
            currentTime = currentTime + Time.deltaTime; // adding real time in seconds from fames
        }
        TimeSpan time = TimeSpan.FromSeconds(currentTime); // converts to hours, minutes, and seconds
        currentTimeText.text = time.ToString(@"mm\:ss");
        saveTimeData(currentTimeText);
        //Invoke("GameOver", 60);
        */
    }

    public void StopTime()
    {
        stopWatchActive = false;
        Time.timeScale = 0f;
    }

    public void StartTime()
    {
        stopWatchActive = true;
        Time.timeScale = 0.8f;
    }

    public void saveTimeData(Text current)
    {
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            PlayerPrefs.SetFloat("Time1", currentTime);
            PlayerPrefs.SetString("Time1Text", currentTimeText.text);
            PlayerPrefs.Save();
            //loadTimeData();
        }
    }

    public void loadTimeData()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {

            // Load the saved time and set it in the UI element
            float savedTime = PlayerPrefs.GetFloat("Time1"); // Default to 0 if no data is found
            string savedTimeText = PlayerPrefs.GetString("Time1Text"); // Default format

            currentTime = savedTime; // Restore the saved current time
            levelTime.text = "Time: " + savedTimeText; // Display the saved time
   
            if(savedTime > 0)
            {
                StopTime();
            }
            PlayerPrefs.DeleteAll();
            //levelTime.text = "Time: " + PlayerPrefs.GetString("Time1Text");
            //stopWatchActive = false;

        }
    }

    void GameOver()
    {
        if (gameOver != null)
        {
            StopTime();
            gameOver.EnableGameOver();
            //StopTime();
        }
        // will make Binary exit button transition to the main menu
       // SceneManager.LoadSceneAsync(0);
    }

}
