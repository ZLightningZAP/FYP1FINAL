using UnityEngine;
using System.Collections;

public class MainMenuTransition : MonoBehaviour
{
    public GameObject MainMenuPanel;
    public GameObject HighScorePanel;
    public Fade fade;
    public float TransitionTiming;

    private Animator anim1;
    private Animator anim2;
    private bool MainMenu = true;

    private float transitiontime = 0;

    // Use this for initialization
    void Start()
    {
        //Get component of the animator from the gameobject
        anim1 = MainMenuPanel.GetComponent<Animator>();
        anim2 = HighScorePanel.GetComponent<Animator>();

        //Set their respective animation to false
        anim1.enabled = false;
        anim2.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Add delta time to transition time
        transitiontime += Time.deltaTime;

        //If transition time is more than the input transition timing, Change panel
        if(transitiontime >= TransitionTiming)
        {
            if(MainMenu == false)
            {
                MainMenuSlideIn();
                transitiontime = 0;
            }
            else if(MainMenu == true)
            {
                HighScoreSlideIn();
                transitiontime = 0;
            }
        }

        if(Input.GetMouseButton(0))
        {
            fade.FadeMe();
        }

    }


    void HighScoreSlideIn()
    {
        // Set their respective animation to true
        anim1.enabled = true;
        anim2.enabled = true;

        //Play their respective animation
        anim1.Play("MainPanelSlideOut");
        anim2.Play("HighscorePanelSlideIn");

        MainMenu = false;
    }


    void MainMenuSlideIn()
    {
        // Set their respective animation to true
        anim1.enabled = true;
        anim2.enabled = true;

        //Play their respective animation
        anim1.Play("MainPanelSlideIn");
        anim2.Play("HighscorePanelSlideOut");

        MainMenu = true;
    }
}
