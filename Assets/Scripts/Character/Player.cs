using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : Character
{
    //Healthbar Text
    public Text healthtext;

    //Getter and setter for score
    public int score { get { return Score; } set { Score = value; } }

    private int Score;

    // Use this for initialization
    protected override void Start()
    {
        // Base Start
        base.Start();
        Score = 0;
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
