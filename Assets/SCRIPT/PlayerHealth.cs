using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

 
public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 5;
    private int currentHealth;

     public Text VieUI;
 

    void Awake(){
        currentHealth = maxHealth;
        UpdateVieUI(); // pour toujour afficher la bonne vie
    }
 
    public void TakeDamage(int dmg)
    {
        currentHealth -= dmg;
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
            VieUI.text = "vie restante : " + currentHealth;
    }

    public void AddLife(int amount) //pour quand tu rammasse un bonus vie ! (cherry)
{
    currentHealth = Mathf.Min(currentHealth + amount, maxHealth);
    UpdateVieUI();
}
}