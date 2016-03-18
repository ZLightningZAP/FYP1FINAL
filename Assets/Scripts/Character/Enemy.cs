using UnityEngine;
using System.Collections;

public class Enemy : Character
{
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

        //If enemy has 0 health, active will be set to false
        if(health == 0)
        {
            gameObject.SetActive(false);
        }
    }
}
