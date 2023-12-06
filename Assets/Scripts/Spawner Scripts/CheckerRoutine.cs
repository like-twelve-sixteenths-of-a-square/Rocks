using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Somehow the simplest and most complicated part of the process

public class CheckerRoutine : MonoBehaviour
{
    //Sets the range at which they can spawn on the board
    //(anywhere but the edges, don't want them spawning ON the screenwrap border)
    private float maxX = 25;
    private float maxZ = 14;

    //A list of spawnable rocks.
    public GameObject[] rockSpawned;

    //Just like the GameManager and SpawnManager...
    private GameObject player;

    void Start()
    {
        //...we are contacting the player.
        //(Yes, the player's GameObject is named "tonk", I get to have a little fun).
        player = GameObject.Find("tonk");


        //Begin the spawn checking process
        StartCoroutine(SpawnProcess());
    }

    IEnumerator SpawnProcess()
    {
        //First, set the bounds and turn those into a position
        Vector3 spawnPos = new Vector3(Random.Range(-maxX, maxX), 0, Random.Range(-maxZ, maxZ));

        yield return new WaitForSeconds(0.1f);

        //Second, teleport to the position
        transform.position = spawnPos;

        yield return new WaitForSeconds(0.1f);

        //Third, start the spawnCheck procedure
        bool spawnCheck = true;


        //Translation: If too close to the player, go somewhere else and try again, then continue on.
        while (spawnCheck)
        {
            if ((player.transform.position.x - transform.position.x) <= 3 && (player.transform.position.z - transform.position.z) <= 3)
            {
                Debug.Log("Spawn check failed, try again...");
                Vector3 newPos = new Vector3(Random.Range(-maxX, maxX), 0, Random.Range(-maxZ, maxZ));
                transform.position = newPos;
            }
            else
            {
                if ((player.transform.position.x - transform.position.x) <= -3 && (player.transform.position.z - transform.position.z) <= -3)
                {
                    Debug.Log("Spawn check failed, try again...");
                    Vector3 newPos = new Vector3(Random.Range(-maxX, maxX), 0, Random.Range(-maxZ, maxZ));
                    transform.position = newPos;
                }
                else
                {
                    spawnCheck = false;
                }
            }
        }
        //Just console reporting to ensure it's all going smooth
        Debug.Log("Spawn check successful, spawning rock and destroying.");

        //Fourth, pick a random rock.
        int rockIndex = Random.Range(0, rockSpawned.Length);

        //Fifth, spawn that rock, and destroy the checker.
        Instantiate(rockSpawned[rockIndex], transform.position, transform.rotation);

        Destroy(gameObject);
    }
}
