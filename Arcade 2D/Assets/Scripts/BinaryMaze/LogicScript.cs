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
    //public Text levelTime;

    [ContextMenu("Increase Score")]

    void Awake()
    {
        transform.parent = null;
        DontDestroyOnLoad(gameObject);
    }

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
        scoreText.text = "Questions: " + playerScore.ToString() + " / 8";
        winGame(playerScore);
    }

    public void winGame(int playerScore)
    {
        if(playerScore == 1)
        {
            //DontDestroyOnLoad(gameObject);
            //completeLevel.IsLevelActive(playerScore);
            if (completeLevel != null)
            {
                completeLevel.EnableLevelComplete();
            }

            if (timer != null)
            {
                //timer.StopTime();
                //timer.loadTimeData();
                timer.StopTime();
            }

            if (buttons != null)
            {
                buttons.levelCompleted();
            }
            // will go to a screen that will say level complete
            // and there will be a continue button that will let them go to the next level.
        }
    }
}
