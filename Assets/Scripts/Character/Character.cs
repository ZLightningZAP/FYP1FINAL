using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public abstract class Character : MonoBehaviour
{
    [Tooltip("The maximum health of the character.")]
    public int MaxHealth = 100;

    // Health
    public int health;

    // Getters
    public int Health { get { return health; } }
    public bool IsAlive { get { return health > 0; } }

    public float HealthFillAmount;

    public Image healthBar;
    public Text healthtext;

    // Use this for initialization
    protected virtual void Start()
    {
        health = 20;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        //HealthBar
        HealthBarUpdate(Health);
    }

    //Use this to injure the character
    public void Injure(int damage)
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
    public void Heal(int healing)
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
    public void HealthBarUpdate(int health)
    {
        //Show the amount of health in text
        healthtext.text = health.ToString();

        // Calculate the fill amount of the health bar
        HealthFillAmount = (float)health / (float)MaxHealth;
        healthBar.fillAmount = HealthFillAmount;

        // If the health amount drop below 30%, the color of the healthbar will change to red
        if(healthBar.fillAmount <= 0.3)
        {
            healthBar.color = Color.red;
        }
    }
}
