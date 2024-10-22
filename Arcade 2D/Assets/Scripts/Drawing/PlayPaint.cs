using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayPaint : MonoBehaviour
{
    public Button paintButton;

    void Start()
    {
        if (paintButton != null)
        {
            paintButton.onClick.AddListener(OnPaintButtonClicked);
        }
    }

    void OnPaintButtonClicked()
    {
        SceneManager.LoadScene("Drawing");
    }
}
