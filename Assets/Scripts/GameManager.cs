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
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI wave;
    public TextMeshProUGUI rocks;

    public Image nextWaveText1;
    public Image nextWaveText2;

    public Image startScreen1;
    public Image startScreen2;

    public Image endScreen1;

    public Image cover;

    public Image backer;

    //Contacts the SpawnManager...
    public SpawnManager spawner;
    //...and the AudioSource.
    private AudioSource audioSource;
    public AudioClip shutOff;
    public AudioClip shutOn;

    //Values for previously mentioned hud elements.
    public int rockCount;

    public int scoreCount = 0;

    public int highScore = 0;

    //Used to determine the game state.
    public bool gameRunning;

    public bool gameOver;

    void Start()
    {
        //Right off  the bat, the game isn't running yet, the game isn't over yet..
        gameRunning = false;
        gameOver = false;

        //...and the start screen is visible... and blinking...
        startScreen1.enabled = true;
        StartCoroutine(StartScreenFlicker());

        //...and the end screen is hidden...
        endScreen1.enabled = false;

        //...and hide the screen cover...
        cover.enabled = false;

        //...AND the AudioSource is lined up...
        audioSource = gameObject.GetComponent<AudioSource>();

        //...AND play the turn on noise.
        audioSource.PlayOneShot(shutOn);
    }

    private void Update()
    {
        //When you press P and the game has yet to start or end...
        if (Input.GetButtonDown("Start") && !gameRunning && !gameOver)
        {
            //...hide the start screen...
            startScreen1.enabled = false;
            startScreen2.enabled = false;

            //...line up the high score...
            highScore = PlayerPrefs.GetInt("HighScore", 0);

            //...start the first wave...
            spawner.SpawnNextWave(1);
            spawner.StartCoroutine("SpawnProcess");

            //...and start the game.
            gameRunning = true;
        }

        //If the game is over and no longer running, press O to start over.
        if (Input.GetButtonDown("Coin") && gameOver && !gameRunning)
        {
            StartCoroutine(RestartProcess());
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

            //...keep the score up to date...
            score.text = "Score: " + scoreCount * 100;

            //...and keep the high score up to date.
            highScoreText.text = "Best Score: " + highScore * 100;
            if (scoreCount > highScore)
            {
                highScore = scoreCount;
                PlayerPrefs.SetInt("HighScore", highScore);
                PlayerPrefs.Save();
            }    
        }
    }

    IEnumerator RestartProcess()
    {
        //Covers the screen with a black rectangle for a second, then restarts the game
        cover.enabled = true;
        audioSource.PlayOneShot(shutOff);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    IEnumerator StartScreenFlicker()
    {
        //Just makes the "press start to play" button blink slowly.
        while (!gameRunning)
        {
            startScreen2.enabled = true;
            yield return new WaitForSeconds(1);
            startScreen2.enabled = false;
            yield return new WaitForSeconds(1);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        backer.enabled = false;
    }

    private void OnTriggerExit(Collider other)
    {
        backer.enabled = true;
    }
}
