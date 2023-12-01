using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyMovement : MonoBehaviour
{
    public float speed;
    public float turnSpeed;

    private float vInput;
    private float hInput;

    private GameManager manager;

    void Start()
    {
        manager = GameObject.Find("Manager").GetComponent<GameManager>();

        manager.endScreen1.enabled = false;
        manager.endScreen2.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        vInput = Input.GetAxis("Vertical");
        hInput = Input.GetAxis("Horizontal");

        if (manager.gameRunning)
        {
            transform.Translate(Vector3.forward * speed * vInput * Time.deltaTime);
            transform.Rotate(Vector3.up * turnSpeed * hInput * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Rock"))
        {
            manager.gameRunning = false;
            manager.gameOver = true;

            manager.endScreen1.enabled = true;
            manager.endScreen2.enabled = true;
        }
    }
}
