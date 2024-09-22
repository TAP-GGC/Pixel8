using UnityEngine;
using UnityEngine.UI;
using System;

public class LineColorChangerBinary : MonoBehaviour
{
    private Color lineColor = Color.black; 
    private InputField inputRed;
    private InputField inputGreen;
    private InputField inputBlue;
    private Button submitButton;
    private Image colorPreviewImage;

    void Start()
    {
       
        inputRed = GameObject.Find("Red").GetComponent<InputField>();
        inputGreen = GameObject.Find("Green").GetComponent<InputField>();
        inputBlue = GameObject.Find("Blue").GetComponent<InputField>();
        submitButton = GameObject.Find("Submit").GetComponent<Button>();
        colorPreviewImage = GameObject.Find("ColorPreviewImage").GetComponent<Image>();

        // Add listener to the submit button
        submitButton.onClick.AddListener(OnSubmitColor);

        colorPreviewImage.color = lineColor;
    }

    void OnSubmitColor()
    {
        // Convert binary input to decimal values
        int red = BinaryToDecimal(inputRed.text);
        int green = BinaryToDecimal(inputGreen.text);
        int blue = BinaryToDecimal(inputBlue.text);

        // Clamp values to be within 0-255 range
        red = Mathf.Clamp(red, 0, 255);
        green = Mathf.Clamp(green, 0, 255);
        blue = Mathf.Clamp(blue, 0, 255);

        // Convert to normalized color value (0-1 range)
        lineColor = new Color(red / 255f, green / 255f, blue / 255f);

        colorPreviewImage.color = lineColor;
    }

    public Color GetLineColor()
    {
        return lineColor;
    }

    int BinaryToDecimal(string binary)
    {
        try
        {
            return Convert.ToInt32(binary, 2);
        }
        catch
        {
            Debug.LogError("Invalid binary input");
            return 0;
        }
    }
}
