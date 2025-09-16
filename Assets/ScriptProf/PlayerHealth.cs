using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

 
public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 5;
    private int currentHealth;

     [Header("UI")]
     public Text VieUI;
 
    // void Awake() => currentHealth = maxHealth;

    void Awake(){
        currentHealth = maxHealth;
        UpdateVieUI();
    }
 
    public void TakeDamage(int dmg)
    {
        currentHealth -= dmg;
        Debug.Log("Player prend " + dmg + " dégâts. HP restants = " + currentHealth);
        UpdateVieUI();
        if (currentHealth <= 0) Die();
    }
 
    void Die()
    {
        Debug.Log("Player est mort !");
        // Ici : désactiver le joueur, lancer une animation, recharger la scène, etc.
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void UpdateVieUI(){
        if(VieUI != null)
            VieUI.text = "HP: " + currentHealth + "/" + maxHealth;
    }
}