using UnityEngine;
using System.Collections;
using MyEnumerations;

public class SideWalls : MonoBehaviour
{

    void Awake()
    {
        GameObject ball = GameObject.FindGameObjectWithTag("Ball");
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name.Equals("Ball"))
        {
            gameObject.GetComponent<AudioSource>().Play();
            string wallName = transform.name;
            ScoreManager.Score(wallName);
            ScoreManager.DealtWithScore();    
        }
    }
    
}
