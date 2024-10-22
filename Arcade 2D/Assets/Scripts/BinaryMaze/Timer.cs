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

            if (currentTime >= 600) // Example: if the timer reaches 10 mins
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
        if (SceneManager.GetActiveScene().buildIndex == 2 /*|| SceneManager.GetActiveScene().buildIndex == 7 || SceneManager.GetActiveScene().buildIndex == 8*/)
        {
            PlayerPrefs.SetFloat("Time1", currentTime);
            PlayerPrefs.SetString("Time1Text", currentTimeText.text);
            PlayerPrefs.Save();
        } 
        else if (SceneManager.GetActiveScene().buildIndex == 7)
        {
            PlayerPrefs.SetFloat("Time2", currentTime);
            PlayerPrefs.SetString("Time2Text", currentTimeText.text);
            PlayerPrefs.Save();
        } 
        else if (SceneManager.GetActiveScene().buildIndex == 8)
        {
            PlayerPrefs.SetFloat("Time3", currentTime);
            PlayerPrefs.SetString("Time3Text", currentTimeText.text);
            PlayerPrefs.Save();
        }
    }

    public void loadTimeData()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2 /*|| SceneManager.GetActiveScene().buildIndex == 7 || SceneManager.GetActiveScene().buildIndex == 8*/)
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
                StopTime();
                //currentTime = 0;
            }
            //PlayerPrefs.DeleteAll();
        } 
        else if(SceneManager.GetActiveScene().buildIndex == 7)
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
        else if (SceneManager.GetActiveScene().buildIndex == 8)
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
            if (SceneManager.GetActiveScene().buildIndex == 0)
            {
                PlayerPrefs.DeleteAll();
            }
        }
    }

    /*
    public void finalTime(List<string> levelTime, List<float> addFinalTime)
    {
        if (level == null || gameTime == null)
        {
            Debug.LogError("UI element 'level' or 'gameTime' is not assigned!");
            return; // Stop the function to prevent the null reference
        }

        if (levelTime == null || addFinalTime == null)
        {
            Debug.LogError("levelTime or addFinalTime is null!");
            return; // Stop the function
        }

        int countLevel = 1;
        float totalTime = 0;
        level.text = ""; // Clear previous text

        for (int i = 0; i < levelTime.Count; i++)
        {
            level.text += "Level " + countLevel + " Time: " + levelTime[i] + "\n";
            countLevel++; // Increment for each level
        }

        for (int i = 0; i < addFinalTime.Count; i++)
        {
            totalTime += addFinalTime[i];
        }

        TimeSpan total = TimeSpan.FromSeconds(totalTime);
        gameTime.text = "Final Time: " + total.ToString(@"mm\:ss");
    }
    */


    /*
    public void finalTime(List<string> levelTime, List<float> addFinalTime)
    {
        int countLevel = 1;
        float totalTime = 0;
        level.text = "";

        if (levelTime != null && addFinalTime != null)
        {
            for (int i = 0; i < levelTime.Count; i++)
            {
                level.text += "Level " + countLevel + " Time: " + levelTime[i] + "\n";
                countLevel++;
            }

            for (int i = 0; i < addFinalTime.Count; i++)
            {
                totalTime += addFinalTime[i];
            }
            TimeSpan total = TimeSpan.FromSeconds(totalTime);
            gameTime.text = "Final Time: " + total.ToString(@"mm\:ss");
        }
    }
    */

    void GameOver()
    {
        if (gameOver != null)
        {
            StopTime();
            gameOver.EnableGameOver();
        }
    }

}
