using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Simple script to troubleshoot an audio hiccup that was bothering me
public class TinyNoiseParticlesScript : MonoBehaviour
{
    private TurretControl control;

    public GameObject anchor;

    private AudioSource audioSource;

    public AudioClip pew;
    public GameObject pewticles;

    void Start()
    {
        control = GameObject.Find("Turret").GetComponent<TurretControl>();

        audioSource = gameObject.GetComponent<AudioSource>();

    }

    void Update()
    {
        if (Input.GetButtonDown("Shoot") && control.fireDelay)
        {
            audioSource.PlayOneShot(pew);
            Instantiate(pewticles, anchor.transform.position, anchor.transform.rotation);
        }
    }
}
