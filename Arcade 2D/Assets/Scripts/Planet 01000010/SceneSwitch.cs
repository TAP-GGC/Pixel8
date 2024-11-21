using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public static SceneSwitch instance;

    //Allows us to access this class anywhere and all the methods
    private void Awake()
    {
        instance = this;
    }

    public enum Scene
    {
        PlanetTitle,
        PlanetMain,
        GameOver
    }
    public void LoadScene(Scene scene)
    {
        SceneManager.LoadScene(scene.ToString());
    }

    public void LoadNewGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadTitle()
    {
        SceneManager.LoadScene(Scene.PlanetTitle.ToString());
    }

    public void LoadGameOver()
    {
        SceneManager.LoadScene(Scene.GameOver.ToString());
    }

    public void ExitButton()
    {
        SceneManager.LoadSceneAsync(3);
    }

    public void PlayButton()
    {
        SceneManager.LoadSceneAsync(8);
    }

    public void StartButton() 
    {
        SceneManager.LoadSceneAsync(9);
    }
}
