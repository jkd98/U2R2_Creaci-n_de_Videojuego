using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeDoorSkins : MonoBehaviour
{
    // refrencia al panel de skins
    public GameObject skinPanel;
    private bool isInDoor = false;
    public GameObject player;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInDoor = true;
            skinPanel.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInDoor = false;
            skinPanel.SetActive(false);
        }
    }

    public void SetPlayerFrog()
    {
        PlayerPrefs.SetString("PlayerSkin", "Frog");
        ResetPlayerSkin();
    }

    public void SetPlayerMaskDude()
    {
        PlayerPrefs.SetString("PlayerSkin", "MaskDude");
        ResetPlayerSkin();
    }

    public void SetPlayerPinkMan()
    {
        PlayerPrefs.SetString("PlayerSkin", "PinkMan");
        ResetPlayerSkin();
    }

    void ResetPlayerSkin()
    {
        skinPanel.SetActive(false);
        player.GetComponent<PlayerSelect>().ChangePlayerInMenu();
    }
}
