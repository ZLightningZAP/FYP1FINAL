using UnityEngine;
using UnityEngine.UI;

public abstract class Character : MonoBehaviour
{
    [Tooltip("The maximum health of the character.")]
    public int MaxHealth = 100;

    // Health
    public float health;

    // Getters
    public float Health { get { return health; } }

    public bool IsAlive { get { return health > 0; } }

    // Use this for initialization
    protected virtual void Start()
    {
        health = MaxHealth;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        Injure(0.5f);
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
}