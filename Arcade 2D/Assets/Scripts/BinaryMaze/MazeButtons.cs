using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MazeButtons : MonoBehaviour
{
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
}
