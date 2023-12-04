using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellControl : MonoBehaviour
{
    //Projectile speed and accessing the GameManager.
    public float speed;

    private GameManager manager;

    void Start()
    {
        //Starts a basic coroutine to destroy after a few seconds, and contacts GameManager
        StartCoroutine(DelayDeath());
        manager = GameObject.Find("Manager").GetComponent<GameManager>();
    }

    void Update()
    {
        //If the GameManager says the game is running, 
        if (manager.gameRunning)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }

    //Destroy after a second
    IEnumerator DelayDeath()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
