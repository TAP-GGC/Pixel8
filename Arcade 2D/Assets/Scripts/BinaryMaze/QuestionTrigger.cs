using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // Import legacy UI namespace

public class QuestionTrigger : MonoBehaviour
{
    public Text questionText;          // Legacy UI Text for displaying the question
    public InputField answerInput;     // Legacy UI InputField for entering the answer
    public Button submitButton;        // Legacy UI Button to submit the answer
    public Text feedbackText;          // Legacy UI Text for feedback
    public string question = "What is 50 in binary?";  // The question to display
    public string correctAnswer = "110010";            // Correct answer for the question

    private bool playerInTrigger = false;  // Track if the player is in the trigger area

    public LogicScript logic; // The script that display the score

    public Enabled_Disabled panel;

    private void Start()
    {
        // Initially hide the question and feedback
        questionText.text = "";
        feedbackText.text = "";
        submitButton.onClick.AddListener(CheckAnswer);  // Add listener to submit button
        // will find the prefab that has logic script attach to it.
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        panel = GameObject.FindGameObjectWithTag("QuestionPanel").GetComponent<Enabled_Disabled>();
        if(panel != null)
        {
          panel.enabled = false;
        }
    }

    private void Update()
    {
        // Check for Enter key press in the Update method (continuously checks every frame)
        if (Input.GetKeyUp(KeyCode.KeypadEnter) || Input.GetKeyUp(KeyCode.Return))
        {
            CheckAnswer();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            questionText.text = question;  // Show the question
            feedbackText.text = "";        // Clear previous feedback
            playerInTrigger = true;
            panel.OnEnable();
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
            panel.OnDisable();
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
