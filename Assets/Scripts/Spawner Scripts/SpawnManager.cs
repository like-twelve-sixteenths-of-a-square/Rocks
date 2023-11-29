using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject checker;

    public int rockCount;
    public int waveNumber = 1;

    public GameManager manager;

    void Start()
    {
        manager = GameObject.Find("Manager").GetComponent<GameManager>();
        SpawnNextWave(waveNumber);
        StartCoroutine(SpawnProcess());
    }

    // Update is called once per frame
    void Update()
    {
        rockCount = GameObject.FindGameObjectsWithTag("Rock").Length;
    }

    IEnumerator SpawnProcess()
    {
        yield return new WaitForSeconds(5);

        while (true)
        {
            while (rockCount > 0)
            {
                yield return new WaitForSeconds(0.5f);
            }

            waveNumber++;

            for (int i = 0; i < Random.Range(1, 4); i++)
            {
                manager.nextWaveText1.enabled = true;
                yield return new WaitForSeconds(0.1f);
                manager.nextWaveText1.enabled = false;
                yield return new WaitForSeconds(0.1f);
            }

            manager.nextWaveText1.enabled = true;

            yield return new WaitForSeconds(0.75f);

            manager.nextWaveText1.enabled = false;

            for (int i = 0; i < Random.Range(1, 4); i++)
            {
                manager.nextWaveText2.enabled = true;
                yield return new WaitForSeconds(0.75f);
                manager.nextWaveText2.enabled = false;
                yield return new WaitForSeconds(0.5f);
            }

            manager.nextWaveText2.enabled = true;

            yield return new WaitForSeconds(1.5f);

            manager.nextWaveText2.enabled = false;
            SpawnNextWave(waveNumber);

            yield return new WaitForSeconds(1);
        }
    }

    void SpawnNextWave(int rockCount)
    {
        for (int i = 0; i < (rockCount * Random.Range(1, 3)); i++)
        {
            Instantiate(checker);
        }
    }
}
