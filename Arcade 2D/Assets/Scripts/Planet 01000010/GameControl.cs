using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    //Reference to UI game objects
    public static GameObject whoWinsText, player1MoveText, player2MoveText;

    //Reference to player objects
    private static GameObject player1, player2;

    //Holds current number of move distance
    public static int diceSideThrown = 0;

    //Start waypoints to determine where each player starts
    public static int player1StartWaypoint = 0;
    public static int player2StartWaypoint = 0;

    //Game over indicator
    public static bool gameOver = false;

 
    // Start is called before the first frame update
    void Start() { 
        //Finds the UI elements so we can control them
        whoWinsText = GameObject.Find("WhoWinsText");
        player1MoveText = GameObject.Find("Player1MoveText");
        player2MoveText = GameObject.Find("Player2MoveText");

        player1 = GameObject.Find("Player1");
        player2 = GameObject.Find("Player2");

        //Finds the player objects so they can be controlled
        //Disables movements of players
        player1.GetComponent<FollowPath>().moveAllowed = false;
        player2.GetComponent<FollowPath>().moveAllowed = false;

        //Win text off
        whoWinsText.gameObject.SetActive(false);
        //Player 1 move text on so they know it's their turn
        player1MoveText.gameObject.SetActive(true);
        //Player 2 move text off
        player2MoveText.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    { 
        if (player1.GetComponent<FollowPath>().waypointIndex >
            player1StartWaypoint + diceSideThrown)
        {
            player1.GetComponent<FollowPath>().moveAllowed = false;
            player1MoveText.gameObject.SetActive(false);
            player2MoveText.gameObject.SetActive(true);
            player1StartWaypoint = player1.GetComponent<FollowPath>().waypointIndex - 1;
        }

        if (player2.GetComponent<FollowPath>().waypointIndex >
            player2StartWaypoint + diceSideThrown)
        {
            player2.GetComponent<FollowPath>().moveAllowed = false;
            player2MoveText.gameObject.SetActive(false);
            player1MoveText.gameObject.SetActive(true);
            player2StartWaypoint = player2.GetComponent<FollowPath>().waypointIndex - 1;
        }

        if (player1.GetComponent<FollowPath>().waypointIndex ==
            player1.GetComponent<FollowPath>().waypoints.Length)
        {
            whoWinsText.gameObject.SetActive(true);
            player1MoveText.gameObject.SetActive(false);
            player2MoveText.gameObject.SetActive(false);
            whoWinsText.GetComponent<TextMeshProUGUI>().SetText("Player 1 Wins!!");
            gameOver = true;
        }

        if (player2.GetComponent<FollowPath>().waypointIndex ==
            player2.GetComponent<FollowPath>().waypoints.Length)
        {
            whoWinsText.gameObject.SetActive(true);
            player1MoveText.gameObject.SetActive(false);
            player2MoveText.gameObject.SetActive(false);
            whoWinsText.GetComponent<TextMeshProUGUI>().SetText("Player 2 Wins!!");
            gameOver = true;
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
}
