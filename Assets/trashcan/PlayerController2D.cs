using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class PlayerController2D : MonoBehaviour
{
    [Header("Mouvement")]
    [SerializeField] private float speed = 6f;
    [SerializeField] private float jumpForce = 14f;

    [Header("Sol")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius = 0.15f;
    [SerializeField] private LayerMask groundLayer; // assigne "Ground" layer aux tiles (voir étape 6)

    private Rigidbody2D rb;
    private Animator anim;
    private bool isGrounded;
    private float inputX;
    private SpriteRenderer sr;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // input
        inputX = Input.GetAxisRaw("Horizontal"); // A/D ou Flèches

        // flip visuel
        if (inputX != 0) sr.flipX = inputX < 0;

        // saut
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }

        // Animator params
        anim.SetFloat("Speed", Mathf.Abs(rb.linearVelocity.x));
        anim.SetBool("IsGrounded", isGrounded);
        anim.SetFloat("Yvel", rb.linearVelocity.y);
    }

    void FixedUpdate()
    {
        // mouvement horizontal
        rb.linearVelocity = new Vector2(inputX * speed, rb.linearVelocity.y);

        // détection sol
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }

    void OnDrawGizmosSelected()
    {
        if (groundCheck == null) return;
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}
