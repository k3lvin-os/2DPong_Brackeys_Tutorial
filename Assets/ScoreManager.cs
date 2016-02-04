using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using MyEnumerations;

public class ScoreManager : MonoBehaviour
{

    public static int playerOneScore = 0;
    public static int playerTwoScore = 0;
    public GUISkin myGUiSkin;

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

        /*  if (playerTwoScore == 10 || playerOneScore == 10)
          {
              GameObject winText = GameObject.FindGameObjectWithTag("VictoryText");

              if (playerOneScore == 10)
              {
                  winText.GetComponent<Text>().text = "Player1 WINS";
              }
              else if (playerTwoScore == 10)
              {
                  winText.GetComponent<Text>().text = "Player2 WINS";
              }

              throw new NotImplementedException("Implement the game play again behaviour"); 
          }
          */
    }

    public static Player IsGameOver()
    {
        if (playerOneScore == 10)
        {
            return Player.Player1;
        }

        else if (playerTwoScore == 10)
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
        GUI.skin = myGUiSkin;
        GUI.Label(new Rect(Screen.width / 2 - 200, 20, 100, 100), "" + playerOneScore);
        GUI.Label(new Rect(Screen.width / 2 + 200, 20, 100, 100), "" + playerTwoScore);

    }
}
