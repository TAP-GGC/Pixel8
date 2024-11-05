using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    public void exitPaint()
    {
        // will make Binary exit button transition to the main menu
        SceneManager.LoadSceneAsync(3);
    }
}
