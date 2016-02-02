using UnityEngine;
using System.Collections;

public class BallControl : MonoBehaviour {

    public float XForce , YForce ;
   

	// Use this for initialization
	void Start () {
        float randNumber = Random.Range(0f, 1f);
        if(randNumber <= 0.5f )
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(XForce, YForce));
        }
        else
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(XForce, YForce));
        }
    }
	
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.collider.tag == "Player")
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
