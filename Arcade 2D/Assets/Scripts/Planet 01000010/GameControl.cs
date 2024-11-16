using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    //Reference to UI game objects
    public GameObject winText;
    string winner;
    [SerializeField] public GameObject player1MoveText;
    [SerializeField] public GameObject npcMoveText;

    //Reference to player objects
    private static GameObject player1, player2;

    //Holds current number of move distance
    public static int diceSideThrown = 0;

    //Start waypoints to determine where each player starts
    public static int player1StartWaypoint = 0;
    public static int player2StartWaypoint = 0;

    //Game over indicator
    public static bool gameOver = false;

    public GameObject instructions;
    public bool instructionsOn = false;

    public QuizManager quiz;

    // Start is called before the first frame update
    void Start() { 
        //Finds the UI elements so we can control them
        winText.GetComponent<TextMeshProUGUI>().SetText(" ");
        //player1MoveText = GameObject.Find("Player1MoveText");
        //npcMoveText = GameObject.Find("NPCMoveText");

        player1 = GameObject.Find("Player1");
        player2 = GameObject.Find("NPC");

        //instructions = GameObject.Find("Instructions");

        //Finds the player objects so they can be controlled
        //Disables movements of players
        player1.GetComponent<FollowPath>().moveAllowed = false;
        player2.GetComponent<FollowPath>().moveAllowed = false;

        //Win text off
        //if (winText != null)
        //{
         //   winText.SetActive(false);
       // }
        //Player 1 move text on so they know it's their turn
        if (player1MoveText != null)
        {
            player1MoveText.SetActive(true);
        }
        //Player 2 move text off
        if (npcMoveText != null)
        {
            npcMoveText.SetActive(false);
        }
        if (instructions != null)
        {
            instructions.SetActive(false);
        }
        if (winText != null)
        {
            winText.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //If the player has moved the number of spaces rolled, stop them from moving
        if (player1.GetComponent<FollowPath>().waypointIndex >
            player1StartWaypoint + diceSideThrown)
        {
            player1.GetComponent<FollowPath>().moveAllowed = false;
            player1MoveText.gameObject.SetActive(false);
            npcMoveText.gameObject.SetActive(true);
            player1StartWaypoint = player1.GetComponent<FollowPath>().waypointIndex - 1;
        }

        //If the NPC has moved the number of spaces rolled, stop them from moving
        if (player2.GetComponent<FollowPath>().waypointIndex >
            player2StartWaypoint + diceSideThrown)
        {
            player2.GetComponent<FollowPath>().moveAllowed = false;
            npcMoveText.gameObject.SetActive(false);
            player1MoveText.gameObject.SetActive(true);
            player2StartWaypoint = player2.GetComponent<FollowPath>().waypointIndex - 1;
        }

        //If the player has reached the end of the path, display the win text
        if (player1.GetComponent<FollowPath>().waypointIndex ==
            player1.GetComponent<FollowPath>().waypoints.Length)
        {
            winner = "Player 1 Wins!!";
            winText.GetComponent<TextMeshProUGUI>().SetText(winner);
            winText.SetActive(true);
            //player1MoveText.SetActive(false);
            //npcMoveText.SetActive(false);
            gameOver = true;
            if (quiz != null)
            {
                quiz.GameOver();
            }
        }

        //If the NPC has reached the end of the path, display the win text
        if (player2.GetComponent<FollowPath>().waypointIndex ==
            player2.GetComponent<FollowPath>().waypoints.Length)
        {
            winner = "NPC Wins!!";
            winText.GetComponent<TextMeshProUGUI>().SetText(winner);
            winText.SetActive(true);
            //player1MoveText.gameObject.SetActive(false);
            //npcMoveText.gameObject.SetActive(false);
            gameOver = true;
            if (quiz != null)
            {
                quiz.GameOver();
            }
        }
    }

    //Allows the player to move based on the roll dice method
    public static void MovePlayer(int playerToMove)
    {
        switch (playerToMove)
        {
            case 1:
                player1.GetComponent<FollowPath>().moveAllowed = true;
                break;
            case 2:
                player2.GetComponent<FollowPath>().moveAllowed = true;
                break;
        }
    }

    //Displays the instructions on the screen when the help button is clicked
    //Hides the instructions when the help button is clicked again
    public void Instructions()
    {
        if (instructionsOn)
        {
            instructions.SetActive(false);
            instructionsOn = false;
        }
        else if (!instructionsOn)
        {
            instructions.SetActive(true);
            instructionsOn = true;
        }
    }
}
