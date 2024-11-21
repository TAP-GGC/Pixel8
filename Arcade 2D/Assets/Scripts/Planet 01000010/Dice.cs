using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dice : MonoBehaviour
{
    // Array of dice sides sprites to load from Resources folder
    private Sprite[] diceSides;

    public GameObject npcW_Text;
    public GameObject npcC_Text;


    // Reference to sprite renderer to change sprites
    private SpriteRenderer rend;

    //Player's turn variable (for multiplayer)
    [SerializeField] public static int whosTurn = 1;

    //Blocks player rolling of die until current player's turn is over
    public static bool coroutineAllowed = true;

    int randomNumber = 0;

    public Game game;
    // Use this for initialization
    private void Start()
    {
        coroutineAllowed = true;
        randomNumber = 0;
        whosTurn = 1;
        // Assign Renderer component
        rend = GetComponent<SpriteRenderer>();

        // Load dice sides sprites to array from DiceSides subfolder of Resources folder
        diceSides = Resources.LoadAll<Sprite>("DiceSides");

        //Shows face 6 at the beginning
        rend.sprite = diceSides[5];

        npcC_Text.SetActive(false);
        npcW_Text.SetActive(false);
    }

    private void Update()
    {
        if (whosTurn == -1)
        {
            Invoke("Roll_NPC", 2f);
        }
    }

    // If you left click over the dice then RollTheDice coroutine is started
    private void OnMouseDown()
    {
        if (!Game.gameOver && coroutineAllowed)
        {
            StartCoroutine("RollTheDice");
            Answers.choice1.interactable = true;
            Answers.choice2.interactable = true;
            Answers.choice3.interactable = true;
            Answers.choice4.interactable = true;

        }
    }

    public void Roll_NPC()
    {
        if (whosTurn != -1)
        {
            return;
        }
        if (!Game.gameOver && coroutineAllowed)
        {
            Debug.Log("NPC is rolling the dice");
            StartCoroutine("RollTheDice");
            randomNumber = Random.Range(0, 11);
            Debug.Log(randomNumber);
            if (randomNumber <= 6)
            {
                Debug.Log("NPC got the question right");
                StartCoroutine(DisplayNPCC_TextAfterDelay(2f));
                StartCoroutine(RemoveNPCC_TextAfterDelay(4f));
                StartCoroutine(MovePlayerAfterDelay(3f));
            }
            else
            {
                Debug.Log("NPC got the question wrong");
                StartCoroutine(DisplayNPCW_TextAfterDelay(2f));
                StartCoroutine(RemoveNPCW_TextAfterDelay(4f));
                StartCoroutine(SwitchPlayerTextAfterDelay(2f));
                //NPC got the question wrong and won't move
                //Switch to player 1's turn
            }
            whosTurn = 1;
            coroutineAllowed = true;
        }
    }

    // Coroutine that rolls the dice
    private IEnumerator RollTheDice()
    {
        coroutineAllowed = false;
        // Variable to contain random dice side number.
        // It needs to be assigned. Let it be 0 initially
        int randomDiceSide = 0;

        // Loop to switch dice sides ramdomly
        // before final side appears. 20 itterations here.
        for (int i = 0; i <= 20; i++)
        {
            // Pick up random value from 0 to 6 (Last exclusive)
            randomDiceSide = Random.Range(0, 6);

            // Set sprite to upper face of dice from array according to random value
            rend.sprite = diceSides[randomDiceSide];

            // Pause before next itteration
            yield return new WaitForSeconds(0.05f);
        }

        // Assigning final side so you can use this value later in your game
        // for player movement for example
        Game.diceSideThrown = randomDiceSide + 1;
        Debug.Log(Game.diceSideThrown);
        //Place in another place
    }

    private IEnumerator MovePlayerAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Game.MovePlayer(2);
    }

    private IEnumerator SwitchPlayerTextAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        game.npcMoveText.gameObject.SetActive(false);
        game.player1MoveText.gameObject.SetActive(true);
    }

    private IEnumerator RemoveNPCC_TextAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        npcC_Text.SetActive(false);

    }
    private IEnumerator DisplayNPCC_TextAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        npcC_Text.SetActive(true);
    }
    private IEnumerator RemoveNPCW_TextAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        npcW_Text.SetActive(false);

    }
    private IEnumerator DisplayNPCW_TextAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        npcW_Text.SetActive(true);
    }
}