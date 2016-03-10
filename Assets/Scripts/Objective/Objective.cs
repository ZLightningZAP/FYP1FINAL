using System;
using UnityEngine;
using System.Collections;

public abstract class Objectives : MonoBehaviour
{
    protected string description;

    private bool finished = false;

    //Stores all the possible types of objectives
    public enum Type
    {
        WAVE1,
        BONUS1,
        WAVE2,
        BONUS2,
        BOSS
    }

    // Use this for initialization
    protected virtual void Start()
    {

    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (!finished && IsAchieved())
        {
            finish();

            // Flag it so that we don't keep finishing it
            finished = true;
        }
    }

    public bool ParseParamString(string str)
    {
        var parameters = str.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);

        return parseParamString(parameters);
    }

    //Getting the description of the current objective
    public virtual string GetDescription()
    {
        return description;
    }

    //This function should define the end conditons of this objective.
    public abstract bool IsAchieved();

    //Call this function to do any clean up on the Objective once it has been completed
    protected abstract void finish();

    //This function should initialize a Objective using a string provided.
    protected abstract bool parseParamString(string[] parameters);
}
