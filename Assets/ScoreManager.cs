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
    private static GameObject myGameManager;

    void Awake()
    {
        myGameManager = gameObject;
    }

    private static void ResetScore()
    {
        playerOneScore = 0;
        playerTwoScore = 0;
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

    public static void DealtWithScore()
    {
        Player? checkWinner = ScoreManager.SomeoneWonTheGame();
        if (checkWinner == null)
        {
            myGameManager.GetComponent<GameSetup>().NextBallShot();
        }
        else
        {
            Player winner = (Player) checkWinner;
            myGameManager.GetComponent<GameSetup>().EndOfGame(winner);
        }
    }

    private static void showMessage(Text textComponent, String message)
    {
        textComponent.text = message;
    }

    public static Player? SomeoneWonTheGame()
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
            return null;
        }
    }

    void OnGUI()
    {
        GUI.skin = MyGUISkin;
        GUI.Label(new Rect(Screen.width / 2 - 200, 20, 100, 100), "" + playerOneScore);
        GUI.Label(new Rect(Screen.width / 2 + 200, 20, 100, 100), "" + playerTwoScore);
    }

}
