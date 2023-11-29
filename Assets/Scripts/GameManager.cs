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

    public SpawnManager spawner;

    public int rockCount;

    public int scoreCount = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rockCount = GameObject.FindGameObjectsWithTag("Rock").Length;
        rocks.text = "Remaining Rocks: " + rockCount;

        wave.text = "Current Round: " + spawner.waveNumber;

        score.text = "Score: " + scoreCount * 100;
    }
}
