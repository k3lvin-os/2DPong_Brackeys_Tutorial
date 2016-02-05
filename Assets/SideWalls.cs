using UnityEngine;
using System.Collections;
using MyEnumerations;

public class SideWalls : MonoBehaviour
{
    BallControl myBallControl;

    void Awake()
    {
        GameObject ball = GameObject.FindGameObjectWithTag("Ball");
        myBallControl = ball.GetComponent<BallControl>();
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.name.Equals("Ball"))
        {
            string wallName = transform.name;
            ScoreManager.Score(wallName);
            myBallControl.FlagResetBall = true;
        }
    }
    
}
