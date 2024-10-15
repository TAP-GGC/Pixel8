using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MazeButtons : MonoBehaviour
{
    public Enabled_Disabled hint;
    public Enabled_Disabled map;
    public Timer timer;
    private bool isHintActive = false; // Boolean to track the state
    private bool isMapActive = false;

    void Start()
    {
        hint = GameObject.FindGameObjectWithTag("Hint").GetComponent<Enabled_Disabled>();
        if (hint != null)
        {
            hint.DisableHint();
        }
        timer = GameObject.FindObjectOfType<Timer>();

        map = GameObject.FindGameObjectWithTag("map").GetComponent<Enabled_Disabled>();
        if (map != null)
        {
           map.DisableMiniMap();
        }
    }

    public void exitBinaryMaze()
    {
        // will make Binary exit button transition to the main menu
        SceneManager.LoadSceneAsync(0);
    }

    public void levelCompleted()
    {
        if(SceneManager.GetActiveScene().buildIndex == 2)
        {
            SceneManager.LoadSceneAsync(7);
        }

        if (SceneManager.GetActiveScene().buildIndex == 7)
        {
            SceneManager.LoadSceneAsync(0);
        }
    }

    public void levelFailed()
    {
        SceneManager.LoadSceneAsync(0);
    }

    public void ToggleHint()
    {
        isHintActive = !isHintActive; // Toggle the state
   
        if (isHintActive)
        {
            if (timer != null)
            {
                timer.StopTime();
            }
            hint.EnableHint(); // Enable hint
        }
        else
        {
            if (timer != null)
            {
                timer.StartTime();
            }
            hint.DisableHint(); // Disable hint
        }
    }

    public void ToggleMap()
    {
        isMapActive = !isMapActive;
        if (isMapActive)
        {
            map.EnableMiniMap();
        }
        else
        {
            map.DisableMiniMap();
        }
    }
}
