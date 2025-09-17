using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // Clip audio à jouer quand le joueur saute (assigné dans l’Inspector)
    [SerializeField] AudioClip sfxJump;
    [SerializeField] private AudioClip sfxHurt;


    // Composant AudioSource qui jouera les sons
    private AudioSource audioSource;

    // Valeur d’entrée horizontale (−1 = gauche, 0 = immobile, 1 = droite)
    private float x;
    // Composant pour gérer l’affichage du sprite (retourner à gauche/droite)
    private SpriteRenderer spriteRenderer;
    // Composant pour gérer les animations du joueur
    private Animator animator;
    // Composant physique pour gérer les forces (notamment le saut)
    private Rigidbody2D rb;

    // Indique si le joueur doit sauter à la prochaine frame physique
    private bool jump = false;

    // ------------- ajout part 26x ---------------------
        [Header("Ground Check")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius = 0.2f;
    [SerializeField] private LayerMask groundLayer;
    private bool isGrounded;



    void Awake()
    {
        // Récupère les composants nécessaires attachés au GameObject
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        // Méthode appelée au lancement, vide ici mais disponible pour init
    }

    // Update est appelé une fois par frame (logique liée aux entrées joueur)
    void Update()
    {
        // ---- Déplacement horizontal ----
        x = Input.GetAxis("Horizontal"); // récupère l’input clavier/flèches
        animator.SetFloat("Speed", Mathf.Abs(x)); // anime la marche selon vitesse
        transform.Translate(Vector2.right * 7f * Time.deltaTime * x); // déplace le joueur

        // ---- Orientation du sprite ----
        if (x > 0f) { spriteRenderer.flipX = false; } // regarde à droite
        if (x < 0f) { spriteRenderer.flipX = true; }  // regarde à gauche

        // ------------- ajout part 26x ---------------------
                // ---- Détection sol ----
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        animator.SetBool("isGrounded", isGrounded);


        // ---- saut ----

        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space))
{
    jump = true;
}



        // ---- Animation d’attaque ----
        if (Input.GetKey(KeyCode.Space))
        {
            animator.SetBool("Attack", true); // lance l’animation
        }
        else
        {
            animator.SetBool("Attack", false); // arrête l’animation
        }
    }

    // FixedUpdate est appelé à chaque frame physique (idéal pour Rigidbody)
    private void FixedUpdate()
    {
        // Déplacement horizontal répété ici (⚠ doublon avec Update)

        transform.Translate(Vector2.right * 7f * Time.deltaTime * x);




        // --------- saut fixedUpdate Remplacer par Version 26x -----------
                // ---- Saut ----
        if (jump) // si le flag est actif
        {
            jump = false; 

            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f); // reset la vitesse verticale
            rb.AddForce(Vector2.up * 900f); //la force

            if (sfxJump && audioSource) audioSource.PlayOneShot(sfxJump);

            animator.ResetTrigger("DoJump");
            animator.SetTrigger("DoJump"); // lance l’anim Jump
        }




    }


    // ------------- methode anim Hurt 26x ---------------------
    public void TakeDamage()
{
    animator.ResetTrigger("Hurt");
    animator.SetTrigger("Hurt");

    if (sfxHurt && audioSource)
    {
        audioSource.PlayOneShot(sfxHurt);
    }
}


    // ------------- methode detection de Trigger 26x ---------------------
    private void OnTriggerEnter2D(Collider2D other)
{
    // Si l’objet a le tag "Trap"
    if (other.CompareTag("Trap"))
    {
        TakeDamage();  // lance anim Hurt
    }
}


    

}