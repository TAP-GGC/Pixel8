using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
    public List<QuestionsAndAnswers> QnA;
    public GameObject[] options;
    public int currentQuestion; 

    public TextMeshProUGUI QuestionText;
    public TextMeshProUGUI ScoreText;

    public GameObject QuizPanel;
    public GameObject GameOverPanel;

    public int totalQuestion = 0;
    public int score = 0;
    private int wrongScore = 0;

    private void Start()
    {
        score = 0;
        totalQuestion = QnA.Count;
        QuizPanel.SetActive(true);
        GameOverPanel.SetActive(false);
        GenerateQuestion();
    }

    public void Exit()
    {
        SceneManager.LoadSceneAsync(3);
    }
    
    public void GameOver()
    {
        QuizPanel.SetActive(false);
        GameOverPanel.SetActive(true);
        ScoreText.text = "Score: " + score + "/" + (score + wrongScore);
    }
    
    public void Correct() 
    {
        score++;
        //Move Player
        //Make button go green 
        QnA.RemoveAt(currentQuestion);
        GenerateQuestion();
    }

    public void Wrong()
    {
        wrongScore++;
        //Don't move player
        //Make button go red
        QnA.RemoveAt(currentQuestion);
        GenerateQuestion();
    }
    
    public void SetAnswer()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<Answers>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = QnA[currentQuestion].answers[i];

            if (QnA[currentQuestion].correctAnswer == i + 1)
            {
                options[i].GetComponent<Answers>().isCorrect = true;
            }
        }
    }

    public void GenerateQuestion()
    {
        if (QnA.Count > 0)
        {
            currentQuestion = Random.Range(0, QnA.Count);

            QuestionText.text = QnA[currentQuestion].question;
            SetAnswer();
        }
        else
        {
            Debug.Log("Out of Questions");
            GameOver();
        }
    }
}