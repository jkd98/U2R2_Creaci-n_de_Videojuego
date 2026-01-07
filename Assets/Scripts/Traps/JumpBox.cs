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

    public GameObject fruit;

    void Start()
    {
        fruit.SetActive(false);
        //llevar la fruta a fruit manager
        fruit.transform.SetParent(FindObjectOfType<FruitManager>().transform);
    }

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
            fruit.SetActive(true);
            boxCollider.SetActive(false);
            col2D.enabled = false;

            brokenParts.SetActive(true);
            spriteRenderer.enabled = false;
            Invoke("DestroyBox", 1f);
        }
    }
    public void DestroyBox()
    {
        //se destruye el padre que es el objeto completo
        Destroy(transform.parent.gameObject);
    }

}
