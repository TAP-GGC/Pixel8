using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using JetBrains.Annotations;



public class Timer : MonoBehaviour
{
    public bool stopWatchActive = false;
    public static float currentTime;
    public Text currentTimeText;
    public Text levelTime;
    public Enabled_Disabled gameOver;

    //private Text level;
    //public Text gameTime;

    public List<string> playerTime = new List<string>();
    public List<float> playerSeconds = new List<float>();

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

        //level.text = "";
        //gameTime.text = "";
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

            if (currentTime >= 720) // Example: if the timer reaches 12 mins
            {
                GameOver();
            }
        } 
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
        if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            PlayerPrefs.SetFloat("Time1", currentTime);
            PlayerPrefs.SetString("Time1Text", currentTimeText.text);
            PlayerPrefs.Save();
        } 
        else if (SceneManager.GetActiveScene().buildIndex == 10)
        {
            PlayerPrefs.SetFloat("Time2", currentTime);
            PlayerPrefs.SetString("Time2Text", currentTimeText.text);
            PlayerPrefs.Save();
        } 
        else if (SceneManager.GetActiveScene().buildIndex == 11)
        {
            PlayerPrefs.SetFloat("Time3", currentTime);
            PlayerPrefs.SetString("Time3Text", currentTimeText.text);
            PlayerPrefs.Save();
        }
    }

    public void loadTimeData()
    {
        if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            //List<string> playerTime = new List<string>();
            //List<float> playerSeconds = new List<float>();

            // Load the saved time and set it in the UI element
            float savedTime = PlayerPrefs.GetFloat("Time1"); // Default to 0 if no data is found
            string savedTimeText = PlayerPrefs.GetString("Time1Text"); // Default format

            currentTime = savedTime; // Restore the saved current time
            levelTime.text = "Time: " + savedTimeText; // Display the saved time

            //playerTime.Add(savedTimeText);
            //playerSeconds.Add(savedTime);

            //playerTime.Add(PlayerPrefs.GetString("Time1Text"));
            //playerSeconds.Add(PlayerPrefs.GetFloat("Time1"));
            //finalTime(playerTime, playerSeconds);

            if (savedTime > 0)
            {
                //StopTime();
                //currentTime = 0;
            }
            PlayerPrefs.DeleteAll();
        } 
        else if(SceneManager.GetActiveScene().buildIndex == 10)
        {
            float savedTime = PlayerPrefs.GetFloat("Time2"); // Default to 0 if no data is found
            string savedTimeText = PlayerPrefs.GetString("Time2Text"); // Default format

            currentTime = savedTime; // Restore the saved current time
            levelTime.text = "Time: " + savedTimeText; // Display the saved time

            if (savedTime > 0)
            {
                StopTime();
                //currentTime = 0;
            }
            //PlayerPrefs.DeleteAll();
            
        } 
        else if (SceneManager.GetActiveScene().buildIndex == 11)
        {
            float savedTime = PlayerPrefs.GetFloat("Time3"); // Default to 0 if no data is found
            string savedTimeText = PlayerPrefs.GetString("Time3Text"); // Default format

            currentTime = savedTime; // Restore the saved current time
            levelTime.text = "Time: " + savedTimeText; // Display the saved time

            if (savedTime > 0)
            {
                StopTime();
                //currentTime = 0;
            }
            //PlayerPrefs.DeleteAll();
        } 
        else
        {
            PlayerPrefs.DeleteAll();
        }
    }

    void GameOver()
    {
        if (gameOver != null)
        {
            StopTime();
            gameOver.EnableGameOver();
        }
    }

}
