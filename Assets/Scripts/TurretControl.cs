using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretControl : MonoBehaviour
{
    public float turnSpeed;

    public GameObject shell;

    public GameObject shooter;

    private bool fireDelay;
    public float timeDelay;

    void Start()
    {
        fireDelay = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.J))
        {
            transform.Rotate(Vector3.forward, turnSpeed * -1 * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.L))
        {
            transform.Rotate(Vector3.forward, turnSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.K) && fireDelay)
        {
            fireDelay = false;
            StartCoroutine(TonkProcess());
        }
    }

    IEnumerator TonkProcess()
    {
        Instantiate(shell, shooter.transform.position, shooter.transform.rotation);
        yield return new WaitForSeconds(timeDelay);
        fireDelay = true;
    }
}
