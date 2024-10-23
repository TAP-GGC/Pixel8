using UnityEngine;
using UnityEngine.UI;

public class PanelController : MonoBehaviour
{
    public GameObject instructionsPanel; 
    public GameObject descriptionPanel; 
    public Button instructionsButton; 
    public Button descriptionButton; 

    void Start()
    {
        // Set both panels to inactive at the start
        instructionsPanel.SetActive(false);
        descriptionPanel.SetActive(false);

        // Add listeners to buttons
        instructionsButton.onClick.AddListener(ToggleInstructionsPanel);
        descriptionButton.onClick.AddListener(ToggleDescriptionPanel);
    }

    void ToggleInstructionsPanel()
    {
        // Check if the instructions panel is currently active
        if (instructionsPanel.activeSelf)
        {
            // If it's active, deactivate it
            instructionsPanel.SetActive(false);
        }
        else
        {
            // If it's not active, activate it and deactivate the description panel
            instructionsPanel.SetActive(true);
            descriptionPanel.SetActive(false);
        }
    }

    void ToggleDescriptionPanel()
    {
        // Check if the description panel is currently active
        if (descriptionPanel.activeSelf)
        {
            // If it's active, deactivate it
            descriptionPanel.SetActive(false);
        }
        else
        {
            // If it's not active, activate it and deactivate the instructions panel
            descriptionPanel.SetActive(true);
            instructionsPanel.SetActive(false);
        }
    }
}
