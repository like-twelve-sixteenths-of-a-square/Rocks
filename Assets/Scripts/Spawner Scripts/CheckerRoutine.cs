using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckerRoutine : MonoBehaviour
{
    private float maxX;
    private float maxZ;

    public GameObject checker;

    void Start()
    {
        Vector3 spawnPos = new Vector3 (Random.Range(-maxX, maxX), 0, Random.Range(-maxZ, maxZ));
        transform.position = spawnPos;

        if (transform.position.x <= 2 && transform.position.z <= 2)
        {
            Instantiate(checker);
            Debug.Log("Spawn failed, try again...");
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("spawn success");
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
