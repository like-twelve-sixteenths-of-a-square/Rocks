using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockBreak : MonoBehaviour
{
    public bool canSplit;
    public GameObject splitTo;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Shell"))
        {
            Debug.Log("thunk");

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
