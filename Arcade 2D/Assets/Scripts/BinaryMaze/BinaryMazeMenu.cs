using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BinaryMazeMenu : MonoBehaviour
{
    public void PlayMazeGame()
    {
        // will make Binary play button transition to the title card
        SceneManager.LoadSceneAsync(5);
    }
}
