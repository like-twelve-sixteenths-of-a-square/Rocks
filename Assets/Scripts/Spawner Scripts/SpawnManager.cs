using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject checker;

    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            Instantiate(checker);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            for (int i = 0; i < 10; i++)
            {
                Instantiate(checker);
            }
        }
    }
}
