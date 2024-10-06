using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enabled_Disabled : MonoBehaviour
{
    public GameObject questionPanel;
    public GameObject levelCompleteScreen;

   
    public void OnDisable()
    {
        if (this.questionPanel != null) 
        {
            this.questionPanel.SetActive(false);
        }
    }

    public void OnEnable()
    {
        if (this.questionPanel != null)
        {
            this.questionPanel.SetActive(true);
        }
    }

    public void EnableLevelComplete()
    {
        if (this.levelCompleteScreen != null)
        {
            this.levelCompleteScreen.SetActive(true);
        }
    }

    public void DisableLevelComplete()
    {
        if (this.levelCompleteScreen != null)
        {
            this.levelCompleteScreen.SetActive(false);
        }
    }

    /*
    public void IsLevelActive(int playerScore)
    {
        if (playerScore == 2)
        {
            levelCompleteScreen.SetActive(true);
        }
        else
        {
            levelCompleteScreen.SetActive(false);
        }

    }
    */
   
}
