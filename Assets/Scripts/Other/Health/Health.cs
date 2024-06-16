using UnityEngine;

public class Health : MonoBehaviour
{
    /// <summary>
    /// State of the object with health
    /// </summary>
    [SerializeField] private bool isDead = false;

    /// <summary>
    /// Current health of the object
    /// </summary>
    [SerializeField] public int currentHealth;

    /// <summary>
    /// Maximum health of the object
    /// </summary>
    [SerializeField] public int maxHealth;
    

    /// <summary>
    /// Start is called on the frame when a script is enabled
    /// </summary>
    private void Start()
    {
        currentHealth = maxHealth;
    }

    /// <summary>
    /// Initialization of the health
    /// </summary>
    /// <param name="health">Max and current health</param>
    public void InitializeHealth(int health)
    {
        currentHealth = health;
        maxHealth = health;
        isDead = false;
    }

    /// <summary>
    /// Getting injured after hitting
    /// </summary>
    /// <param name="amount">Amount of the damage</param>
    public void GetHit(int amount)
    {
        if (isDead) return;

        if (gameObject.CompareTag("Enemy"))
        {
            AudioManager.Instance.PlayEnemySFX(0);
        }
        else if (gameObject.CompareTag("Player"))
        {
            AudioManager.Instance.PlayPlayerSFX(2);
        }

        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            isDead = true;
        }
    }
}

