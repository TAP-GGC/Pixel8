using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    private static bool hasPlayedBinary = false; // Static to persist across scenes
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

    public void PlayPaint()
    {
        if (hasPlayedBinary)
        {
            SceneManager.LoadSceneAsync(3);
        }
        else
        {
            if (warningText != null)
            {
                warningText.text = "You must play another game first.";
            }
        }
    }
}
