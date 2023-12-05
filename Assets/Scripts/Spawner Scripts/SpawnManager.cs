using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //The spawning system's spawn checker Prefab.
    public GameObject checker;

    //for counting rocks and waves
    public int rockCount;
    public int waveNumber = 1;

    //GameManager, so on...
    public GameManager manager;
    private AudioSource audioSource;

    //Noices
    public AudioClip good;
    public AudioClip warning;
    public AudioClip waveSpawn;

    public TColorSw bodySwap;

    void Start()
    {
        //... so forth.
        manager = GameObject.Find("Manager").GetComponent<GameManager>();
        bodySwap = GameObject.Find("Body").GetComponent<TColorSw>();
        audioSource = gameObject.GetComponent<AudioSource>();
    }


    void Update()
    {
        //Count how many rocks are in play at any given time.
        rockCount = GameObject.FindGameObjectsWithTag("Rock").Length;
    }

    //The SpawnProcess works as such...
    public IEnumerator SpawnProcess()
    {
        //...wait 5 seconds as the first wave spawns...
        yield return new WaitForSeconds(5);

        //...then, if the game is running, run in a loop and make these checks...
        if (manager.gameRunning)
        {
            while (true)
            {
                //...while there are still rocks in play, idle...
                while (rockCount > 0)
                {
                    yield return new WaitForSeconds(0.5f);
                }

                //...once all rocks are gone, progress to the next wave...
                waveNumber++;

                //...show the first set of next wave text, praise the player...
                audioSource.PlayOneShot(good);
                for (int i = 0; i < 3; i++)
                {
                    manager.nextWaveText1.enabled = true;
                    yield return new WaitForSeconds(0.05f);
                    manager.nextWaveText1.enabled = false;
                    yield return new WaitForSeconds(0.05f);
                }

                //...hold it there a second...
                manager.nextWaveText1.enabled = true;

                yield return new WaitForSeconds(1.25f);

                manager.nextWaveText1.enabled = false;

                //...then, warn the player of the next wave inbound...
                for (int i = 0; i < 2; i++)
                {
                    audioSource.PlayOneShot(warning);
                    manager.nextWaveText2.enabled = true;
                    yield return new WaitForSeconds(0.5f);
                    manager.nextWaveText2.enabled = false;
                    yield return new WaitForSeconds(0.5f);
                }
                audioSource.PlayOneShot(warning);
                //...hold that a second as well...
                manager.nextWaveText2.enabled = true;

                yield return new WaitForSeconds(1.5f);

                manager.nextWaveText2.enabled = false;

                //...finally, start the next wave, wait a moment as the checkers are sent out, then start the loop again.
                audioSource.PlayOneShot(waveSpawn);
                SpawnNextWave(waveNumber);
                bodySwap.StartCoroutine("SwappoColore");

                yield return new WaitForSeconds(1);
            }
        }
    }

    public void SpawnNextWave(int rockCount)
    {
        //Sends out a number of spawn checkers equal to the current wave, multiplied by a number.
        for (int i = 0; i < (rockCount * Random.Range(3, 4)); i++)
        {
            Instantiate(checker);
        }
    }
}
