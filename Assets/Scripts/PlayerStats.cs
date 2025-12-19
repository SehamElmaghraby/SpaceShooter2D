using UnityEngine;
using UnityEngine.UI; 

public class PlayerStats : MonoBehaviour
{
     public static PlayerStats instance;
    public int gold = 0;
    public Text goldText;

    public int maxHealth = 100;
    public int currentHealth;
    public Slider healthBar; 
    public Text healthText;

    void Start()
    {
        currentHealth = maxHealth;

    if (goldText != null)
        UpdateGoldUI();

    if (healthBar != null && healthText != null)
        UpdateHealthUI();
    }

    public void AddGold(int amount)
    {
        gold += amount;
        UpdateGoldUI();
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if(currentHealth < 0) currentHealth = 0;
        UpdateHealthUI();
        if(currentHealth == 0)
        {
          
            GameManager.instance.GameOver();
            Destroy(gameObject);
        }
    }

    void UpdateGoldUI()
    {
          if (goldText != null)
        goldText.text = "Gold: " + gold;
    }

    void UpdateHealthUI()
    {
       if (healthBar != null)
        healthBar.value = currentHealth;

    if (healthText != null)
        healthText.text = "Health: " + currentHealth;
    }
    void Awake()
{
    if(instance == null)
        instance = this;
    else
        Destroy(gameObject);
}

    
}
