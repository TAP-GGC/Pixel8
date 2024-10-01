using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    //bool stopWatchActive = false;
    float currentTime;
    public Text currentTimeText;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = 0;
    }

    
    // Update is called once per frame
    void Update()
    {
        currentTime = currentTime + Time.deltaTime;
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        currentTimeText.text = time.ToString(@"mm\:ss");
        /*
        if (currentTimeText.text.Equals("00:30")){
            Invoke("GameOver", 30);
        }
        */

        Invoke("GameOver", 30);
    }

    void GameOver()
    {
        // will make Binary exit button transition to the main menu
        SceneManager.LoadSceneAsync(0);
    }

}
