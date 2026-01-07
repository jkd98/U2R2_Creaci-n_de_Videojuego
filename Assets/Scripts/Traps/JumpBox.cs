using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBox : MonoBehaviour
{
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public GameObject brokenParts;
    public float jumpForce = 5f;
    public int lifes = 1;

    public GameObject boxCollider;
    public Collider2D col2D;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpForce;
            LooseLieAndHit();
        }
    }
    public void LooseLieAndHit()
    {
        lifes--;
        animator.Play("Hit");
        CheckLife();
    }
    public void CheckLife()
    {
        if (lifes <= 0)
        {
            boxCollider.SetActive(false);
            col2D.enabled = false;

            brokenParts.SetActive(true);
            spriteRenderer.enabled = false;
            Invoke("DestroyBox", 1f);
        }
    }
    public void DestroyBox()
    {
        Destroy(gameObject);
    }

}
