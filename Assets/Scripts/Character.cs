﻿using UnityEngine;
using System.Collections;

public abstract class Character : MonoBehaviour
{
    [Tooltip("The maximum health of the character.")]
    public int MaxHealth = 100;

    // Health
    public int health;

    // Getters
    public int Health { get { return health; } }
    public bool IsAlive { get { return health > 0; } }

    public GameObject healthBar;

    // Use this for initialization
    protected virtual void Start()
    {
        health = MaxHealth;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        //HealthBar Testing
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
        float currentHP = (float)health / (float)MaxHealth;
        currentHP = Mathf.Clamp(currentHP, 0, MaxHealth);
        if (healthBar != null)
        {
            healthBar.transform.localScale = new Vector3(currentHP, healthBar.transform.localScale.y, healthBar.transform.localScale.z);
        }
    }
}
