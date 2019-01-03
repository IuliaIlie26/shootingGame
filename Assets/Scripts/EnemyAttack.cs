using UnityEngine;

public class EnemyAttack : MonoBehaviour {

    public int attackDamage = 10;
    float timer;
    public float timeBetweenAttacks = 0.5f;
    Animator anim;                            
    GameObject player;                         
    PlayerHealth playerHealth;                 
    EnemyHealth enemyHealth;                 
    bool playerInRange;                       

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        enemyHealth = GetComponent<EnemyHealth>();
        anim = GetComponent<Animator>();
   
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            playerInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {        
        if (other.gameObject == player)
        {
            playerInRange = false;
        }
        anim.SetBool("walk", true);
    }

    void Update()
    {
        timer += Time.deltaTime;
         if (timer >= timeBetweenAttacks && playerInRange && enemyHealth.currentHealth > 0)
        {
           Attack();
        } 
      
    }

    void Attack()
    {
        timer = 0f;
        anim.SetBool("attack", true);

        if (playerHealth.currentHealth > 0)
        {
            playerHealth.TakeDamage(attackDamage);
        }
    }   
}
