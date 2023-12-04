using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BodyMovement : MonoBehaviour
{
    //Speed values
    public float speed;
    public float turnSpeed;

    //Input values
    private float vInput;
    private float hInput;

    //sdgasgfdjsfdakhjdsfkjhgfdsagkj GameManager contact stuff weeeeee
    private GameManager manager;

    //Audio Source :)
    private AudioSource audioSource;

    //Noises
    public AudioClip tankBoom;

    //Noise Troubleshooting
    private bool makingNoise;

    void Start()
    {
        //yippee
        manager = GameObject.Find("Manager").GetComponent<GameManager>();

        //Gets the AudioSource component from the GameObject.
        audioSource = gameObject.GetComponent<AudioSource>(); 
    }

    void Update()
    {
        //Axis inputs are the input values/
        vInput = Input.GetAxis("Vertical");
        hInput = Input.GetAxis("Horizontal");

        //Moves back and forth according to the vertical input values.
        //Rotates left and right accoridng to the horizontal ones.
        if (manager.gameRunning)
        {
            transform.Translate(Vector3.forward * speed * vInput * Time.deltaTime);
            transform.Rotate(Vector3.up * turnSpeed * hInput * Time.deltaTime);
        }

        //Plays tread rattling noises when you're moving/turning
        if (vInput > 0 && manager.gameRunning && !makingNoise)
        {
            audioSource.Play();
            makingNoise = true;
        }
        if (vInput < 0 && manager.gameRunning && !makingNoise)
        {
            audioSource.Play();
            makingNoise = true;
        }
        if (hInput > 0 && manager.gameRunning && !makingNoise)
        {
            audioSource.Play();
            makingNoise = true;
        }
        if (hInput < 0 && manager.gameRunning && !makingNoise)
        {
            audioSource.Play();
            makingNoise = true;
        }

        //Stops the noise when you aren't moving
        if (vInput == 0 && manager.gameRunning)
        {
            audioSource.Stop();
            makingNoise = false;
        }
        if (vInput == 0 && manager.gameRunning)
        {
            audioSource.Stop();
            makingNoise = false;        }
    }


    //Translation: If you hit a rock, the game is over, show the end screen, play lose noise.
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Rock"))
        {
            audioSource.Stop();
            manager.gameRunning = false;
            manager.gameOver = true;

            audioSource.PlayOneShot(tankBoom);
            manager.endScreen1.enabled = true;
            manager.endScreen2.enabled = true;
        }
    }
}
