using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TotalGameTime : MonoBehaviour
{
    public Text level;
    public Text gameTime;
    public Timer finalTimeInventory;

    //public List<string> playerTime = new List<string>();
    //public List<float> playerSeconds = new List<float>();




    // Start is called before the first frame update
    void Start()
    {
        int countLevel = 1;
        float totalTime = 0;
        //playerTime.Add(PlayerPrefs.GetString("Time1Text"));
        //playerSeconds.Add(PlayerPrefs.GetFloat("Time1"));

        
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

            TimeSpan total = TimeSpan.FromSeconds(totalTime);
            gameTime.text = "Final Time: " + total.ToString(@"mm\:ss");
        }
        else
        {
            Debug.Log("Inventory is empty.");
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void finalScore()
    {
        if (finalTimeInventory != null)
        {
            if (SceneManager.GetActiveScene().buildIndex == 9)
            {
                SceneManager.LoadSceneAsync(0);
            }
        }
    }
}
