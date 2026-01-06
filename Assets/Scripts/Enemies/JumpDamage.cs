using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;

public class JumpDamage : MonoBehaviour
{
    public Collider2D playerCollider;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public GameObject deathEffect;
    public float bounceForce = 2.5f;
    public int lifes = 2;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = (Vector2.up * bounceForce);
            LossesLifeAndHit();
            CheckLife();
        }
    }

    public void LossesLifeAndHit()
    {
        lifes--;
        animator.Play("Death");
    }

    public void CheckLife()
    {
        if (lifes == 0)
        {
            deathEffect.SetActive(true);
            spriteRenderer.enabled = false;
            Invoke("DestroyEnemy", 0.2f);
        }
    }

    public void DestroyEnemy()
    {
        Destroy(gameObject);
    }
}