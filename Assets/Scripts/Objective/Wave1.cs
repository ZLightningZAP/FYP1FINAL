using System;
using UnityEngine;
using System.Collections;

public class Wave1 : Objectives
{

    [Tooltip("The number of tanks to be eliminated.")]
    public int enemiestokill = 5;

    // Use this for initialization
    protected override void Start()
    {
        base.Start();
        description = "Defeat " + enemiestokill + " Tank!";
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        //description = "Defeat " + (enemiestokill - Manager.EnemiesKilled) + " enemies!";
    }

    //If objective has been completed
    public override bool IsAchieved()
    {
        return false;
        //(Manager.EnemiesKilled >= enemiestokill);
    }

    protected override void finish()
    {
    }

    protected override bool parseParamString(string[] parameters)
    {
        if (parameters.Length == 1)
        {
            enemiestokill = Convert.ToInt32(parameters[0]);
            return true;
        }

        return false;
    }

}
