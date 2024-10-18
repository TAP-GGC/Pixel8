using UnityEngine;
using System.Collections.Generic;

public class DrawLine : MonoBehaviour
{
    private List<Vector3> points = new List<Vector3>();
    private LineRenderer currentLineRenderer;
    private List<GameObject> drawnLines = new List<GameObject>();
    private LineColorChangerBinary colorChanger;
    private int lineOrder = 0; 
    void Start()
    {
        colorChanger = GameObject.Find("Pencil").GetComponent<LineColorChangerBinary>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // On left-click or touch
        {
            CreateNewLine();
        }

        if (Input.GetMouseButton(0)) // While holding left-click or touch
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0; // Keep the line on the 2D plane
            AddPoint(mousePos);
        }
    }

    void CreateNewLine()
    {
        // Create a new GameObject to hold the LineRenderer
        GameObject newLine = new GameObject("Line");
        currentLineRenderer = newLine.AddComponent<LineRenderer>();

        // Set the material to Default-Line
        currentLineRenderer.material = new Material(Shader.Find("Sprites/Default"))
        {
            color = colorChanger.GetLineColor() // Set the line color
        };

        currentLineRenderer.widthMultiplier = 0.2f;
        currentLineRenderer.positionCount = 0;

        // Set the sorting order to make sure new lines appear on top
        currentLineRenderer.sortingOrder = lineOrder;
        lineOrder++; // Increment the order for the next line

        drawnLines.Add(newLine); // Add the new line to the list

        // Clear the points list for the new line
        points.Clear();
    }

    void AddPoint(Vector3 point)
    {
        if (points.Count == 0 || Vector3.Distance(points[points.Count - 1], point) > 0.1f)
        {
            points.Add(point);
            currentLineRenderer.positionCount = points.Count;
            currentLineRenderer.SetPosition(points.Count - 1, point);
        }
    }

    public void RemoveLastTwoLines()
    {
        for (int i = 0; i < 2; i++)
        {
            if (drawnLines.Count > 0)
            {
                GameObject lastLine = drawnLines[drawnLines.Count - 1];
                Destroy(lastLine); 
                drawnLines.RemoveAt(drawnLines.Count - 1); // Remove the last line from the list
                lineOrder--; 
            }
        }
    }

    // Method to get the number of drawn lines
    public int GetDrawnLinesCount()
    {
        return drawnLines.Count;
    }

    // Method to clear all lines (optional for future use)
    public void ClearAllLines()
    {
        foreach (GameObject line in drawnLines)
        {
            Destroy(line); // Destroy each line GameObject
        }
        drawnLines.Clear(); // Clear the list after destroying all lines
        lineOrder = 0; // Reset the line order
    }
}
