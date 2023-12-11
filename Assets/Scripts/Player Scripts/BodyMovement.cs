using System.Collections;
using System.Collections.Generic;
using System.Net.Security;
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
    public AudioClip rockHit;

    //Noise Troubleshooting
    private bool makingNoise;

    //Particle Systems
    public GameObject boom;
    public GameObject burn;

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

            StartCoroutine(boomProcess());
        }
    }

    //When you hit the rock, play a hit sound, wait a moment, then the tank explodes, wait another moment,
    //then set the tank on fire and make the end screen slowly blink. 
    IEnumerator boomProcess()
    {
        audioSource.PlayOneShot(rockHit);
        yield return new WaitForSeconds(1);
        audioSource.PlayOneShot(tankBoom);
        Instantiate(boom, transform.position, boom.transform.rotation);
        yield return new WaitForSeconds(1);
        Instantiate(burn, transform.position, burn.transform.rotation);
        while (true)
        {
            manager.endScreen1.enabled = true;
            yield return new WaitForSeconds(0.75f);
            manager.endScreen1.enabled = false;
            yield return new WaitForSeconds(0.75f);
        }
    }
}
