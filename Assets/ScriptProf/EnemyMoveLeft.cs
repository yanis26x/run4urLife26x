using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMoveLeft : MonoBehaviour
{
    [Header("Vitesse de déplacement")]
    public float speed = 2f;

    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // Toujours à gauche (axe X négatif)
        rb.linearVelocity = new Vector2(-speed, rb.linearVelocity.y);
    }
}
