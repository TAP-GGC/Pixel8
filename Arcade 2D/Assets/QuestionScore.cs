using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionScore : MonoBehaviour
{
    [SerializeField]
    private int answerScore;

    private ScoreCount scoreCount;

    private void Awake()
    {
        //answerScore = FindObjectOfType<ScoreCount>();
        scoreCount = FindObjectOfType<ScoreCount>();

        if(scoreCount == null)
        {
            Debug.LogError("ScoreCount component not found");
        }
    }

    public void AllocateScore()
    {
        if (scoreCount != null)
        {
            scoreCount.addScore(answerScore);
        }
    }
}
