using UnityEngine;
 
public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 5;
    private int currentHealth;
 
    void Awake() => currentHealth = maxHealth;
 
    public void TakeDamage(int dmg)
    {
        currentHealth -= dmg;
        Debug.Log("Player prend " + dmg + " dégâts. HP restants = " + currentHealth);
        if (currentHealth <= 0) Die();
    }
 
    void Die()
    {
        Debug.Log("Player est mort !");
        // Ici : désactiver le joueur, lancer une animation, recharger la scène, etc.
    }
}