using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI score;
    public TextMeshProUGUI wave;
    public TextMeshProUGUI rocks;

    public TextMeshProUGUI nextWaveText1;
    public TextMeshProUGUI nextWaveText2;

    public TextMeshProUGUI startScreen1;
    public TextMeshProUGUI startScreen2;

    public TextMeshProUGUI endScreen1;
    public TextMeshProUGUI endScreen2;

    public SpawnManager spawner;

    public int rockCount;

    public int scoreCount = 0;

    public bool gameRunning;

    public bool gameOver;

    void Start()
    {
        gameRunning = false;
        gameOver = false;

        startScreen1.enabled = true;
        startScreen2.enabled = true;

        endScreen1.enabled = false;
        endScreen2.enabled = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && !gameRunning && !gameOver)
        {
            startScreen1.enabled = false;
            startScreen2.enabled = false;

            spawner.SpawnNextWave(1);
            spawner.StartCoroutine("SpawnProcess");

            gameRunning = true;
        }

        if (Input.GetKeyDown(KeyCode.O) && gameOver && !gameRunning)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gameRunning)
        {
            rockCount = GameObject.FindGameObjectsWithTag("Rock").Length;
            rocks.text = "Remaining Rocks: " + rockCount;

            wave.text = "Current Round: " + spawner.waveNumber;

            score.text = "Score: " + scoreCount * 100;
        }
    }
}
