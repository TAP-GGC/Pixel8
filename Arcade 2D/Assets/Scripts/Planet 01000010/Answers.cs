using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Answers : MonoBehaviour
{
    public bool isCorrect = false;
    public QuizManager quizManager;
    //public static GameObject pWrongText;

    public Dice dice;
    public void Start()
    {
        //pWrongText = GameObject.Find("PlayerWrongText");
        //pWrongText.SetActive(false);
    }
    public void Answer()
    {
        if (Dice.whosTurn == 1)
        {
            if (isCorrect)
            {
                Game.MovePlayer(1);
                Debug.Log("Correct Answer");
                quizManager.Correct();
            }
            else
            {
                Debug.Log("Wrong Answer");
                //StartCoroutine(DisplayWrongTextAfterDelay(0.5f));
                //StartCoroutine(RemoveWrongTextAfterDelay(1.5f));
                Game.player1MoveText.gameObject.SetActive(false);
                Game.player2MoveText.gameObject.SetActive(true);
                quizManager.Wrong();
            }
            Dice.whosTurn *= -1;
            dice.coroutineAllowed = true;
        }
    }
    /*private IEnumerator RemoveWrongTextAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        pWrongText.SetActive(false);

    }
    private IEnumerator DisplayWrongTextAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        pWrongText.SetActive(true);

    }*/
}