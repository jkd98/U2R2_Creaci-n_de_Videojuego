using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private PlatformEffector2D effector;
    public float waitTime = 0.5f;
    private float waitedTime;
    void Start()
    {
        effector = GetComponent<PlatformEffector2D>();
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            waitedTime = waitTime;
            Debug.Log("Reset");
            Debug.Log(waitedTime);
        }

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            if (waitedTime <= 0)
            {
                Debug.Log("Changed");
                Debug.Log(waitedTime);
                effector.rotationalOffset = 180f;
                waitedTime = waitTime;
            }
            else
            {
                Debug.Log("Waiting");
                Debug.Log(waitedTime);
                waitedTime -= Time.deltaTime;
            }
        }

        if (Input.GetKey(KeyCode.Space))
        {
            effector.rotationalOffset = 0f;
        }
    }
}
