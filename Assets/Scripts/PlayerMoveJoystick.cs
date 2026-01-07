using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveJoystick : MonoBehaviour
{

    //referencia al joystick
    private float horizontalMove = 0f;
    private float verticalMove = 0f;
    public Joystick joystick;

    public float runSpeed = 1.5f;
    public float jumpSpeed = 3.0f;
    Rigidbody2D rb2d; // referencia al rigidbody


    // Para animaciones
    public SpriteRenderer spriteRenderer; // referencia al sprite renderer del componente
    public Animator animator; // referencia al animator del componente

    // Para doble salto
    public float doubleJumpSpeed = 2.5f; // Para que el doble salto sea un poco más bajo
    private bool canDoubleJump = false;

    // Para las particulas
    public GameObject dustLeft;
    public GameObject dustRight;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>(); //obtiene referencia de el componente
    }

    void Update()
    {
        // amimaciones de correr
        if (horizontalMove > 0.1f)
        {
            spriteRenderer.flipX = false; // mirar a la derecha
            animator.SetBool("Run", true);
            if (CheckGround.isGrounded)
            {
                dustLeft.SetActive(true);
                dustRight.SetActive(false);

            }
        }
        else if (horizontalMove < -0.1f)
        {
            spriteRenderer.flipX = true; // mirar a la izquierda
            animator.SetBool("Run", true);
            if (CheckGround.isGrounded)
            {
                dustLeft.SetActive(false);
                dustRight.SetActive(true);

            }
        }
        else
        {
            animator.SetBool("Run", false);
            dustLeft.SetActive(false);
            dustRight.SetActive(false);
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

        if (rb2d.velocity.y < -0.1f)
        {
            animator.SetBool("Falling", true);
        }
        else if (rb2d.velocity.y > 0.1f)
        {
            animator.SetBool("Falling", false);
        }
    }

    void FixedUpdate()
    {
        horizontalMove = joystick.Horizontal * runSpeed;
        transform.position += new Vector3(horizontalMove, 0, 0) * Time.deltaTime * runSpeed;
    }

    public void Jump()
    {
        if (CheckGround.isGrounded) // Si está en el suelo
        {
            canDoubleJump = true; // Resetea la posibilidad de doble salto 
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpSpeed);
        }
        else
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
