using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class BonusVie : MonoBehaviour
{
  
    public AudioClip pickupSfx;   

    private void Awake()
    {
        GetComponent<Collider2D>().isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            // +1
            PlayerHealth hp = other.GetComponent<PlayerHealth>();
            if (hp != null)
            {
                hp.AddLife(1);
            }

           
            if (pickupSfx != null)
            {
                AudioSource.PlayClipAtPoint(pickupSfx, transform.position); // sfx 
            }

            // disparrt
            Destroy(gameObject);
        }
    }
}
