using UnityEngine;
using System.Collections;

public class OverHeating : MonoBehaviour
{
    private int MaxHeat = 1;
    private bool overheated = false;
    private float currentHeat = 0;
    private float cooldowntimer;

    public float HeatPerShot = 0.005f;
    public GameObject overheatBar;
    public bool overHeated { get { return overheated; } set { overheated = value; } }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //Update the heating bar
    public void OverheatbarUpdate()
    {
        //Debug.Log(currentHeat);

        //Increase the heating guage
        currentHeat += HeatPerShot;

        //Clamps the current heat so that it doesnt go crazy
        currentHeat = Mathf.Clamp(currentHeat, 0, MaxHeat);

        //Check if the current heating bar is not null
        //Update the current heating bar transform
        if(overheatBar != null)
        {
            overheatBar.transform.localScale = new Vector3(overheatBar.transform.localScale.x, currentHeat, overheatBar.transform.localScale.z);
        }

        //Check if the guage is full , you cannot fire anymore
        if(currentHeat == 1)
        {
            overheated = true;
        }
    }


    public void CoolDownHeating()
    {
        //Debug.Log(currentHeat);

        //Cooldown will only start every 0.5 seconds
        cooldowntimer += Time.deltaTime;

        //Check if the current time is more than x seconds
        if(cooldowntimer >= 0.5)
        {
            currentHeat -= 0.05f;
            cooldowntimer = 0;
        }

        //Clamps the current heat so that it doesnt go crazy
        currentHeat = Mathf.Clamp(currentHeat, 0, MaxHeat);

        //Check if the current heating bar is not null
        //Update the current heating bar transform
        if (overheatBar != null)
        {
            overheatBar.transform.localScale = new Vector3(overheatBar.transform.localScale.x, currentHeat, overheatBar.transform.localScale.z);
        }

        //If the heating bar is less than 70%, u can continue firing
        if(overheated == true && currentHeat <= 0.7)
        {
            overheated = false;
        }
    }
}
