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

        // Add listener to limit input length to 8 characters and only allow binary digits
        inputRed.onValueChanged.AddListener(delegate { ValidateBinaryInput(inputRed); });
        inputGreen.onValueChanged.AddListener(delegate { ValidateBinaryInput(inputGreen); });
        inputBlue.onValueChanged.AddListener(delegate { ValidateBinaryInput(inputBlue); });

        // Add listener to the submit button
        submitButton.onClick.AddListener(OnSubmitColor);

        colorPreviewImage.color = lineColor;
    }

    void Update()
    {
        // Check if Enter key is pressed
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            OnSubmitColor(); // Call submit when Enter is pressed
        }
    }

    void ValidateBinaryInput(InputField input)
    {
        // Keep only valid binary characters (1 and 0) and limit to 8 characters
        string validInput = "";
        foreach (char c in input.text)
        {
            if (c == '0' || c == '1')
            {
                validInput += c;
            }
        }

        // Trim the input if it's longer than 8 characters
        if (validInput.Length > 8)
        {
            validInput = validInput.Substring(0, 8);
        }

        // Update the input field with the valid filtered input
        input.text = validInput;
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
    public void SetInputFields(string redBinary, string greenBinary, string blueBinary)
{
    inputRed.text = redBinary;
    inputGreen.text = greenBinary;
    inputBlue.text = blueBinary;

    OnSubmitColor();
}
}
