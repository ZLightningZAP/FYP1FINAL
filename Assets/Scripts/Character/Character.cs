using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public abstract class Character : MonoBehaviour
{
    [Tooltip("The maximum health of the character.")]
    public int MaxHealth = 100;

    // Health
    public float health;
    //Healthbar Image
    public Image healthBar;

    // Getters
    public float Health { get { return health; } }
    public bool IsAlive { get { return health > 0; } }

    //Fill amount for the health bar
    private float HealthFillAmount;

    // Use this for initialization
    protected virtual void Start()
    {
        health = MaxHealth;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        //HealthBar
        HealthBarUpdate(Health);
        Injure(0.1f);
    }

    //Use this to injure the character
    public void Injure(float damage)
    {
        // Error checks
        if (damage < 0)
        {
            throw new UnityException("Please don't use Injure() to heal!");
        }

        health -= damage;

        // Clamp the health so we don't go crazy with the health accidentally
        health = Mathf.Clamp(health, 0, MaxHealth);
    }

    //Use this to heal the character
    public void Heal(float healing)
    {
        // Error checks
        if (healing < 0)
        {
            throw new UnityException("Please don't use Heal() to injure!");
        }

        health += healing;

        // Clamp the health so we don't go crazy with the health accidentally
        health = Mathf.Clamp(health, 0, MaxHealth);
    }

    //Updated the healthbar on the character
    public void HealthBarUpdate(float health)
    {
        // Calculate the fill amount of the health bar
        HealthFillAmount = health / MaxHealth;
        healthBar.fillAmount = HealthFillAmount;

        // If the health amount drop below 30%, the color of the healthbar will change to red
        if (healthBar.fillAmount <= 0.3)
        {
            healthBar.color = Color.red;
        }

        // If the health amount drop below 70%, the color of the healthbar will change to yellow
        else if(healthBar.fillAmount <= 0.7)
        {
            healthBar.color = Color.yellow;
        }
    }
}
