using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellControl : MonoBehaviour
{
    public float speed;

    private GameManager manager;

    void Start()
    {
        StartCoroutine(DelayDeath());
        manager = GameObject.Find("Manager").GetComponent<GameManager>();
    }

    void Update()
    {
        if (manager.gameRunning)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }

    IEnumerator DelayDeath()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
