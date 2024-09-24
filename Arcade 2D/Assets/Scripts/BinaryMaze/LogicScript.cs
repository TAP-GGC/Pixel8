using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogicScript : MonoBehaviour
{
    public int playerScore; // the number that will be increase for the score
    public Text scoreText; // The text legacy that display the score

    [ContextMenu("Increase Score")]

    // will display the score increase within the game
    public void addScore()
    {
        playerScore++;
        scoreText.text = "Questions: " + playerScore.ToString() + " / 8";
    }
}
