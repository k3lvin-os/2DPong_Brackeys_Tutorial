using MyEnumerations;
using MyUnitResources;
using System;
using UnityEngine;
using UnityEngine.UI;


public class GameSetup : MonoBehaviour
{
    private bool _endOfGame;
    private float counter = 0;

    public Player? Winner { get; set; }
    public Text GameplayText;
    public BoxCollider2D TopWall, BottomWall, LeftWall, RightWall;
    public Transform Player1, Player2;
    public Camera MainCamera;
    public bool EndOfGame
    {
        get { return _endOfGame; }
        set
        {
            if (Winner != null)
            {
                _endOfGame = value;
            }
            else
            {
                throw new MissingReferenceException("Could not set value to EndOfGame propriety."
                    + "See if you missed out some requirement");
            }
        }

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

            Debug.Log("I'm inside AskAboutTryAgain");

        }

        return (bool)answer;
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

    private void resetGame()
    {
        gameObject.GetComponent<ScoreManager>().flagResetScore = true;
        GameObject ball = GameObject.FindGameObjectWithTag("Ball");
        BallControl myBallControl = ball.GetComponent<BallControl>();
        myBallControl.FlagResetBall = true;
    }

    void Update()
    {
        if (EndOfGame)
        {
            GameplayText.text = String.Format("{0} WINS!", Winner);
            float now = 0f;
            while (now < 5f)
            {
                now += Time.deltaTime;
                Debug.Log("now = " + now);
            }
            GameplayText.text = ""; // test
            /*
            GameplayText.text = "PLAY AGAIN? ( Y | N )";
            bool tryAgain = AskAboutTryAgain();
            if (tryAgain)
            {
                resetGame();
                EndOfGame = false;
                Winner = null;
            }
            else
            {
                UnityUtil.Quit();
            }
            */
        }
        


    }
}
