using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretControl : MonoBehaviour
{
    //The turret's rotation speed.
    public float turnSpeed;

    //The shell the tank fires
    public GameObject shell;

    //The point the shell comes from
    public GameObject shooter;

    //The spot that the turret anchors to the body
    public GameObject anchor;

    //Delay values
    public bool fireDelay;
    public float timeDelay;

    //Wewewewewewewewewewewewewe GameManager wawawawawawawawawawawawawa
    private GameManager manager;
    private AudioSource audioSource;

    void Start()
    {
        //Lets you shoot right off the bat
        fireDelay = true;

        manager = GameObject.Find("Manager").GetComponent<GameManager>();
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //Clings the turret to the anchor's position
        transform.position = anchor.transform.position;

        //While the game is running...
        if (manager.gameRunning)
        {
            //...holding J turns left...
            if (Input.GetKey(KeyCode.J))
            {
                transform.Rotate(Vector3.forward, turnSpeed * -1 * Time.deltaTime);
            }

            //...holding L turns right...
            if (Input.GetKey(KeyCode.L))
            {
                transform.Rotate(Vector3.forward, turnSpeed * Time.deltaTime);
            }

            //...pressing K while you are allowed to shoot fires a shell, and starts the delay process.
            if (Input.GetKeyDown(KeyCode.K) && fireDelay)
            {
                fireDelay = false;
                StartCoroutine(TonkProcess());
            }

            //Same thing as above, but with controller button inputs, on an Xbox controllers it should be X, A, and B.
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

            //Rotation noise figuring out
            if (Input.GetKey(KeyCode.J) && !audioSource.isPlaying)
            {
                audioSource.Play();
            }
            if (Input.GetKey(KeyCode.L) && !audioSource.isPlaying)
            {
                audioSource.Play();
            }

            if (Input.GetKeyUp(KeyCode.J))
            {
                audioSource.Stop();
            }
            if (Input.GetKeyUp(KeyCode.L))
            {
                audioSource.Stop();
            }
        }
    }

    //Simple process, just spawns a shell, waits a second, then lets you fire again.
    IEnumerator TonkProcess()
    {
        Instantiate(shell, shooter.transform.position, shooter.transform.rotation);
        yield return new WaitForSeconds(timeDelay);
        fireDelay = true;
    }
}
