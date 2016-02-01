using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

    public float Speed = 10f;
    public KeyCode MoveUp, MoveDown;
   

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetKey(MoveUp))
        {
           gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, Speed);

        }

        else if(Input.GetKey(MoveDown))
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, Speed * -1);

        }

        else
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
        }
    }
}
