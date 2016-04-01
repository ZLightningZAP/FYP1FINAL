using UnityEngine;
using WiimoteApi;

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
    private Wiimote wiimote;    //Wii mote
    private int ret;

    // Use this for initialization
    private void Start()
    {
        //Get component of the animator from the gameobject
        anim1 = MainMenuPanel.GetComponent<Animator>();
        anim2 = HighScorePanel.GetComponent<Animator>();

        //Set their respective animation to false
        anim1.enabled = false;
        anim2.enabled = false;

        //Wii Plugins Initialize
        WiimoteManager.FindWiimotes();  //Find for connected Wii Mote

        //Check if Manager has wii mote connected
        if (WiimoteManager.HasWiimote())
        {
            print("Wiimote Found");

            //Assign our variable to the first
            wiimote = WiimoteManager.Wiimotes[0];

            if (wiimote != null)
            {
                print("Wiimote Assigned");

                wiimote.SendPlayerLED(true, false, false, false);
            }

            //Setup IR Camera
            wiimote.SetupIRCamera(IRDataType.BASIC);
        }
    }

    // Update is called once per frame
    private void Update()
    {
        //Add delta time to transition time
        transitiontime += Time.deltaTime;

        //If transition time is more than the input transition timing, Change panel
        if (transitiontime >= TransitionTiming)
        {
            if (MainMenu == false)
            {
                MainMenuSlideIn();
                transitiontime = 0;
            }
            else if (MainMenu == true)
            {
                HighScoreSlideIn();
                transitiontime = 0;
            }
        }

        // if wiimote is found
        if (wiimote != null)
        {
            //Read Data
            do
            {
                ret = wiimote.ReadWiimoteData();
            } while (ret > 0);

            if (wiimote.Button.a || wiimote.Button.b)
            {
                print("A or B Button is pressed!");
                fade.FadeMe();
            }
        }
        // Falling back to mouse and keyboard input
        else
        {
            if (Input.GetMouseButton(0))
            {
                fade.FadeMe();
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    private void HighScoreSlideIn()
    {
        // Set their respective animation to true
        anim1.enabled = true;
        anim2.enabled = true;

        //Play their respective animation
        anim1.Play("MainPanelSlideOut");
        anim2.Play("HighscorePanelSlideIn");

        MainMenu = false;
    }

    private void MainMenuSlideIn()
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