using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    private static bool hasPlayedBinary = false; // Static to persist across scenes
    private static bool hasPlayedPlanet = false;
    public Text warningText;

    void Start()
    {
        DontDestroyOnLoad(gameObject);

        if (warningText != null)
        {
            warningText.text = "";
        }
    }

    public void PlayBinary()
    {
        hasPlayedBinary = true;

        if (warningText != null)
        {
            warningText.text = "";
        }

        SceneManager.LoadSceneAsync(1);
    }
    public void PlayPlanet()
    {
        hasPlayedPlanet = true;

        if (warningText != null)
        {
            warningText.text = "";
        }

        SceneManager.LoadSceneAsync(4);
    }

    public void PlayPaint()
    {
        if (hasPlayedBinary || hasPlayedPlanet)
        {
            SceneManager.LoadSceneAsync("Drawing Title");
        }
        else if (warningText != null)
        {
            warningText.text = "You must play Binary Maze or Planet 01000010 first.";
        }
       
    }
}
