using UnityEngine;
using UnityEngine.UI;

public class OverHeating : MonoBehaviour
{
    private int MaxHeat = 1;
    private bool overheated = false;
    private float currentHeat = 0;
    private float cooldowntimer;
    private float number;

    public float CooldownTimerCountdown = 1.0f;
    public float ContinueShooting = 0.75f;
    public float HeatPerShot = 0.005f;
    public Image overheatBar;
    public bool overHeated { get { return overheated; } set { overheated = value; } }

    // Use this for initialization
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
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

        //Check if the guage is full , you cannot fire anymore
        if (currentHeat == 1)
        {
            overheated = true;
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

        //If the heating bar is less than 75%, u can continue firing
        if (overheated == true && currentHeat <= ContinueShooting)
        {
            overheated = false;
        }
    }
}