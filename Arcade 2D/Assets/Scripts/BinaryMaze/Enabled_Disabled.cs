using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enabled_Disabled : MonoBehaviour
{
    public GameObject questionPanel;
    public GameObject levelCompleteScreen;
    public GameObject gameLimit;
    public GameObject gameHint;
    public GameObject miniMap;

   
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

    public void EnableGameOver()
    {
        if(this.gameLimit != null)
        {
            this.gameLimit.SetActive(true);
        }
    }

    public void DisableGameOver()
    {
        if(this.gameLimit != null)
        {
            this.gameLimit.SetActive(false);
        }
    }

    public void EnableHint()
    {
        if (this.gameHint != null)
        {
            this.gameHint.SetActive(true);
        }
    }

    public void DisableHint()
    {
        if (this.gameHint != null)
        {
            this.gameHint.SetActive(false);
        }
    }

    public void EnableMiniMap()
    {
        if(this.miniMap != null)
        {
            this.miniMap.SetActive(true);
        }
    }

    public void DisableMiniMap()
    {
        if(this.miniMap != null)
        {
            this.miniMap.SetActive(false);
        }
    }
   
}
