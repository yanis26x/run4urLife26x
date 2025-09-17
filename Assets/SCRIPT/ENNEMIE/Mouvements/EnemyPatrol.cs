using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class EnemyPatrol : MonoBehaviour
{
    public float speed = 2f;          
    public float range = 3f;          

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private bool goingRight = true;
    private float leftLimit;
    private float rightLimit;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

        // limites
        leftLimit = transform.position.x - range;
        rightLimit = transform.position.x + range;
    }

    void FixedUpdate()
    {
        // direction selon le bool
        float dir = goingRight ? 1f : -1f;
        rb.linearVelocity = new Vector2(dir * speed, rb.linearVelocity.y);

        // mm direction que le mouvement
        sr.flipX = goingRight;

        // inverse la direction si atteint une limite
        if (goingRight && transform.position.x >= rightLimit)
        {
            goingRight = false;
        }
        else if (!goingRight && transform.position.x <= leftLimit)
        {
            goingRight = true;
        }
    }
}
