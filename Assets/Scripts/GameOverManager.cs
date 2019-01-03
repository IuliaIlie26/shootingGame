using UnityEngine.SceneManagement;
using UnityEngine;

public class GameOverManager : MonoBehaviour {

    public PlayerHealth playerHealth;       
    public float restartDelay = 5f;
    public AudioSource audioSource;
    float restartTimer;
    Animator anim;
    public GameObject gameOverPanel;
    
    void Awake()
    {
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        gameOverPanel = GameObject.FindGameObjectWithTag("GameController");
        gameOverPanel.SetActive(false);
    }
    void Update()
    {
      if (playerHealth.currentHealth <= 0)
        {
            audioSource.Play();
            anim.SetTrigger("GameOver");
            gameOverPanel.SetActive(true);
            restartTimer += Time.deltaTime;
            if (restartTimer >= restartDelay)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
            }
        }
    }

}
