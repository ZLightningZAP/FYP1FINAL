using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using WiimoteApi;

public class MainMenuTransition : MonoBehaviour
{
    public GameObject Overlay;
    public Image Crosshair;

    // For the Quit options
    public GameObject quitMenu;

    private Animator anim1;

    private Wiimote wiimote;    //Wii mote
    private int ret;
    private bool goingtoexit = false;

    private GameObject WiiController;

    // Use this for initialization
    private void Start()
    {
        anim1 = Overlay.GetComponent<Animator>();
        // Set their respective animation to true
        anim1.enabled = true;

        //Play their respective animation
        anim1.Play("MenuAnimation");

        //Disable the quit menu on start
        quitMenu.SetActive(false);

        //Wii Set up
        WiiController = GameObject.Find("WiiController");
        wiimote = WiiController.GetComponent<WiiConnection>().wiimote;
    }

    // Update is called once per frame
    private void Update()
    {
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
                StartCoroutine(ChangeLevel());
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
                    SoundManager.PlaySoundEffect(SoundManager.SoundEffect.ClickToStart);
                    StartCoroutine(ChangeLevel());
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

    private IEnumerator ChangeLevel()
    {
        float fadeTime = GetComponent<FadeInOut>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene(2);
    }
}