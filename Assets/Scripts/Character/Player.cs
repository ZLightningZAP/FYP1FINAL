using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : Character
{
    //Healthbar Text
    public Text healthtext;

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

        //Show the amount of health in text
        healthtext.text = health.ToString("F0");
    }
}
