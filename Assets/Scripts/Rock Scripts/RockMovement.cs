using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RockMovement : MonoBehaviour
{
    private float speed;

    private GameManager manager;

    void Start()
    {
        transform.Rotate(0, Random.Range(1, 360), 0);
        speed = Random.Range(2, 5);

        manager = GameObject.Find("Manager").GetComponent<GameManager>();
    }

    void Update()
    {
        if (manager.gameRunning)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }
}
