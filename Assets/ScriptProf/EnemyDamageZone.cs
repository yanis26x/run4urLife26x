using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class EnemyDamageZone : MonoBehaviour
{
    [Header("Dégâts infligés au joueur")]
    public int damage = 1;

    private void Reset()
    {
        // on s'assure que ce collider sert bien de zone de dommage
        var col = GetComponent<Collider2D>();
        col.isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Si l’objet a le tag "Player"
        if (!other.CompareTag("Player")) return;

        // 1) Lance l’anim/sfx Hurt du joueur (réutilise ta méthode existante)
        var pm = other.GetComponent<PlayerMove>();
        if (pm != null) pm.TakeDamage();  // lance anim Hurt + sfx

        // 2) Enlève des PV au joueur (script PlayerHealth que tu as déjà)
        var hp = other.GetComponent<PlayerHealth>();
        if (hp != null) hp.TakeDamage(damage);
    }
}
