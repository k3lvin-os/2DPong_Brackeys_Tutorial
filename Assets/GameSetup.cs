using MyEnumerations;
using MyUnitResources;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Pong;


public class GameSetup : MonoBehaviour
{

    public Text GameplayText;
    public BoxCollider2D TopWall, BottomWall, LeftWall, RightWall;
    public Transform Player1, Player2;
    public Camera MainCamera;
    private BallControl myBallControl;


    void Awake()
    {
        myBallControl = GameObject.FindGameObjectWithTag("Ball").GetComponent<BallControl>();
    }


    private static bool AskAboutTryAgain()
    {
        bool? answer = null;
        while (answer == null)
        {
            if (Input.GetKeyDown(KeyCode.Y))
            {
                answer = true;
            }
            else if (Input.GetKeyDown(KeyCode.N))
            {
                answer = false;
            }

        }

        return (bool)answer;
    }

    public void NextBallShot()
    {
        myBallControl.ResetBall();
        myBallControl.GoBall(Const.WAIT_TIME);
    }


    // In begin of scene
    void Start()
    {
        float playerDistEdgeX = 1.5f;
        float rightEdge = MainCamera.ScreenToWorldPoint(new Vector3(Screen.width, 0f, 0f)).x;
        float leftEdge = MainCamera.ScreenToWorldPoint(new Vector3(0f, 0f, 0f)).x;

        // Move each wall to its each location
        TopWall.size = new Vector2(MainCamera.ScreenToWorldPoint(new Vector3(Screen.width * 2f, 0f, 0f)).x, 1f);
        TopWall.offset = new Vector2(0f, MainCamera.ScreenToWorldPoint(new Vector3(0f, Screen.height, 0f)).y + 0.5f);

        BottomWall.size = new Vector2(MainCamera.ScreenToWorldPoint(new Vector3(Screen.width * 2f, 0f, 0f)).x, 1f);
        BottomWall.offset = new Vector2(0f, MainCamera.ScreenToWorldPoint(new Vector3(0f, 0f, 0f)).y - 0.5f);

        RightWall.size = new Vector2(1f, MainCamera.ScreenToWorldPoint(new Vector3(0f, Screen.height * 2f, 0f)).y);
        RightWall.offset = new Vector2(MainCamera.ScreenToWorldPoint(new Vector3(Screen.width, 0f, 0f)).x + 0.5f, 0f);

        LeftWall.size = new Vector2(1f, MainCamera.ScreenToWorldPoint(new Vector3(0f, Screen.height * 2f, 0f)).y);
        LeftWall.offset = new Vector2(MainCamera.ScreenToWorldPoint(new Vector3(0f, 0f, 0f)).x - 0.5f, 0f);

        Player1.position = new Vector3(leftEdge + playerDistEdgeX, 0f, 0f);
        Player2.position = new Vector3(rightEdge - playerDistEdgeX, 0f, 0f);

    }

    public void EndOfGame(Player winner)
    {
        coroutineEndOfGame(winner);
    }

    private IEnumerator coroutineEndOfGame(Player winner)
    {
        GameplayText.text = String.Format("{0} WINS", winner);
        yield return new WaitForSeconds(Const.WAIT_TIME);
        GameplayText.text = "Play Again ( Y | N )?";
    }
}



