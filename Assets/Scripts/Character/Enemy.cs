using UnityEngine;
using UnityEngine.UI;

public class Enemy : Character
{
    //Healthbar Image
    public Image healthBar;

    public ParticleSystem Debris;
    public ParticleSystem Explosion;
    public ParticleSystem ExplosionSpark;
    public ParticleSystem SmokeEffect;

    //Fill amount for the health bar
    private float HealthFillAmount;

    private bool SmokeEffectStart;

    // Use this for initialization
    protected override void Start()
    {
        // Base Start
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        // Base Update
        base.Update();

        //HealthBar
        //HealthBarUpdate(Health);

        if(health <= 50 && !SmokeEffectStart)
        {
            Instantiate(SmokeEffect, transform.position, Quaternion.identity);


            SmokeEffectStart = true;
        }

        //If enemy has 0 health, active will be set to false
        if (health == 0)
        {
            //Creating Explosion Effect
            Instantiate(Debris, transform.position, Quaternion.identity);
            Instantiate(Explosion, transform.position, Quaternion.identity);
            Instantiate(ExplosionSpark, transform.position, Quaternion.identity);

            //Deactivate object
            gameObject.SetActive(false);
        }
    }

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
        else if (healthBar.fillAmount <= 0.7)
        {
            healthBar.color = Color.yellow;
        }
    }
}