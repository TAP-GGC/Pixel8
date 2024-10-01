using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enabled_Disabled : MonoBehaviour
{
    public GameObject questionPanel;
    
    public void OnDisable()
    {
        this.questionPanel.SetActive(false);
    }

    public void OnEnable()
    {
        this.questionPanel.SetActive(true);
    }
}
