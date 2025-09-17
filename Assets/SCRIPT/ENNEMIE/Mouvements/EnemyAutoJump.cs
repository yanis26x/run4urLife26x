using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyAutoJump : MonoBehaviour
{

    public float jumpSpeedY = 5f;   
    public float interval = 1f;     
    public bool requireGrounded = true;

    public float gravityScale = 3f; 

    public Transform groundCheck;   
    public float groundCheckRadius = 0.12f;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private float timer;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = gravityScale;
        timer = interval;
    }
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            if (!requireGrounded || IsGrounded())
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpSpeedY);
            }
            timer = interval;
        }}
    bool IsGrounded()
    {
        if (groundCheck == null) return true;
        return Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }

    void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }
}
