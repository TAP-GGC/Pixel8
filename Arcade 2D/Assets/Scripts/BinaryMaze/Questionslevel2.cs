using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // Import legacy UI namespace

public class Questionslevel2 : MonoBehaviour
{
    public Text questionText;          // Legacy UI Text for displaying the question
    public InputField answerInput;     // Legacy UI InputField for entering the answer
    public Button submitButton;        // Legacy UI Button to submit the answer
    public Text feedbackText;          // Legacy UI Text for feedback
    public string question = "What is 13 in binary?";  // The question to display
    public string correctAnswer = "1101";            // Correct answer for the question

    private bool playerInTrigger = false;  // Track if the player is in the trigger area

    public LogicScript logic; // The script that display the score

    private void Start()
    {
        // Initially hide the question and feedback
        questionText.text = "";
        feedbackText.text = "";
        submitButton.onClick.AddListener(CheckAnswer);  // Add listener to submit button

        // will find the prefab that has logic script attach to it.
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            questionText.text = question;  // Show the question
            feedbackText.text = "";        // Clear previous feedback
            playerInTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            questionText.text = "";        // Hide the question
            feedbackText.text = "";        // Hide feedback
            answerInput.text = "";         // Clear input field
            playerInTrigger = false;
        }
    }

    // Function to check the player's answer
    public void CheckAnswer()
    {
        if (playerInTrigger)  // Only check if the player is in the trigger area
        {
            string playerAnswer = answerInput.text;  // Get the player's input
            if (playerAnswer == correctAnswer)
            {
                feedbackText.text = "Correct!";
                // Destroy the parent TriggerSquare and the BlockerSquare child
                Destroy(gameObject);  // This will destroy both the trigger and the blocking square (as it's a child)
                logic.addScore(); // will update score when answered correctly
            }
            else
            {
                feedbackText.text = "Wrong Answer!";
            }
        }
    }
}
