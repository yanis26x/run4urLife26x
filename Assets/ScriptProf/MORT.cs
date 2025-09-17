using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class MORT : MonoBehaviour
{

    public int damage = 1;

    private void Reset()
    {
        var col = GetComponent<Collider2D>();
        col.isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (!other.CompareTag("Player")) return;

        var pm = other.GetComponent<PlayerMove>();
        if (pm != null) pm.TakeDamage(); 


        var hp = other.GetComponent<PlayerHealth>();
        if (hp != null) hp.TakeDamage(damage);
    }
}
