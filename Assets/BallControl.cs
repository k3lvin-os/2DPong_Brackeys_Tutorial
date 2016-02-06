using UnityEngine;
using System.Collections;
using MyUnitResources;
using Pong;

public class BallControl : MonoBehaviour
{

    public float XForce, YForce;
    public GameObject ball;

    void Start()
    {
        GoBall(Const.BALL_SHOT_WAIT_TIME);
    }

    private IEnumerator WaitAndGoBall(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        GoBall();
    }

    public void ResetBall()
    {
        ball.transform.position = new Vector3(0f, 0f, 0f);
        ball.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
    }

    public void GoBall(float waitTime)
    {
        StartCoroutine(WaitAndGoBall(waitTime));
    }

    public void GoBall()
    {
        float randNumber = Random.Range(0f, 1f);
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
            float newYVelocity = (yVelocityBall + yVelocityPlayer) / 2  + Random.Range(0f, 5f);
            float newXVelocity = gameObject.GetComponent<Rigidbody2D>().velocity.x + Random.Range(0f, 5f);

            gameObject.GetComponent<Rigidbody2D>().velocity =
                new Vector2( newXVelocity,
                newYVelocity);


            GetComponent<AudioSource>().Play();
        }
    }

}
