using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellControl : MonoBehaviour
{
    private float speed = 5;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DelayDeath());
    }

    // Update is called once per frame
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
