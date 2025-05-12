using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private SFXController sFXController;
    private SpriteRenderer spriteRenderer;

    [Header("Movimiento")]
    private Rigidbody2D _rigidbody2D;
    public Vector2 inputMovement;
    public float speed;
    public float verticalSpeed = 5f;
    private float verticalInput;

    [Header("Teletransporte y Salto")]
    public float distance = 4.29f;
    public Transform playerTransform;
    public float jumpForce = 5f;
    public float horizontalJumpForce = 7f;
    private bool isOnLeftSide = true;

    [Header("Suelo y Gravedad")]
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    private bool isGrounded;

    [Header("Vida y Daño")]
    public int maxHealth = 5;
    private int currentHealth;
    public TextMeshProUGUI textvida;

    [Header("Puntaje")]
    private float playTime = 0f;

    private Pausa pausaController; 

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody2D.gravityScale = 0;
        currentHealth = maxHealth;
        UpdateHealthUI();
        sFXController = FindObjectOfType<SFXController>();

        pausaController = FindObjectOfType<Pausa>(); 

        if (sFXController == null)
        {
            Debug.LogError("SFXController no encontrado en la escena.");
        }
        spriteRenderer.flipX = true;

    }

    private void Update()
    {
        playTime += Time.deltaTime;
        CheckIfGrounded();
    }

    private void CheckIfGrounded()
    {
        float distanceToWall;

        if (isOnLeftSide)
        {
            distanceToWall = Mathf.Abs(transform.position.x - -0.844f);
        }
        else
        {
            distanceToWall = Mathf.Abs(transform.position.x - 0.844f);
        }

        isGrounded = distanceToWall < 0.05f;
    }

    private void Teleport()
    {
        if (pausaController.IsPaused()) 
        {
            return; 
        }

        Vector2 targetPosition = new Vector2(-transform.position.x, transform.position.y);
        
        transform.position = targetPosition;
        sFXController.PlayTeleport();
        isOnLeftSide = !isOnLeftSide;
        if (isOnLeftSide)
        {
            spriteRenderer.flipX = true;  
            spriteRenderer.flipY = verticalInput < 0; 
        }
        else
        {
            spriteRenderer.flipX = false; 
            spriteRenderer.flipY = verticalInput < 0; 
        }
    }

    private void Move(float direction)
    {
        if (direction != 0)
        {
            Vector3 moveDirection;

            if (direction > 0)
            {
                moveDirection = Vector3.up;

                if (isOnLeftSide)
                {
                    spriteRenderer.flipX = true;
                    spriteRenderer.flipY = false;
                }
                else
                {
                    spriteRenderer.flipX = false;
                    spriteRenderer.flipY = false;
                }
            }
            else
            {
                moveDirection = Vector3.down;

                if (isOnLeftSide)
                {
                    spriteRenderer.flipX = true;
                    spriteRenderer.flipY = true;
                }
                else
                {
                    spriteRenderer.flipX = false;
                    spriteRenderer.flipY = true;
                }
            }

            playerTransform.position += moveDirection * verticalSpeed * Time.fixedDeltaTime;
        }
    }

    private void Jump()
    {
        _rigidbody2D.velocity = Vector2.zero;

        if (Mathf.Abs(inputMovement.x) > 0.01f)
        {
            if (isOnLeftSide)
            {
                _rigidbody2D.AddForce(new Vector2(-horizontalJumpForce, jumpForce), ForceMode2D.Impulse);
            }
            else
            {
                _rigidbody2D.AddForce(new Vector2(horizontalJumpForce, jumpForce), ForceMode2D.Impulse);
            }
        }
        else
        {
            if (isOnLeftSide)
            {
                _rigidbody2D.AddForce(new Vector2(-horizontalJumpForce, 0), ForceMode2D.Impulse);
            }
            else
            {
                _rigidbody2D.AddForce(new Vector2(horizontalJumpForce, 0), ForceMode2D.Impulse);
            }
        }
        sFXController.PlayJumpSound();
    }

    private void ApplyWallAttraction()
    {
        float targetXPosition;
        if (isOnLeftSide)
        {
            targetXPosition = -0.844f;
        }
        else
        {
            targetXPosition = 0.844f;
        }
        Vector2 attractionForce = new Vector2(targetXPosition - transform.position.x, 0);
        _rigidbody2D.AddForce(attractionForce * 10f);
    }

    public void ReadDirection(InputAction.CallbackContext context)
    {
        verticalInput = context.ReadValue<float>();
    }

    public void ReadTeleport(InputAction.CallbackContext context)
    {
        if (context.performed && !pausaController.IsPaused())
        {
            Teleport();
        }
    }

    public void ReadJump(InputAction.CallbackContext context)
    {
        if (context.performed && isGrounded)
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        Move(verticalInput);
        if (!isGrounded)
        {
            ApplyWallAttraction();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            sFXController.PlayDamageSound();

            sFXController.PlayDamageSound(); 

            TakeDamage(1);
            Destroy(collision.gameObject);
        }
    }

    private void TakeDamage(int damage)
    {
        currentHealth -= damage;
        UpdateHealthUI();
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    private void UpdateHealthUI()
    {
        textvida.text = "LIFE: " + currentHealth.ToString(); 
    }

    private void Die()
    {

        Invoke("GameOver", 0.1f);

        Invoke("GameOver", 0.5f);

    }

    private void GameOver()
    {
        MusicManager.Instance.StopAllMusic();
        sFXController.PlayDeathSound();
        SceneManager.LoadScene("GameOver");
    }
}