using UnityEngine;
using UnityEngine.UI;


public class PlayerHealth : MonoBehaviour {

    public int startingHealth = 100;                           
    public int currentHealth;                                 
    public Slider healthSlider;                              
    public Image damageImage;                                
    public AudioClip deathClip;                                
    public float flashSpeed = 5f;                            
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);                                   
    AudioSource playerAudio;                                   
    PlayerMovement playerMovement;                             
    PlayerShooting playerShooting;                                                                    
    bool damaged;                                              

    void Awake()
    {
        playerAudio = GetComponent<AudioSource>();
        playerMovement = GetComponent<PlayerMovement>();
       playerShooting = GetComponentInChildren<PlayerShooting>();

        currentHealth = startingHealth;
    }

    void Update()
    {
        damageImage.color = damaged ? flashColour : Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);

        damaged = false;
    }

    public void TakeDamage(int amount)
    {
        damaged = true;
        currentHealth -= amount;
        healthSlider.value = currentHealth;
        playerAudio.Play();
        if (currentHealth <= 0)
        {
            Death();
        }
    }

    void Death()
    {
        playerShooting.DisableEffects();
        playerAudio.clip = deathClip;
        playerAudio.Play();
        playerMovement.enabled = false;
        playerShooting.enabled = false;
    }
}
