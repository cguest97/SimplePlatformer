using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* If Player leaves the playable area destroy them */
public class OutOfBounds : MonoBehaviour {

    public GameControl myController;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        myController.GetComponent<GameControl>().GameOver();
    }
}
