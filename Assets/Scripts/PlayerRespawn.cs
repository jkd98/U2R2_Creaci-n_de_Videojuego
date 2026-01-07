using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRespawn : MonoBehaviour
{
    private float checkpointX;
    private float checkpointY;

    public Animator animator;

    // Para vidas
    public GameObject[] hearts;
    private int life;



    void Start()
    {
        life = hearts.Length;
        if (PlayerPrefs.GetFloat("checkpointX") != 0)
        {
            transform.position = new Vector2(PlayerPrefs.GetFloat("checkpointX"), PlayerPrefs.GetFloat("checkpointY"));
        }
    }

    void CheckLife()
    {
        if (life < 1)
        {
            Destroy(hearts[0].gameObject);
            animator.Play("Hit");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }
        else if (life < 2)
        {
            Destroy(hearts[1].gameObject);
            animator.Play("Hit");

        }
        else if (life < 3)
        {
            Destroy(hearts[2].gameObject);
            animator.Play("Hit");

        }

    }

    public void ReachedCheckPoint(float x, float y)
    {
        PlayerPrefs.SetFloat("checkpointX", x);
        PlayerPrefs.SetFloat("checkpointY", y);
    }

    public void PlayerDamage()
    {
        life--;
        CheckLife();
    }

}
