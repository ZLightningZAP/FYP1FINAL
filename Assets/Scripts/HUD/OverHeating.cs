using UnityEngine;
using UnityEngine.UI;

public class OverHeating : MonoBehaviour
{
    private int MaxHeat = 1;
    private bool overheated = false;
    private float currentHeat = 0;
    private float cooldowntimer;
    private float number;

    //Variables to control blinking of the bar
    private float transition;

    private bool gone = false;
    private bool blinking = false;

    //variables to control glowing of the bar
    private float transitionGlow;

    private bool goneGlow = false;
    private bool glowing = false;

    public float CooldownTimerCountdown = 1.0f;
    public float ContinueShooting = 0.75f;
    public float StartToBlink = 0.6f;
    public float HeatPerShot = 0.005f;
    public float BlinkingSpeed = 0.25f;
    public Image overheatBar;

    public Text overheatBlinking;
    public Text ReleaseTrigger;
    public RawImage overheatGlow;

    public bool overHeated { get { return overheated; } set { overheated = value; } }

    // Use this for initialization
    private void Start()
    {
        overheatBlinking.enabled = false;
        overheatGlow.enabled = false;
    }

    // Update is called once per frame
    private void Update()
    {
        if (blinking == true)
        {
            Blinking();
        }
        if (glowing == true)
        {
            Glowing();
        }
    }

    //Update the heating bar
    public void OverheatbarUpdate()
    {
        //Increase the heating guage
        currentHeat += HeatPerShot;

        //Clamps the current heat so that it doesnt go crazy
        currentHeat = Mathf.Clamp(currentHeat, 0, MaxHeat);

        //Check if the current heating bar is not null
        //Update the current heating bar transform
        if (overheatBar != null)
        {
            overheatBar.fillAmount = currentHeat;
        }

        if (currentHeat >= StartToBlink)
        {
            blinking = true;
            glowing = true;
        }

        //Check if the guage is full , you cannot fire anymore
        if (currentHeat == 1)
        {
            overheated = true;
            blinking = false;
            overheatBlinking.enabled = false;
            ReleaseTrigger.enabled = true;
        }

        number = currentHeat;
    }

    // Update the cooldown on the overheating system
    public void CoolDownHeating()
    {
        //Cooldown will only start every 0.5 seconds
        cooldowntimer += Time.deltaTime;

        //Check if the current time is more than x seconds
        if (cooldowntimer >= CooldownTimerCountdown)
        {
            number -= 0.05f;
            cooldowntimer = 0;
        }

        //Smoothen down cooldown
        if (number != currentHeat)
        {
            currentHeat -= 0.01f;
        }

        //Clamps the current heat so that it doesnt go crazy
        currentHeat = Mathf.Clamp(currentHeat, 0, MaxHeat);

        //Check if the current heating bar is not null
        //Update the current heating bar transform
        if (overheatBar != null)
        {
            overheatBar.fillAmount = currentHeat;
        }

        if (currentHeat <= StartToBlink)
        {
            blinking = false;
            glowing = false;
            overheatBlinking.enabled = false;
            overheatGlow.enabled = false;
            ReleaseTrigger.enabled = false;
        }

        //If the heating bar is less than 75%, u can continue firing
        if (overheated == true && currentHeat <= ContinueShooting)
        {
            overheated = false;
        }
    }

    // Update the cooldown on the overheating system
    public void CoolDownWhileShooting()
    {
        //Cooldown will only start every 0.5 seconds
        cooldowntimer += Time.deltaTime;

        //Check if the current time is more than x seconds
        if (cooldowntimer >= CooldownTimerCountdown)
        {
            number -= 0.05f;
            cooldowntimer = 0;
        }

        //Smoothen down cooldown
        if (number != currentHeat)
        {
            currentHeat -= 0.001f;
        }

        //Clamps the current heat so that it doesnt go crazy
        currentHeat = Mathf.Clamp(currentHeat, 0, MaxHeat);

        //Check if the current heating bar is not null
        //Update the current heating bar transform
        if (overheatBar != null)
        {
            overheatBar.fillAmount = currentHeat;
        }

        if (currentHeat <= StartToBlink)
        {
            blinking = false;
            glowing = false;
            overheatBlinking.enabled = false;
            overheatGlow.enabled = false;
        }

        //If the heating bar is less than 75%, u can continue firing
        if (overheated == true && currentHeat <= ContinueShooting)
        {
            overheated = false;
        }
    }

    private void Blinking()
    {
        //Add up the time for the overheat blinking effect
        transition += Time.deltaTime;
        overheatBlinking.enabled = true;
        if (gone == false && transition >= BlinkingSpeed)
        {
            overheatBlinking.CrossFadeAlpha(0.0f, BlinkingSpeed, false);
            gone = true;
            transition = 0;
        }
        else if (gone == true && transition >= BlinkingSpeed)
        {
            overheatBlinking.CrossFadeAlpha(1f, BlinkingSpeed, false);
            gone = false;
            transition = 0;
        }
    }

    private void Glowing()
    {
        //Add up the time for the overheat blinking effect
        transitionGlow += Time.deltaTime;
        overheatGlow.enabled = true;
        if (goneGlow == false && transitionGlow >= BlinkingSpeed)
        {
            overheatGlow.CrossFadeAlpha(0.0f, BlinkingSpeed, false);
            goneGlow = true;
            transitionGlow = 0;
        }
        else if (goneGlow == true && transitionGlow >= BlinkingSpeed)
        {
            overheatGlow.CrossFadeAlpha(1f, BlinkingSpeed, false);
            goneGlow = false;
            transitionGlow = 0;
        }
    }
}