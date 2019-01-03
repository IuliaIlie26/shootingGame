using UnityEngine;


public class EnemyHealth : MonoBehaviour {

    public int startingHealth = 100;            
    public int currentHealth;                  
    public float sinkSpeed = 2.5f;            
    public int scoreValue = 10;               
    public AudioClip deathClip;
    GameObject player;
    Animator anim;                            
    AudioSource enemyAudio;                   
    CapsuleCollider capsuleCollider;           
    bool isDead;
    PlayerHealth playerHealth;

    void Awake()
    {
        anim = GetComponent<Animator>();
        enemyAudio = GetComponent<AudioSource>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        currentHealth = startingHealth;
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
    }
    public void TakeDamage(int amount, Vector3 hitPoint)
    {
        if (isDead)
          return;

        enemyAudio.Play();
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            Death();
        }
    }
    
    void Death()
    {
        if (playerHealth.currentHealth <= 95)
        {
            playerHealth.currentHealth += 5;
        }
        ScoreManager.score += scoreValue;
        isDead = true;
        capsuleCollider.isTrigger = true;
        anim.SetTrigger("dead");
        enemyAudio.clip = deathClip;
        enemyAudio.Play();
    }
}
