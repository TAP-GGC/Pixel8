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
    public Button submitButton;

    private Dictionary<string, string> quizQuestions; 
    private List<string> questionKeys;
    private int currentQuestionIndex = 0; 

    void Start()
    {
        
        quizQuestions = new Dictionary<string, string>
        {
            { "What is 2^3?", "8" },
            { "What is 1101", "13" },
            { "What is 50 in binary?", "110010" }
        };

        questionKeys = new List<string>(quizQuestions.Keys);

        
        ShowNextQuestion();

        submitButton.onClick.AddListener(CheckAnswer);
    }

    void ShowNextQuestion()
    {
        
        wrongText.text = "";


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
            wrongText.text = "Incorrect, try again!";
        }
    }

    public void exitTutorial()
    {
        if(currentQuestionIndex == questionKeys.Count)
        {
            // will make Binary exit button transition to the main menu
            SceneManager.LoadSceneAsync(3);
        }
    }
}
