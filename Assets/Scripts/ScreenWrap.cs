using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWrap : MonoBehaviour
{
    //Base Values
    private float xLimit = 26;
    private float zLimit = 15;

    //Modified Values
    private float xLimitPositive;
    private float zLimitPositive;
    private float xLimitNegative;
    private float zLimitNegative;

    //Positioning Values
    private float xPos;
    private float zPos;

    void Start()
    {
        //Sets the Positive Modified Values
        xLimitPositive = xLimit;
        zLimitPositive = zLimit;

        //Sets the Negative Modified Values
        xLimitNegative = xLimit * -1;
        zLimitNegative = zLimit * -1;
    }

    void Update()
    {
        //Tracks the player's position
        xPos = transform.position.x;
        zPos = transform.position.z;

        //If a Modified Value is passed, teleport to the other side.
        if (xPos >= xLimitPositive)
        {
            transform.position = new Vector3(xLimitNegative + 1, transform.position.y, transform.position.z);
        }

        if (xPos <= xLimitNegative)
        {
            transform.position = new Vector3(xLimitPositive - 1, transform.position.y, transform.position.z);
        }

        if (zPos >= zLimitPositive)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zLimitNegative + 1);
        }

        if (zPos <= zLimitNegative)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zLimitPositive - 1);
        }
    }
}
