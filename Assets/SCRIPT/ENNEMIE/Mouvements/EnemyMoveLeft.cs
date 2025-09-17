using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMoveRight : MonoBehaviour
{

    public float speed = 2f;

    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // a droite
        rb.linearVelocity = new Vector2(speed, rb.linearVelocity.y);
    }
}
