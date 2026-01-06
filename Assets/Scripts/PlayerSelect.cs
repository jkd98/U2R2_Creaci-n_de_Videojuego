using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelect : MonoBehaviour
{
    public bool enableSelectPlayer;
    public enum Player { Frog, MaskDude, PinkMan };
    public Player selectedPlayer;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public RuntimeAnimatorController[] playerControllers;
    public Sprite[] playerSpriteRenderers;
    void Start()
    {
        if (enableSelectPlayer)
        {
            switch (selectedPlayer)
            {
                case Player.Frog:
                    animator.runtimeAnimatorController = playerControllers[0];
                    spriteRenderer.sprite = playerSpriteRenderers[0];
                    break;
                case Player.MaskDude:
                    animator.runtimeAnimatorController = playerControllers[1];
                    spriteRenderer.sprite = playerSpriteRenderers[1];
                    break;
                case Player.PinkMan:
                    animator.runtimeAnimatorController = playerControllers[2];
                    spriteRenderer.sprite = playerSpriteRenderers[2];
                    break;
            }
        }
        else
        {
            ChangePlayerInMenu();
        }

    }

    public void ChangePlayerInMenu()
    {
        switch (PlayerPrefs.GetString("PlayerSkin"))
        {
            case "Frog":
                animator.runtimeAnimatorController = playerControllers[0];
                spriteRenderer.sprite = playerSpriteRenderers[0];
                break;
            case "MaskDude":
                animator.runtimeAnimatorController = playerControllers[1];
                spriteRenderer.sprite = playerSpriteRenderers[1];
                break;
            case "PinkMan":
                animator.runtimeAnimatorController = playerControllers[2];
                spriteRenderer.sprite = playerSpriteRenderers[2];
                break;
        }
    }


}
