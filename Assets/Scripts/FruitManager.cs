using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FruitManager : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        AllFruitsCollected();
    }

    void AllFruitsCollected()
    {
        if (transform.childCount == 0)
        {
            Debug.Log("¡Todas las frutas recolectadas!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
