using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckerRoutine : MonoBehaviour
{
    private float maxX = 25;
    private float maxZ = 14;

    public GameObject[] rockSpawned;

    private GameObject player;

    void Start()
    {
        player = GameObject.Find("tonk");

        StartCoroutine(SpawnProcess());
    }

    IEnumerator SpawnProcess()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-maxX, maxX), 0, Random.Range(-maxZ, maxZ));

        yield return new WaitForSeconds(0.1f);

        transform.position = spawnPos;

        yield return new WaitForSeconds(0.1f);

        bool spawnCheck = true;

        while (spawnCheck)
        {
            if ((player.transform.position.x - transform.position.x) <= 2 && (player.transform.position.z - transform.position.z) <= 2)
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

        Debug.Log("Spawn check successful, spawning rock and destroying.");

        int rockIndex = Random.Range(0, rockSpawned.Length);

        Instantiate(rockSpawned[rockIndex], transform.position, transform.rotation);

        Destroy(gameObject);
    }
}
