using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TotalGameTime : MonoBehaviour
{
    public Text level;
    public Text gameTime;
    public Timer finalTimeInventory;

    public List<string> playerTime = new List<string>();
    public List<float> playerSeconds = new List<float>();

    void Start()
    {
        int countLevel = 1;
        float totalTime = 0;
        level.text = "";  // Reset level text at the start

        // Initialize lists if not already
        if (playerTime == null) playerTime = new List<string>();
        if (playerSeconds == null) playerSeconds = new List<float>();

        // Add PlayerPrefs data to lists with key checks
        if (PlayerPrefs.HasKey("Time1Text"))
        {
            playerTime.Add(PlayerPrefs.GetString("Time1Text"));
            playerSeconds.Add(PlayerPrefs.GetFloat("Time1"));
        }
        else
        {
            Debug.Log("Missing Time1Text or Time1 in PlayerPrefs");
        }

        if (PlayerPrefs.HasKey("Time2Text"))
        {
            playerTime.Add(PlayerPrefs.GetString("Time2Text"));
            playerSeconds.Add(PlayerPrefs.GetFloat("Time2"));
        }
        else
        {
            Debug.Log("Missing Time2Text or Time2 in PlayerPrefs");
        }

        if (PlayerPrefs.HasKey("Time3Text"))
        {
            playerTime.Add(PlayerPrefs.GetString("Time3Text"));
            playerSeconds.Add(PlayerPrefs.GetFloat("Time3"));
        }
        else
        {
            Debug.Log("Missing Time3Text or Time3 in PlayerPrefs");
        }

        // Use StringBuilder for more efficient string concatenation
        StringBuilder sb = new StringBuilder();
        foreach (string levelTime in playerTime)
        {
            sb.AppendLine("Level " + countLevel + ": " + levelTime);
            countLevel++;
        }
        level.text = sb.ToString();  // Set the combined text

        // Sum up the total time
        foreach (float addFinalTime in playerSeconds)
        {
            totalTime += addFinalTime;
        }

        // Display the total game time
        TimeSpan total = TimeSpan.FromSeconds(totalTime);
        gameTime.text = "Final Time: " + total.ToString(@"mm\:ss");
    }

    /*

    // Start is called before the first frame update
    void Start()
    {
        int countLevel = 1;
        float totalTime = 0;
        level.text = "";
        //level.text = "Time: " + PlayerPrefs.GetString("Time1Text");
        //TimeSpan total = TimeSpan.FromSeconds(PlayerPrefs.GetFloat("Time1"));
        //gameTime.text = "Final Time: " + total.ToString(@"mm\:ss");



        playerTime.Add(PlayerPrefs.GetString("Time1Text"));
        playerSeconds.Add(PlayerPrefs.GetFloat("Time1"));

        playerTime.Add(PlayerPrefs.GetString("Time2Text"));
        playerSeconds.Add(PlayerPrefs.GetFloat("Time2"));

        playerTime.Add(PlayerPrefs.GetString("Time3Text"));
        playerSeconds.Add(PlayerPrefs.GetFloat("Time3"));

        foreach (string levelTime in playerTime)
        {
            Debug.Log("Time: " + levelTime + "\n");
            level.text += "Level " + countLevel + " Time: " + levelTime + "\n";
            countLevel++;
        }

        foreach (float addFinalTime in playerSeconds)
        {
            totalTime += addFinalTime;
        }
        TimeSpan total = TimeSpan.FromSeconds(PlayerPrefs.GetFloat("Time1") + PlayerPrefs.GetFloat("Time2") + PlayerPrefs.GetFloat("Time3"));
        gameTime.text = "Final Time: " + total.ToString(@"mm\:ss");

        if (finalTimeInventory != null)
        {
            foreach (string levelTime in finalTimeInventory.playerTime)
            {
                Debug.Log("Time: " + levelTime + "\n");
                level.text += "Level " + countLevel + " Time: " + levelTime + "\n";
            }

            foreach (float addFinalTime in finalTimeInventory.playerSeconds)
            {
                totalTime += addFinalTime;
            }

            //TimeSpan total = TimeSpan.FromSeconds(totalTime);
            //gameTime.text = "Final Time: " + total.ToString(@"mm\:ss");
        }
        else
        {
            Debug.Log("Inventory is empty.");
        }

    }
    */

    // Update is called once per frame
    void Update()
    {
        
    }

    public void finalScore()
    {
        if (SceneManager.GetActiveScene().buildIndex == 10)
        {
            SceneManager.LoadSceneAsync(3);
        }
    }
}
