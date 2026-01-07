using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class OpenDoor : MonoBehaviour
{
    public TextMeshProUGUI startText;
    public string levelName;
    private bool inDoor = false;

    // Para el tiempo en puertas
    private float doorTime = 3f;
    private float startTime = 3f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            startText.gameObject.SetActive(true);
            inDoor = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            startText.gameObject.SetActive(false);
            inDoor = false;
            doorTime = startTime;
        }
    }

    void Update()
    {
        if (inDoor)
        {
            doorTime -= Time.deltaTime;
        }

        if (doorTime <= 0)
        {
            SceneManager.LoadScene(levelName);
        }

        if (inDoor && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Cargando nivel: " + levelName);
            SceneManager.LoadScene(levelName);
        }
    }

}
