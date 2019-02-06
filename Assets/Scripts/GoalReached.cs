using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Script ends game when player object collides with trigger */
[System.Serializable]
public class GoalReached : MonoBehaviour{
    public GameControl myController;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") {
            Debug.Log("Win");
            myController.GetComponent<GameControl>().GameWon();
        } 
    }
}
