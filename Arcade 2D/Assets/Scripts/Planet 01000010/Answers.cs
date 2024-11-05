using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Answers : MonoBehaviour
{
    public bool isCorrect = false;
    public QuizManager quizManager;

    public GameObject correctText;
    public GameObject wrongText;

    public Game game;
    public void Start()
    {
        correctText.SetActive(false);
        wrongText.SetActive(false);
    }
    public void Answer()
    {
        if (Dice.whosTurn == 1)
        {
            if (isCorrect)
            {
                Debug.Log("Correct Answer");
                StartCoroutine(DisplayC_TextAfterDelay(.2f));
                Game.MovePlayer(1);
                StartCoroutine(RemoveC_TextAfterDelay(2f));
                quizManager.Correct();
            }
            else
            {
                Debug.Log("Wrong Answer");
                StartCoroutine(DisplayW_TextAfterDelay(.2f));
                StartCoroutine(RemoveW_TextAfterDelay(2f));
                game.player1MoveText.gameObject.SetActive(false);
                game.npcMoveText.gameObject.SetActive(true);
                quizManager.Wrong();
            }
            Dice.whosTurn *= -1;
            Dice.coroutineAllowed = true;
        }
    }

    private IEnumerator RemoveC_TextAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        correctText.SetActive(false);
    }
    private IEnumerator DisplayC_TextAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        correctText.SetActive(true);
    }
    private IEnumerator RemoveW_TextAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        wrongText.SetActive(false);
    }
    private IEnumerator DisplayW_TextAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        wrongText.SetActive(true);
    }
}