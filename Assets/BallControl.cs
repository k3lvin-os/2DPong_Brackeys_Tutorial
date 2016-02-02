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
	
    void OnCollisionEnter(Collision col)
    {
        if(col.collider.CompareTag("Player"))
        {
            Debug.Log("It's working");
        }
    }
}
