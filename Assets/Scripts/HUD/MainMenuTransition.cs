using UnityEngine;
using WiimoteApi;

public class MainMenuTransition : MonoBehaviour
{
    public GameObject MainMenuPanel;
    public GameObject HighScorePanel;
    public Fade fade;
    public GameObject Crosshair;
    public float TransitionTiming;

    // For the Quit options
    public GameObject quitMenu;

    private Animator anim1;
    private Animator anim2;
    private bool MainMenu = true;

    private float transitiontime = 0;
    private Wiimote wiimote;    //Wii mote
    private int ret;
    private bool goingtoexit = false;

    private GameObject WiiController;

    // Use this for initialization
    private void Start()
    {
        //Get component of the animator from the gameobject
        anim1 = MainMenuPanel.GetComponent<Animator>();
        anim2 = HighScorePanel.GetComponent<Animator>();

        //Set their respective animation to false
        anim1.enabled = false;
        anim2.enabled = false;

        //Wii Set up
        WiiController = GameObject.Find("WiiController");
        wiimote = WiiController.GetComponent<WiiConnection>().wiimote;
        
        //Disable the quit menu on start
        quitMenu.SetActive(false);
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
            if (wiimote.Button.home)
            {
                ExitPress();
            }

            //Setting final position to IR's detected position
            float[] pointer = wiimote.Ir.GetPointingPosition();

            //Mapping the position to screen
            Crosshair.transform.position = new Vector3(pointer[0] * Screen.width, pointer[1] * Screen.height, 0);

        }
        // Falling back to mouse and keyboard input
        else
        {
            if (Input.GetMouseButton(0))
            {
                if (goingtoexit == false)
                {
                    fade.FadeMe();
                }
            }

            //Mapping crosshair to mouse position
            Crosshair.transform.position = Input.mousePosition;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (goingtoexit == true)
            {
                NoPress();
            }
            else
            {
                ExitPress();
            }
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

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ExitPress()
    {
        quitMenu.SetActive(true);
        goingtoexit = true;
    }

    public void NoPress()
    {
        quitMenu.SetActive(false);
        goingtoexit = false;
    }
}