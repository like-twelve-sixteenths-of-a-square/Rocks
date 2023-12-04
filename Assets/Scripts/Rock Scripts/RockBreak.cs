using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockBreak : MonoBehaviour
{
    //If the rock can split apart, and what it splits into
    public bool canSplit;
    public GameObject splitTo;

    //Access GameManager
    private GameManager manager;

    //Do AudioSource
    private AudioSource audioSource;

    //Noise(s)
    public AudioClip rockBreak;

    private void Start()
    {
        //Contacts the GameManager
        manager = GameObject.Find("Manager").GetComponent<GameManager>();

        //Contacts the AudioSource
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //If a tank shell hits a rock and the game is running...
        if (other.gameObject.CompareTag("Shell") && manager.gameRunning)
        {
            //...increase score...
            manager.scoreCount++;
            

            //...check if the rock can split...
            if (canSplit)
            {
                //...then split into a few instances of the designated rock size...
                for (int i = 0; i < Random.Range(1, 4); i++)
                {
                    Instantiate(splitTo, transform.position, transform.rotation);
                }
            }
            //.. cease existence
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Collider>().enabled = false;
            //...make a noise...
            audioSource.PlayOneShot(rockBreak);

            //...destroy the shell that hit you...
            Destroy(other.gameObject);

            //...and be destroyed.
            Destroy(gameObject, 1);
        }
    }
}
