using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    public float spee = 0.5f;
    private float waitTime; // detenga en el punto que al que llega
    public float startWaitTime = 2f; // tiempo que espera en cada punto
    private int i; //punto al que se dirige
    public Transform[] moveSpots; //puntos a los que se mueve el enemigo


    // Start is called before the first frame update
    void Start()
    {
        waitTime = startWaitTime;
    }

    // Update is called once per frame
    void Update()
    {
        // hacia (current, target, maxDistanceDelta)
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[i].position, spee * Time.deltaTime);
        if (Vector2.Distance(transform.position, moveSpots[i].position) < 0.2f)
        {
            if (waitTime <= 0)
            {
                if (moveSpots[i] != moveSpots[moveSpots.Length - 1])
                {
                    i++;
                }
                else
                {
                    i = 0;
                }
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.parent = transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.parent = null;
        }
    }
}
