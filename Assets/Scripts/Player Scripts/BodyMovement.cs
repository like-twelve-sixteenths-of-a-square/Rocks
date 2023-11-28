using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyMovement : MonoBehaviour
{
    public float speed;
    public float turnSpeed;

    private float vInput;
    private float hInput;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        vInput = Input.GetAxis("Vertical");
        hInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.forward * speed * vInput * Time.deltaTime);
        transform.Rotate(Vector3.up * turnSpeed * hInput * Time.deltaTime);
    }
}
