using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogicScript : MonoBehaviour
{
    public int playerScore; // the number that will be increase for the score
    public Text scoreText; // The text legacy that display the score
    public Timer timer;
    public MazeButtons buttons;
    public Enabled_Disabled completeLevel;

    [ContextMenu("Increase Score")]

    // Start is called before the first frame update
    void Start()
    {
        completeLevel = GameObject.FindGameObjectWithTag("LevelComplete").GetComponent<Enabled_Disabled>();
        if (completeLevel != null)
        {
            completeLevel.DisableLevelComplete();
        }
    }

    // will display the score increase within the game
    public void addScore()
    {
        playerScore++;
        scoreText.text = "Questions: " + playerScore.ToString() + " / 10";
        winGame(playerScore);
    }

    public void winGame(int playerScore)
    {
        if(playerScore == 10)
        {
            if (completeLevel != null)
            {
                completeLevel.EnableLevelComplete();
            }

            if (timer != null)
            {
                timer.StopTime();
            }

            if (buttons != null)
            {
                buttons.levelCompleted();
            }
        }
    }
}
