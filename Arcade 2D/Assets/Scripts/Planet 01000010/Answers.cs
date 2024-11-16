using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Answers : MonoBehaviour
{
    public bool isCorrect = false;
    public QuizManager quizManager;

    public GameObject correctText;
    public GameObject wrongText;

    public static Button choice1;
    public static Button choice2;
    public static Button choice3;
    public static Button choice4;

    public Game game;
    public void Start()
    {
        isCorrect = false;
        correctText.SetActive(false);
        wrongText.SetActive(false);
        choice1 = GameObject.Find("Choice1").GetComponent<Button>();
        choice2 = GameObject.Find("Choice2").GetComponent<Button>();
        choice3 = GameObject.Find("Choice3").GetComponent<Button>();
        choice4 = GameObject.Find("Choice4").GetComponent<Button>();

        choice1.interactable = false;
        choice2.interactable = false;
        choice3.interactable = false;
        choice4.interactable = false;
    }
    public void Answer()
    {
        if (Dice.whosTurn == 1)
        {
            if (isCorrect)
            {
                Debug.Log("Correct Answer");
                Answers.choice1.interactable = false;
                Answers.choice2.interactable = false;
                Answers.choice3.interactable = false;
                Answers.choice4.interactable = false;
                StartCoroutine(DisplayC_TextAfterDelay(.2f));
                Game.MovePlayer(1);
                StartCoroutine(RemoveC_TextAfterDelay(2f));
                quizManager.Correct();
            }
            else
            {
                Debug.Log("Wrong Answer");
                Answers.choice1.interactable = false;
                Answers.choice2.interactable = false;
                Answers.choice3.interactable = false;
                Answers.choice4.interactable = false;
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