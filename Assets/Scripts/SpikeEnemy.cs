using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeEnemy : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Jugador dañado por el enemigo.");
            Destroy(collision.gameObject);
        }
    }
}
