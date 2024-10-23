using UnityEngine;
using UnityEngine.UI;

public class RemoveLastLine : MonoBehaviour
{
    public DrawLine drawLine;
    public Button undoButton;

    void Start()
    {
        // Find the DrawLine component if it's not assigned in the Inspector
        if (drawLine == null)
        {
            drawLine = GetComponent<DrawLine>();
        }

        // Add the listener for the Undo button
        undoButton.onClick.AddListener(RemoveLast);
    }

    // Method to remove the last two drawn lines
    public void RemoveLast()
    {
        if (drawLine != null)
        {
            drawLine.RemoveLastTwoLines();
        }
    }
}
