using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("Health Parameters")]
    [SerializeField] private float _maxHealth = 100f;
    
    public float currentHealth;

    void Start()
    {
        currentHealth = _maxHealth;
    }

    void Update()
    {
        Die();
    }

    // Handles restarting the game when the player dies
    void Die()
    {
        // Check if health has dropped to zero
        if(currentHealth <= 0)
            // Reload the scene, effectively restarting the level
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}



