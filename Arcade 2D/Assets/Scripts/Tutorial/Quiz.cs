using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    public Text questionText;       
    public InputField answerInput;  
    public Text wrongText; 
    public Text hintText;          
    public Button submitButton;

    private Dictionary<string, string> quizQuestions; 
    private Dictionary<string, List<string>> hints;  
    private List<string> questionKeys;
    private int currentQuestionIndex = 0; 
    private int incorrectAttempts = 0;
    private const int hintsThreshold = 1;  // Number of incorrect attempts before showing hints

    void Start()
    {
        // Initialize questions and answers
        quizQuestions = new Dictionary<string, string>
        {
            { "What is 2^3?", "8" },
            { "What is 1101 in decimal?", "13" },
            { "What is 50 in binary? (using 8 bits)", "00110010" }
        };

        // Initialize hints for each question
        hints = new Dictionary<string, List<string>>
        {
            { "What is 2^3?", new List<string> { "Remember: 2^3 is the same as 2 * 2 * 2.", 
            "The result is a single-digit number.", "2 * 2 * 2", "Answer = 8"} },

            { "What is 1101 in decimal?", new List<string> { "Binary position values: 8, 4, 2, 1.",
             "Add the values of each '1' bit in 1101 based on position.", "8+4+0+1", "Answer = 13"} },

            { "What is 50 in binary? (using 8 bits)", new List<string> { 
                "Subtract 50 by the highest power of 2^x without going over then repeat till 0",
                 "50 - 32 = 18", "18 - 16 = 2", "2 - 2 = 0", "Fill in 1 in the corresponding 2^x you used",
                  "50 - 32 = 18 | 18 - 16 = 2 | 2 - 2 = 0 \n 110010", "Answer = 00110010"} }
        };

        questionKeys = new List<string>(quizQuestions.Keys);

        ShowNextQuestion();

        submitButton.onClick.AddListener(CheckAnswer);
    }

    void Update()
    {
        // Check if the Enter key is pressed and the input field is focused
        if (Input.GetKeyDown(KeyCode.Return))
        {
            CheckAnswer();
        }
    }

    void ShowNextQuestion()
    {
        wrongText.text = "";
        hintText.text = "";
        incorrectAttempts = 0;  // Reset incorrect attempts for the new question

        if (currentQuestionIndex < questionKeys.Count)
        {
            string currentQuestion = questionKeys[currentQuestionIndex];
            questionText.text = currentQuestion;
            answerInput.text = ""; 
        }
        else
        {
            questionText.text = "You've completed the quiz!";
            submitButton.interactable = false;
        }
    }

    void CheckAnswer()
    {
        string currentQuestion = questionKeys[currentQuestionIndex];
        string correctAnswer = quizQuestions[currentQuestion];

        if (answerInput.text == correctAnswer)
        {
            currentQuestionIndex++;
            ShowNextQuestion();
        }
        else
        {
            incorrectAttempts++;
            DisplayHintOrErrorMessage(currentQuestion);
        }
    }

    void DisplayHintOrErrorMessage(string question)
    {
        // Check if hints are available and if the user hasn't reached the last hint
        if (incorrectAttempts >= hintsThreshold && hints.ContainsKey(question))
        {
            int hintIndex = incorrectAttempts - hintsThreshold;

            // If the hint index is within bounds, display the corresponding hint
            if (hintIndex < hints[question].Count)
            {
                hintText.text = "Hint: " + hints[question][hintIndex];
                wrongText.text = "Incorrect";
            }
            else
            {
                // If the hint index exceeds the available hints, keep displaying the last hint
                hintText.text = "Hint: " + hints[question][hints[question].Count - 1];
                wrongText.text = "Incorrect";
            }
        }
        else
        {
            wrongText.text = "Incorrect, try again!";
        }
    }

    public void exitTutorial()
    {
        if (currentQuestionIndex == questionKeys.Count)
        {
            SceneManager.LoadSceneAsync(3);
        }
    }
}


