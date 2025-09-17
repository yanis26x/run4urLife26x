using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class EnemyDamageOnCollision : MonoBehaviour
{

    public int damage = 4;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.collider.CompareTag("Player")) return;

        //  animationnnn
        var pm = collision.collider.GetComponent<PlayerMove>();
        if (pm != null) pm.TakeDamage();

        // Enlever des PV
        var hp = collision.collider.GetComponent<PlayerHealth>();
        if (hp != null) hp.TakeDamage(damage);
    }
}
