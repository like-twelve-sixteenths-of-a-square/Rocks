using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

//Probably the ACTUAL simplest code here.
public class RockMovement : MonoBehaviour
{
    //Sets a speed, contacts GameManager, you get it already.
    private float speed;

    private GameManager manager;

    void Start()
    {
        //Pick a random angle, pick a random speed.
        transform.Rotate(0, Random.Range(1, 360), 0);
        speed = Random.Range(2, 5);

        manager = GameObject.Find("Manager").GetComponent<GameManager>();
    }

    void Update()
    {
        //If the game is running, drift forward in the direction you chose.
        if (manager.gameRunning)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }
}
