using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MazeButtons : MonoBehaviour
{
    public Enabled_Disabled hint;
    public Timer timer;
    private bool isHintActive = false; // Boolean to track the state

    void Start()
    {
        hint = GameObject.FindGameObjectWithTag("Hint").GetComponent<Enabled_Disabled>();
        if (hint != null)
        {
            hint.DisableHint();
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
            SceneManager.LoadSceneAsync(1);
        }
    }

    public void levelFailed()
    {
        SceneManager.LoadSceneAsync(0);
    }

    public void HintOn()
    {
        if (hint != null)
        {
            hint.EnableHint();
        }
    }

    public void HintOff()
    {
        if (hint != null)
        {
            hint.DisableHint();
        }
    }

    public void ToggleHint()
    {
        isHintActive = !isHintActive; // Toggle the state

        if (isHintActive)
        {
            hint.EnableHint(); // Enable hint
        }
        else
        {
            hint.DisableHint(); // Disable hint
        }
    }
}
