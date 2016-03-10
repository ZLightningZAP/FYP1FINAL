using System;
using UnityEngine;
using System.Collections;

public class Boss : Objectives
{

    // Use this for initialization
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    //If objective has been completed
    public override bool IsAchieved()
    {
        return false;
    }

    protected override void finish()
    {
    }

    protected override bool parseParamString(string[] parameters)
    {
        return false;
    }
}
