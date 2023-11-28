using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellControl : MonoBehaviour
{
    public float speed;

    void Start()
    {
        StartCoroutine(DelayDeath());
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    IEnumerator DelayDeath()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
