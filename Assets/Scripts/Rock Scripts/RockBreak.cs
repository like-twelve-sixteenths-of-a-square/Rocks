using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockBreak : MonoBehaviour
{
    public bool canSplit;
    public GameObject splitTo;

    private GameManager manager;

    private void Start()
    {
        manager = GameObject.Find("Manager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Shell"))
        {
            manager.scoreCount++;

            if (canSplit)
            {
                for (int i = 0; i < Random.Range(1, 4); i++)
                {
                    Instantiate(splitTo, transform.position, transform.rotation);
                }
            }

            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
