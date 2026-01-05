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
        }
    }

    void Update()
    {
        if (inDoor && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Cargando nivel: " + levelName);
            SceneManager.LoadScene(levelName);
        }
    }

}
