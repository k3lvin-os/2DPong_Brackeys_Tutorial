using UnityEngine;
using System.Collections;

public class BallControl : MonoBehaviour
{

    public float XForce, YForce;
    public GameObject ball;
    public bool FlagResetBall { get; set; }

    void Start()
    {
        Invoke("GoBall", 2.0f);
    }

    void Update()
    {
        if(FlagResetBall)
        {
            resetBall();
            FlagResetBall = false;
        }
    }
    

    private void resetBall()
    {
        ball.transform.position = new Vector3(0f, 0f, 0f);
        ball.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
        Invoke("GoBall", 2.0f);
    }



    void GoBall()
    {
        float randNumber = Random.Range(0f, 2f);
        if (randNumber <= 0.5f)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(XForce, YForce));
        }
        else
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1 * XForce, YForce));
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.tag == "Player")
        {
            float yVelocityBall = gameObject.GetComponent<Rigidbody2D>().velocity.y;
            float yVelocityPlayer = col.gameObject.GetComponent<Rigidbody2D>().velocity.y;
            float newYVelocity = (yVelocityBall + yVelocityPlayer) / 2;

            gameObject.GetComponent<Rigidbody2D>().velocity =
                new Vector2(gameObject.GetComponent<Rigidbody2D>().velocity.x,
                newYVelocity);
        }
    }


}
