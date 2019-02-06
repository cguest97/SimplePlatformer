using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour {

    GameObject controller;

	// Use this for initialization
	void Start () {

        controller = GameObject.FindGameObjectWithTag("GameController");		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            controller.GetComponent<GameControl>().GameOver();
        }
    }
}
