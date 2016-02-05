using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using MyEnumerations;

public class ScoreManager : MonoBehaviour
{

    private static int playerOneScore = 0;
    private static int playerTwoScore = 0;
    public GUISkin MyGUISkin;
    public Text GameplayText;
    public bool flagResetScore { get; set; }


    private static void ResetScore()
    {
        playerOneScore = 0;
        playerTwoScore = 0;
    }

    void Update()
    {
        Player checkWinner = someoneWonTheGame();
        if (checkWinner != Player.NotAPlayer)
        {
            gameObject.GetComponent<GameSetup>().Winner = checkWinner;
            gameObject.GetComponent<GameSetup>().EndOfGame = true;
            
        
        }

        if (flagResetScore)
        {
            ResetScore();
        }
    }

    public static void Score(string wallName)
    {

        if (wallName.Equals("rightWall"))
        {
            playerOneScore++;
        }
        else
        {
            playerTwoScore++;
        }

    }



    private static void showMessage(Text textComponent, String message)
    {
        textComponent.text = message;
    }

    private static Player someoneWonTheGame()
    {
        if (playerOneScore == 2)
        {
            return Player.Player1;
        }

        else if (playerTwoScore == 2)
        {
            return Player.Player2;
        }

        else
        {
            return Player.NotAPlayer;
        }
    }

    void OnGUI()
    {
        GUI.skin = MyGUISkin;
        GUI.Label(new Rect(Screen.width / 2 - 200, 20, 100, 100), "" + playerOneScore);
        GUI.Label(new Rect(Screen.width / 2 + 200, 20, 100, 100), "" + playerTwoScore);

    }





}
