using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;

    private Rigidbody2D rb;
    private Animator animator;
    private float moveInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Input horizontal (A/D ou ←/→)
        moveInput = Input.GetAxisRaw("Horizontal");

        // Animação de andar
        animator.SetBool("isWalking", moveInput != 0);

        // Virar o personagem conforme a direção
        if (moveInput > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (moveInput < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    void FixedUpdate()
    {
        // Movimento físico
        rb.linearVelocity = new Vector2(moveInput * speed, rb.linearVelocity.y);
    }
}