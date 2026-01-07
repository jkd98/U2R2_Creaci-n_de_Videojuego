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

    // Para las particulas
    public GameObject dustLeft;
    public GameObject dustRight;

    // dash de movimiento (opcional)
    public float dashCooldown = 2.0f; //para esperar entre dashes
    public GameObject dashEffectParticle; //particulas de dash
    public float dashSpeed = 30.0f; //velocidad de dash

    // wall
    bool isTouchingFront = false;
    bool isWallSliding = false;
    public float wallSlidingSpeed = 0.75f;
    bool isTouchingR = false;
    bool isTouchingL = false;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>(); //obtiene referencia de el componente
    }

    void Update()
    {
        dashCooldown -= Time.deltaTime; //reduce el cooldown del dash
        if (Input.GetKey("space") && !isWallSliding)
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
            dustLeft.SetActive(false);
            dustRight.SetActive(false);
        }

        if (rb2d.velocity.y < 0)
        {
            animator.SetBool("Falling", true);
        }
        else if (rb2d.velocity.y > 0)
        {
            animator.SetBool("Falling", false);
        }

        if (isTouchingFront && !CheckGround.isGrounded)
        {
            isWallSliding = true;
        }
        else
        {
            isWallSliding = false;
        }

        if (isWallSliding)
        {
            animator.Play("Wall");
            rb2d.velocity = new Vector2(rb2d.velocity.x, Mathf.Clamp(rb2d.velocity.y, -wallSlidingSpeed, float.MaxValue));
        }

    }

    void FixedUpdate()
    {
        if (Input.GetKey("d") || Input.GetKey("right") && !isTouchingR)
        {
            rb2d.velocity = new Vector2(runSpeed, rb2d.velocity.y);
            spriteRenderer.flipX = false; // mirar a la derecha
            animator.SetBool("Run", true);
            if (CheckGround.isGrounded)
            {
                dustLeft.SetActive(true);
                dustRight.SetActive(false);
            }

            if (Input.GetKey("e") && dashCooldown <= 0)
            {
                Dash();
            }

        }
        else if (Input.GetKey("e") && dashCooldown <= 0)
        {
            Dash();
        }
        else if (Input.GetKey("a") || Input.GetKey("left") && !isTouchingL)
        {
            rb2d.velocity = new Vector2(-runSpeed, rb2d.velocity.y);
            spriteRenderer.flipX = true; // mirar a la izquierda
            animator.SetBool("Run", true);
            if (CheckGround.isGrounded)
            {
                dustLeft.SetActive(false);
                dustRight.SetActive(true);

            }
            if (Input.GetKey("e") && dashCooldown <= 0)
            {
                Dash();
            }
        }
        else
        {
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
            animator.SetBool("Run", false);
            dustLeft.SetActive(false);
            dustRight.SetActive(false);
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

    public void Dash()
    {
        GameObject dashObject;
        dashObject = Instantiate(dashEffectParticle, transform.position, transform.rotation); // crea las particulas en la posicion del jugador
        if (spriteRenderer.flipX)
        {
            //Esta mirando a la derecha
            rb2d.AddForce(Vector2.left * dashSpeed, ForceMode2D.Impulse);
        }
        else
        {
            //Esta mirando a la izquierda
            rb2d.AddForce(Vector2.right * dashSpeed, ForceMode2D.Impulse);
        }
        dashCooldown = 2.0f; //resetea el cooldown
        Destroy(dashObject, 1f); //destruye las particulas despues de 0.5 segundos
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("WallRight"))
        {
            isTouchingFront = true;
            isTouchingR = true;
        }

        if (collision.gameObject.CompareTag("WallLeft"))
        {
            isTouchingFront = true;
            isTouchingL = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
            isTouchingFront = false;
            isTouchingR = false;
            isTouchingL = false;
    }
}
