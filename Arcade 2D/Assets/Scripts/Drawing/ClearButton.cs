using UnityEngine;
using UnityEngine.UI;

public class ClearButton : MonoBehaviour
{
    private DrawLine drawLine;
    private Button clearButton;

    void Start()
    {
        
        drawLine = GetComponent<DrawLine>();
        
        // Find the Clear button and add the listener
        clearButton = GameObject.Find("Clear").GetComponent<Button>();
        clearButton.onClick.AddListener(ClearLines);
    }

    void ClearLines()
    {
        drawLine.ClearAllLines();
    }
}
