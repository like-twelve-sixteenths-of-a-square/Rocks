using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RockMovement : MonoBehaviour
{
    private float speed;

    void Start()
    {
        transform.Rotate(0, Random.Range(1, 360), 0);
        speed = Random.Range(2, 5);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
