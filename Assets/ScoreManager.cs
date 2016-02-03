using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour {

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

        Debug.Log("Player1 score is " + playerOneScore);
        Debug.Log("Player2 score is " + playerTwoScore);
    }

    void OnGUI()
    {
        GUI.skin = myGUiSkin;
        GUI.Label(new Rect(Screen.width / 2 - 200, 20, 100, 100), "" + playerOneScore);
        GUI.Label(new Rect(Screen.width / 2 + 200, 20, 100, 100), "" + playerTwoScore);

    }
}
