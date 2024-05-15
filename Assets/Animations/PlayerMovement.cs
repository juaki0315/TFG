using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 4f;

    private Rigidbody2D playerRb;
    private Vector2 moveInput;
    private Animator playerAnimator;

    [SerializeField] private LayerMask collisionLayer;
    private bool isColliding;

    void Start()
    {
        collisionLayer = LayerMask.GetMask("Limites");
        playerRb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        moveInput = new Vector2(moveX, moveY).normalized;

        playerAnimator.SetFloat("Horizontal", moveX);
        playerAnimator.SetFloat("Vertical", moveY);
        playerAnimator.SetFloat("Speed", moveInput.sqrMagnitude);

        if (moveInput.sqrMagnitude == 0f)
        {
            playerAnimator.SetFloat("Horizontal", 0f);
            playerAnimator.SetFloat("Vertical", 0f);
            playerAnimator.SetFloat("Speed", 0f);
        }
    }

    private void FixedUpdate()
    {
        playerRb.MovePosition(playerRb.position + moveInput * speed * Time.fixedDeltaTime);

        CheckCollisions(); // Verificar colisiones con la capa "limites"
    }

    private void CheckCollisions()
    {
        Collider2D playerCollider = GetComponent<Collider2D>(); // Obtener el collider del jugador

        isColliding = Physics2D.IsTouchingLayers(playerCollider, collisionLayer); // Verificar si hay colisiones en el área del jugador

        if (isColliding)
        {
            playerRb.velocity = Vector2.zero;
        }
    }
}
