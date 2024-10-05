using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    bool stopWatchActive = false;
    public static float currentTime;
    public Text currentTimeText;
    public Text levelTime;
    //public float levelTime;

    
    // Start is called before the first frame update
    void Start()
    {
        stopWatchActive = true;
        currentTime = 0;
        //Time.timeScale = 1;
        Invoke("GameOver", 60);
    }

    
    // Update is called once per frame
    void Update()
    {
        if (stopWatchActive == true)
        {
            currentTime = currentTime + Time.deltaTime; // adding real time in seconds from fames
        }
        TimeSpan time = TimeSpan.FromSeconds(currentTime); // converts to hours, minutes, and seconds
        currentTimeText.text = time.ToString(@"mm\:ss");
        saveTimeData(currentTimeText);
        //Invoke("GameOver", 60);
    }

    public void StopTime()
    {
        stopWatchActive = false;
    }

    public void saveTimeData(Text current)
    {
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            PlayerPrefs.SetFloat("Time1", currentTime);
            PlayerPrefs.SetString("Time1Text", current.text);
            loadTimeData();
        }
    }

    public void loadTimeData()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            if (stopWatchActive == false)
            {
                levelTime.text = "Time: " + PlayerPrefs.GetString("Time1Text");
            }
        }
    }

    void GameOver()
    {
        // will make Binary exit button transition to the main menu
        SceneManager.LoadSceneAsync(0);
    }

}
