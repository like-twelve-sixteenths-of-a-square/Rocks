using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Simple script to troubleshoot an audio hiccup that was bothering me
public class TinyNoiseScript : MonoBehaviour
{
    private TurretControl control;

    private AudioSource audioSource;

    public AudioClip pew;

    void Start()
    {
        control = GameObject.Find("Turret").GetComponent<TurretControl>();

        audioSource = gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K) && control.fireDelay)
        {
            audioSource.PlayOneShot(pew);
        }
    }
}
