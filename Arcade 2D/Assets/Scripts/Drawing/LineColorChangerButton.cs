using System;
using UnityEngine;
using UnityEngine.UI;

public class LineColorChangerButton : MonoBehaviour
{
    public LineColorChangerBinary colorChangerBinary; 
    public Button[] colorButtons;
    public Color[] buttonColorsBinary;

    void Start()
    {
        // Add a listener for each button to change the color based on the button's color when clicked
        for (int i = 0; i < colorButtons.Length; i++)
        {
            int index = i;
            colorButtons[i].onClick.AddListener(() => ChangeColorWithInputFields(index));
        }
    }

    void ChangeColorWithInputFields(int index)
    {
        // Get the red, green, and blue components from the Color object
        Color color = buttonColorsBinary[index];
        int red255 = Mathf.RoundToInt(color.r * 255);
        int green255 = Mathf.RoundToInt(color.g * 255);
        int blue255 = Mathf.RoundToInt(color.b * 255);

        // Convert them to binary strings
        string redBinary = Convert.ToString(red255, 2).PadLeft(8, '0');
        string greenBinary = Convert.ToString(green255, 2).PadLeft(8, '0');
        string blueBinary = Convert.ToString(blue255, 2).PadLeft(8, '0');

        // Set the InputField values in LineColorChangerBinary script
        colorChangerBinary.SetInputFields(redBinary, greenBinary, blueBinary);

    }
}
