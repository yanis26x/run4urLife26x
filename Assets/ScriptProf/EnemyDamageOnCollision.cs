using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class EnemyDamageOnCollision : MonoBehaviour
{
    [Header("Dégâts infligés au joueur")]
    public int damage = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.collider.CompareTag("Player")) return;

        // 1) Lancer anim/sfx Hurt du joueur
        var pm = collision.collider.GetComponent<PlayerMove>();
        if (pm != null) pm.TakeDamage();

        // 2) Enlever des PV
        var hp = collision.collider.GetComponent<PlayerHealth>();
        if (hp != null) hp.TakeDamage(damage);
    }
}
