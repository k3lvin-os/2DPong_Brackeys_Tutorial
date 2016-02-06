using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using MyEnumerations;
using Pong;

public class ScoreManager : MonoBehaviour
{
    private static int playerOneScore = 0;
    private static int playerTwoScore = 0;
    public GUISkin MyGUISkin;
    public Text GameplayText;
    private static GameObject myGameManager;
    private static BallControl myBallControl;

    void Awake()
    {
        myGameManager = gameObject;
        myBallControl = GameObject.FindGameObjectWithTag("Ball").GetComponent<BallControl>();
    }

    public static void ResetScore()
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
            myBallControl.ResetBall();
            myBallControl.GoBall(Const.BALL_SHOT_WAIT_TIME);
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
        if (playerOneScore == Const.MAX_SCORE)
        {
            return Player.Player1;
        }

        else if (playerTwoScore == Const.MAX_SCORE)
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
