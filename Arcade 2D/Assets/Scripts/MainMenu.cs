using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayBinary()
    {
        // will make Binary play button transition to the title card
        SceneManager.LoadSceneAsync(1);
    }
}
