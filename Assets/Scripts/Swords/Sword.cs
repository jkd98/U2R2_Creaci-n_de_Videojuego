using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    private BoxCollider2D boxColider;
    private SpriteRenderer playerSpriteRenderer; // elemento pdre 
    public Animator animator;
    public GameObject swordParent;
    void Start()
    {
        playerSpriteRenderer = transform.root.GetComponent<SpriteRenderer>();
        boxColider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) || Input.GetMouseButtonDown(0))
        {
            Attack();
        }

        if (playerSpriteRenderer.flipX)
        {
            swordParent.transform.rotation = Quaternion.Euler(0, -180, 0);
        }
        else
        {
            swordParent.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    public void Attack()
    {
        animator.Play("Attack");
        boxColider.enabled = true;
        Invoke("DisableColider", 0.3f);
    }

    public void DisableColider()
    {
        boxColider.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponentInParent<JumpDamage>().LossesLifeAndHit();
            boxColider.enabled = false;
        }
    }
}
