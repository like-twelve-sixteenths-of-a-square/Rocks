using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //Impossible amount of different HUD elements.
    public TextMeshProUGUI score;
    public TextMeshProUGUI wave;
    public TextMeshProUGUI rocks;

    public TextMeshProUGUI nextWaveText1;
    public TextMeshProUGUI nextWaveText2;

    public TextMeshProUGUI startScreen1;
    public TextMeshProUGUI startScreen2;

    public TextMeshProUGUI endScreen1;
    public TextMeshProUGUI endScreen2;

    //Contacts the SpawnManager
    public SpawnManager spawner;

    //Values for previously mentioned hud elements.
    public int rockCount;

    public int scoreCount = 0;

    //Used to determine the game state.
    public bool gameRunning;

    public bool gameOver;

    void Start()
    {
        //Right off  the bat, the game isn't running yet, the game isn't over yet..
        gameRunning = false;
        gameOver = false;

        //...the start screen is visible..
        startScreen1.enabled = true;
        startScreen2.enabled = true;

        //...the end screen is hidden.
        endScreen1.enabled = false;
        endScreen2.enabled = false;
    }

    private void Update()
    {
        //When you press P and the game has yet to start or end...
        if (Input.GetButtonDown("Start") && !gameRunning && !gameOver)
        {
            //...hide the start screen
            startScreen1.enabled = false;
            startScreen2.enabled = false;

            //...start the first wave...
            spawner.SpawnNextWave(1);
            spawner.StartCoroutine("SpawnProcess");

            //...and start the game.
            gameRunning = true;
        }

        //If the game is over and no longer running, press O to start over.
        if (Input.GetButtonDown("Coin") && gameOver && !gameRunning)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void FixedUpdate()
    {
        //When the game is running...
        if (gameRunning)
        {
            //...count the rocks and list it on the HUD...
            rockCount = GameObject.FindGameObjectsWithTag("Rock").Length;
            rocks.text = "Remaining Rocks: " + rockCount;

            //...be sure to update the round count...
            wave.text = "Current Round: " + spawner.waveNumber;

            //...and keep the score up to date.
            score.text = "Score: " + scoreCount * 100;
        }
    }
}
