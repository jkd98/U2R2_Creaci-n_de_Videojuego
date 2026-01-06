using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class FruitCollected : MonoBehaviour
{
    public AudioSource fruitSound;

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

            // Reproducir el sonido de recolección de fruta
            fruitSound.Play();
        }
    }
}
