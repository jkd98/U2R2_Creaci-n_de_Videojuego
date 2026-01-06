using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject optionsPanel;

    public void OptionsPanel()
    {
        Time.timeScale = 0f;
        optionsPanel.SetActive(true);
    }

    public void ReturnPanel()
    {
        Time.timeScale = 1f;
        optionsPanel.SetActive(false);
    }

    // Para abrir otras opciones en el futuro
    public void AnotherOptions()
    {
        //sound
        //graphics
    }

    public void GoMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
