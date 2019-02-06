using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/* This Script is attached to any object that when collected will give the player points */


public class ScorePoints : MonoBehaviour
{

    public int scoreModifier = 10;
    private GameObject controller;

    bool scoring;

    private void Start()
    {
        controller = GameObject.FindGameObjectWithTag("GameController");
        scoring = false;
    }


    /* When collision with player, update score and destroy self */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !scoring)
        {
            scoring = true;
            Debug.Log("Scored");
            controller.GetComponent<GameControl>().addScore(scoreModifier);
            Destroy(gameObject);
        }

    }
}
