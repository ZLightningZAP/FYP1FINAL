using UnityEngine;
using UnityEngine.UI;

public class Player : Character
{
    //Healthbar Image
    public Image healthBar;

    public RawImage BloodImage;
    public RawImage healthGlow;
    public float transitionTime = 0.5f;

    //Getter and setter for score
    public int score { get { return Score; } set { Score = value; } }

    private int Score;
    private bool gone = false;
    private float transition;

    public float BlinkingSpeed = 0.2f;
    private bool Blink = false;
    private float blinktransition;

    //Fill amount for the health bar
    private float HealthFillAmount;

    // Use this for initialization
    protected override void Start()
    {
        // Base Start
        base.Start();
        Score = 0;
        BloodImage.enabled = false;
        healthGlow.enabled = false;
    }

    // Update is called once per frame
    protected override void Update()
    {
        // Base Update
        base.Update();

        //HealthBar
        HealthBarUpdate(Health);

        if (health <= 40)
        {
            BloodEffect();
            Blinking();
        }
    }

    private void BloodEffect()
    {
        transition += Time.deltaTime;
        BloodImage.enabled = true;

        if (gone == false && transition >= transitionTime)
        {
            BloodImage.CrossFadeAlpha(0.0f, transitionTime, false);
            gone = true;
            transition = 0;
        }
        else if (gone == true && transition >= transitionTime)
        {
            BloodImage.CrossFadeAlpha(1.0f, transitionTime, false);
            gone = false;
            transition = 0;
        }
    }

    private void Blinking()
    {
        blinktransition += Time.deltaTime;
        healthGlow.enabled = true;

        if (Blink == false && blinktransition >= BlinkingSpeed)
        {
            healthGlow.CrossFadeAlpha(0.0f, transitionTime, false);
            Blink = true;
            blinktransition = 0;
        }
        else if (Blink == true && blinktransition >= BlinkingSpeed)
        {
            healthGlow.CrossFadeAlpha(1.0f, transitionTime, false);
            Blink = false;
            blinktransition = 0;
        }
    }

    private void HealthBarUpdate(float health)
    {
        // Calculate the fill amount of the health bar
        HealthFillAmount = health / MaxHealth;
        healthBar.fillAmount = HealthFillAmount;
    }
}