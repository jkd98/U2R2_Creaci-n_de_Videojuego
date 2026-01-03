using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        }
    }
}
