using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBoss : Character
{
    //Healthbar Image
    public Image healthBar;

    //Fill amount for the health bar
    private float HealthFillAmount;

    // Use this for initialization
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        // Update the healthbar
        HealthBarUpdate(Health);
    }

    public void HealthBarUpdate(float health)
    {
        // Calculate the fill amount of the health bar
        HealthFillAmount = health / MaxHealth;
        healthBar.fillAmount = HealthFillAmount;

        //// If the health amount drop below 30%, the color of the healthbar will change to red
        //if (healthBar.fillAmount <= 0.3)
        //{
        //    healthBar.color = Color.red;
        //}

        //// If the health amount drop below 70%, the color of the healthbar will change to yellow
        //else if (healthBar.fillAmount <= 0.7)
        //{
        //    healthBar.color = Color.yellow;
        //}
    }
}