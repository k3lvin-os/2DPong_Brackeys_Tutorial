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

    /*
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.name.Equals("Ball"))
        {
            string wallName = transform.name;
            ScoreManager.Score(wallName);
        }
    }*/


    void OnTriggerExit2D(Collider2D col)
    {
        if (col.name.Equals("Ball"))
        {
            string wallName = transform.name;
            ScoreManager.Score(wallName);
        }

    }
}
