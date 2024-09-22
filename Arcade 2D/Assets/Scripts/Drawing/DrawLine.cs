using UnityEngine;
using System.Collections.Generic;

public class DrawLine : MonoBehaviour
{
    private List<Vector3> points = new List<Vector3>();
    private LineRenderer currentLineRenderer;
    private List<GameObject> drawnLines = new List<GameObject>();
    private LineColorChangerBinary colorChanger;


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
            color = colorChanger.GetLineColor() // You can set the line color here
        };

        
        currentLineRenderer.widthMultiplier = 0.2f;
        currentLineRenderer.positionCount = 0;

        drawnLines.Add(newLine);

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
    public void ClearAllLines()
    {
        foreach (GameObject line in drawnLines)
        {
            Destroy(line); // Destroy each line GameObject
        }
        drawnLines.Clear(); // Clear the list after destroying all lines
    }
}
