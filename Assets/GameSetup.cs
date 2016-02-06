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
    private bool flagTryAgain;


    void Awake()
    {
        myBallControl = GameObject.FindGameObjectWithTag("Ball").GetComponent<BallControl>();
    }


    private void AskAboutTryAgain()
    {

        flagTryAgain = true; // Teels to update method to always run this method

        if (Input.GetKeyDown(KeyCode.Y))
        {
            ScoreManager.ResetScore();
            myBallControl.ResetBall();
            myBallControl.GoBall(Const.BALL_SHOT_WAIT_TIME);
            flagTryAgain = false;
            GameplayText.text = "";
        }
        else if (Input.GetKeyDown(KeyCode.N))
        {
            UnityUtil.Quit();
            flagTryAgain = false;
        }

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
        StartCoroutine(coroutineEndOfGame(winner));
    }

    private IEnumerator coroutineEndOfGame(Player winner)
    {
        GameplayText.text = String.Format("{0} WINS", winner);
        yield return new WaitForSeconds(Const.PLAY_AGAIN_WAIT_TIME);
        GameplayText.text = "Play Again ( Y | N )?";
        AskAboutTryAgain();
    }


    void Update()
    {
        if (flagTryAgain)
        {
            AskAboutTryAgain();
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            UnityUtil.Quit();
        }
    }
}




