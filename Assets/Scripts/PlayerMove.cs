using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float runSpeed = 2.0f;
    public float jumpSpeed = 3.0f;
    Rigidbody2D rb2d; // referencia al rigidbody

    // Para salto mejorado
    public bool betterJump = false;
    public float fallMultiplier = 0.5f;
    public float lowJumpMultiplier = 1f;

    // Para animaciones
    public SpriteRenderer spriteRenderer; // referencia al sprite renderer del componente
    public Animator animator; // referencia al animator del componente

    // Para doble salto
    public float doubleJumpSpeed = 2.5f; // Para que el doble salto sea un poco más bajo
    private bool canDoubleJump = false;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>(); //obtiene referencia de el componente
    }

    void Update()
    {
        if (Input.GetKey("space"))
        {
            if (CheckGround.isGrounded) // Si está en el suelo
            {
                canDoubleJump = true; // Resetea la posibilidad de doble salto
                rb2d.velocity = new Vector2(rb2d.velocity.x, jumpSpeed);
            }
            else
            {
                if (Input.GetKeyDown("space"))
                {
                    if (canDoubleJump)
                    {
                        animator.SetBool("DoubleJump", true);
                        rb2d.velocity = new Vector2(rb2d.velocity.x, doubleJumpSpeed);
                        canDoubleJump = false; // Desactiva la posibilidad de otro doble salto
                    }
                }
            }
        }

        // Animaciones de salto
        if (CheckGround.isGrounded)
        {
            animator.SetBool("Jump", false);
            animator.SetBool("DoubleJump", false);
            animator.SetBool("Falling", false);

        }
        else
        {
            animator.SetBool("Jump", true);
            animator.SetBool("Run", false);
        }

        if (rb2d.velocity.y < 0)
        {
            animator.SetBool("Falling", true);
        }
        else if (rb2d.velocity.y > 0)
        {
            animator.SetBool("Falling", false);
        }
    }

    void FixedUpdate()
    {
        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            rb2d.velocity = new Vector2(runSpeed, rb2d.velocity.y);
            spriteRenderer.flipX = false; // mirar a la derecha
            animator.SetBool("Run", true);
        }
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            rb2d.velocity = new Vector2(-runSpeed, rb2d.velocity.y);
            spriteRenderer.flipX = true; // mirar a la izquierda
            animator.SetBool("Run", true);
        }
        else
        {
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
            animator.SetBool("Run", false);
        }

        if (betterJump)  // Si esta opción está activada
        {
            // 1. CAÍDA MÁS RÁPIDA
            if (rb2d.velocity.y < 0)  // Si el personaje está cayendo (velocidad vertical negativa)
            {
                rb2d.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier) * Time.deltaTime;
            }
            // 2. SALTO CORTO
            else if (rb2d.velocity.y > 0 && !Input.GetKey("space"))  // Si está subiendo Y NO se mantiene presionado espacio
            {
                rb2d.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier) * Time.deltaTime;
            }
        }
    }
}
