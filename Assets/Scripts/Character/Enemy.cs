using UnityEngine;
using UnityEngine.UI;

public class Enemy : Character
{
    //Healthbar Image
    public Image healthBar;

    public ParticleSystem Debris;
    public ParticleSystem Explosion;
    public ParticleSystem ExplosionSpark;

    //Fill amount for the health bar
    private float HealthFillAmount;

    //Smoke Effect
    private GameObject SmokeEffect;

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


        //When Health drops below 50, start our smoke effect here
        //If Smoke effect is null, shows that this is the first time it has started
        if (health <= 50 && SmokeEffect == null)
        {
            SmokeEffect = VFXController.current.SpawnVFX(transform.position, Quaternion.identity, VFXController.VFX_TYPE.SMOKE_TYPE1);
        }
        //Else check if it is still active
        else if (health <= 50 && !SmokeEffect.activeInHierarchy)
        {
            SmokeEffect = VFXController.current.SpawnVFX(transform.position, Quaternion.identity, VFXController.VFX_TYPE.SMOKE_TYPE1);
        }

        //If enemy has 0 health, active will be set to false
        if (health == 0)
        {
            //Creating Explosion Effect
            Instantiate(Debris, transform.position, Quaternion.identity);
            Instantiate(Explosion, transform.position, Quaternion.identity);
            Instantiate(ExplosionSpark, transform.position, Quaternion.identity);

            //Stop smoke effect if it is active
            if(SmokeEffect.activeInHierarchy)
            {
                SmokeEffect.SetActive(false);
            }

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