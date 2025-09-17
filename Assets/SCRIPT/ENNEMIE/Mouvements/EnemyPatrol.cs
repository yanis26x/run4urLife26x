using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class EnemyPatrol : MonoBehaviour
{
    public float speed = 2f;          
    public float range = 3f;          

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private bool AdroiteOuPas = true;
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
        float dir = AdroiteOuPas ? 1f : -1f;
        rb.linearVelocity = new Vector2(dir * speed, rb.linearVelocity.y);

        // mm direction que le mouvement
        sr.flipX = AdroiteOuPas;

        // inverse la direction
        if (AdroiteOuPas && transform.position.x >= rightLimit)
        {
            AdroiteOuPas = false;
        }
        else if (!AdroiteOuPas && transform.position.x <= leftLimit)
        {
            AdroiteOuPas = true;
        }
    }
}
