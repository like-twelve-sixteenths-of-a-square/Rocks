using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretControl : MonoBehaviour
{
    public float turnSpeed;

    public GameObject shell;

    public GameObject shooter;

    public GameObject anchor;

    private bool fireDelay;
    public float timeDelay;

    private GameManager manager;

    void Start()
    {
        fireDelay = true;

        manager = GameObject.Find("Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = anchor.transform.position;

        if (manager.gameRunning)
        {
            if (Input.GetKey(KeyCode.J))
            {
                transform.Rotate(Vector3.forward, turnSpeed * -1 * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.L))
            {
                transform.Rotate(Vector3.forward, turnSpeed * Time.deltaTime);
            }

            if (Input.GetKeyDown(KeyCode.K) && fireDelay)
            {
                fireDelay = false;
                StartCoroutine(TonkProcess());
            }



            //Controlber Contogs

            if (Input.GetButton("Left"))
            {
                transform.Rotate(Vector3.forward, turnSpeed * Time.deltaTime);
            }

            if (Input.GetButton("Right"))
            {
                transform.Rotate(Vector3.forward, turnSpeed * -1 * Time.deltaTime);
            }

            if (Input.GetButtonDown("Shoot") && fireDelay)
            {
                fireDelay = false;
                StartCoroutine(TonkProcess());
            }
        }
    }

    IEnumerator TonkProcess()
    {
        Instantiate(shell, shooter.transform.position, shooter.transform.rotation);
        yield return new WaitForSeconds(timeDelay);
        fireDelay = true;
    }
}
