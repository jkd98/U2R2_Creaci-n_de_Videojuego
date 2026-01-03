using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class DamageObject : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Jugador dañado por el objeto dañino.");
            Destroy(collision.gameObject);
        }
    }
}
