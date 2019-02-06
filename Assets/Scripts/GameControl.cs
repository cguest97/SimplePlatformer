using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/* This script controls aspects of the game such as the UI elements, score and resolves game overs */
[System.Serializable]
public class GameControl : MonoBehaviour
{

    public int currentScore;
    public Text myScore;
    public Text gameOverText;

    public AudioClip coinPickup;
    public AudioClip playerDeath;
    public AudioClip victorySound;
    public AudioClip jumpSound;

    bool isGameOver;
    bool isGameWon;

    public GameObject player;
    public GameObject myCamera;

    private AudioSource myAudio;

    void Start()
    {
        currentScore = 0;
        myScore.text = "Score: " + currentScore;
        gameOverText.text = "";
        isGameOver = false;
        isGameWon = false;
        myAudio = gameObject.GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        if (isGameOver && Input.GetKeyDown(KeyCode.R)) {
            Application.LoadLevel(Application.loadedLevel);
        }

        if (Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();
        }
    }

    public void addScore(int points)
    {
        myAudio.PlayOneShot(coinPickup);
        currentScore += points;
        updateScoreText();
    }

    public int getCurrentScore()
    {
        return currentScore;
    }

    public void updateScoreText()
    {
        myScore.text = "Score: " + currentScore;
    }

    public void GameOver() {
        myCamera.GetComponent<CameraControl>().setFollow(false);
        player.GetComponent<PlayerController>().destroy_self();
        myAudio.PlayOneShot(playerDeath);
        isGameOver = true;

        if(!isGameWon)
            gameOverText.text = "Press R to Restart";
    }

    public void GameWon() {
        if (!isGameOver)
        {
            isGameOver = true;
            isGameWon = true;
            myAudio.PlayOneShot(victorySound);
            gameOverText.text = "Congratulations! You Win.";
        }
    }

    public void playJumpSound() {
        myAudio.PlayOneShot(jumpSound);
    }

}
