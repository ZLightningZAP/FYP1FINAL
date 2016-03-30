using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : Character
{
    //Healthbar Text
    public Text healthtext;
    public RawImage BloodImage;
    public float transitionTime = 0.5f;

    //Getter and setter for score
    public int score { get { return Score; } set { Score = value; } }

    private int Score;
    private bool gone = false;
    private float transition;

    // Use this for initialization
    protected override void Start()
    {
        // Base Start
        base.Start();
        Score = 0;
        BloodImage.enabled = false;
    }

    // Update is called once per frame
    protected override void Update()
    {
        // Base Update
        base.Update();

        //Show the amount of health in text
        healthtext.text = health.ToString("F0");

        if (health <= 40)
        {
            BloodEffect();
        }
    }

    void BloodEffect()
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
}
