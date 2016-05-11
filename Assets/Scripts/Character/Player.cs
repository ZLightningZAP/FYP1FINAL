using UnityEngine;
using UnityEngine.UI;

public class Player : Character
{
    //Healthbar Image
    public Image healthBar;

    public RawImage BloodImage;
    public RawImage TakingDmg;
    public float HealthGlowTransitionTime = 0.5f;

    //Getter and setter for score
    public int score { get { return Score; } set { Score = value; } }

    private int Score;
    private bool gone = false;
    private float transition;

    public float BlinkingSpeed = 0.2f;
    private float blinktransition;

    public float DamageSpeed = 0.2f;
    private bool Damage = false;
    private float DamageTransition;

    //Fill amount for the health bar
    private float HealthFillAmount;

    private float lasthealth;
    private bool finished = false;

    // Use this for initialization
    protected override void Start()
    {
        // Base Start
        base.Start();
        Score = 0;
        BloodImage.enabled = false;
        TakingDmg.enabled = false;
        lasthealth = health;
    }

    // Update is called once per frame
    protected override void Update()
    {
        // Base Update
        base.Update();

        //HealthBar
        HealthBarUpdate(Health);

        //If the player healthbar drop below 40
        if (health <= 40)
        {
            BloodEffect();
        }

        //If the player receive damage
        if (lasthealth != health)
        {
            TakingDamage();
            if (finished == true)
            {
                lasthealth = health;
                finished = false;
            }
        }
    }

    private void BloodEffect()
    {
        transition += Time.deltaTime;
        BloodImage.enabled = true;

        if (gone == false && transition >= HealthGlowTransitionTime)
        {
            BloodImage.CrossFadeAlpha(0.0f, HealthGlowTransitionTime, false);
            gone = true;
            transition = 0;
        }
        else if (gone == true && transition >= HealthGlowTransitionTime)
        {
            BloodImage.CrossFadeAlpha(1.0f, HealthGlowTransitionTime, false);
            gone = false;
            transition = 0;
        }
    }

    private void TakingDamage()
    {
        DamageTransition += Time.deltaTime;
        TakingDmg.enabled = true;

        if (Damage == false && DamageTransition >= DamageSpeed)
        {
            TakingDmg.CrossFadeAlpha(1.0f, DamageSpeed, false);
            Damage = true;
            DamageTransition = 0;
        }
        else if (Damage == true && DamageTransition >= DamageSpeed)
        {
            TakingDmg.CrossFadeAlpha(0.0f, DamageSpeed, false);
            Damage = false;
            DamageTransition = 0;
            finished = true;
        }
    }

    private void HealthBarUpdate(float health)
    {
        // Calculate the fill amount of the health bar
        HealthFillAmount = health / MaxHealth;
        healthBar.fillAmount = HealthFillAmount;
    }
}