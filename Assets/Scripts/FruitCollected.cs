using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitCollected : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // Desactivar el sprite de la fruta
            GetComponent<SpriteRenderer>().enabled = false;
            // Activar el collected animation hijo de la fruta
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            // findObjectOfType<FruitManager>().AllFruitsCollected();
            Destroy(gameObject, 0.5f); // Destruir el objeto fruta después de 0.5 segundos
        }
    }
}
