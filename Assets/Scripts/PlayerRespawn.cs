using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRespawn : MonoBehaviour
{
    private float checkpointX;
    private float checkpointY;

    public Animator animator;
    void Start()
    {
        if (PlayerPrefs.GetFloat("checkpointX") != 0)
        {
            transform.position = new Vector2(PlayerPrefs.GetFloat("checkpointX"), PlayerPrefs.GetFloat("checkpointY"));
        }
    }

    public void ReachedCheckPoint(float x, float y)
    {
        PlayerPrefs.SetFloat("checkpointX",x);
        PlayerPrefs.SetFloat("checkpointY",y);
    }

    public void PlayerDamage()
    {
        animator.Play("Hit");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
