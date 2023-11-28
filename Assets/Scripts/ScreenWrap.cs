using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWrap : MonoBehaviour
{
    private float xLimit = 26;
    private float zLimit = 15;

    private float xLimitPositive;
    private float zLimitPositive;
    private float xLimitNegative;
    private float zLimitNegative;

    private float xPos;
    private float zPos;

    void Start()
    {
        xLimitPositive = xLimit;
        zLimitPositive = zLimit;

        xLimitNegative = xLimit * -1;
        zLimitNegative = zLimit * -1;
    }

    void Update()
    {
        xPos = transform.position.x;
        zPos = transform.position.z;

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
