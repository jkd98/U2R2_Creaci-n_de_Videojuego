using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
// libreria para referencia a text mesh pro
using TMPro;

public class FruitManager : MonoBehaviour
{
    public TextMeshProUGUI fruitText;
    public GameObject transition;

    public TextMeshProUGUI totalFruitsText;
    public TextMeshProUGUI recolectedFruitsText;
    private int totalFruits;

    void Start()
    {
        totalFruits = transform.childCount;
        totalFruitsText.text = totalFruits.ToString();
    }
    void Update()
    {
        AllFruitsCollected();
        recolectedFruitsText.text = transform.childCount.ToString();
    }

    void AllFruitsCollected()
    {
        if (transform.childCount == 0)
        {
            Debug.Log("¡Todas las frutas recolectadas!");
            fruitText.gameObject.SetActive(true);
            transition.SetActive(true);
            Invoke("ChangeScene", 1f);
        }
    }

    private void ChangeScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
