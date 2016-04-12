using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using WiimoteApi;

public class InputHandler : MonoBehaviour
{
    public GameObject BulletHole;   //Bullet Hole Graphic
    public ParticleSystem OnHitEffect;  //Particle Effect On Bullet Hit
    public ParticleSystem OnHitEffect2; //Different type
    public OverHeating overheat;
    public AmmoSystem ammosystem;
    public GameObject returnPanel;
    public Image Crosshair; //Crosshair image
    public Fade fade;
    public GameObject canvas;
    public GameObject DeadPanel;
    public Player player;
    public TextManager textmanager;
    public List<GameObject> firingimages = new List<GameObject>();
    public GameObject NewHighscorePanel;
    public InputField Nameinput;
    public InputField Scoreinput;

    private string nameKey;
    private int scoreKey;
    private Animator Flash;
    private int randomnumber;
    public float ReloadTime;

    public float MaxBulletSpreadRange; //Maximum Range of Bullet Spread
    public float FireRate;  //Rate of Fire
    public float SpreadIncreaseRate; //Rate of increasing bullet spread

    private float gap = 0.1f;   //Gap for instantiating effects
    private float defaultBulletSpread = 0.1f;   //Default Range of Bullet Spread
    private float currentBulletSpread;  //Current Range of Bullet Spread
    private float fireTimer = 0.0f; //Use to keep track of time before last fire

    private float reloadtimetracker;

    private bool goingbacktomainmenu = false;
    private bool dead = false;
    private bool highscore = false;
    private bool highscorepanelpressed = false;

    public float DamageOfBullet = 10;

    private GameObject WiiController;   //Wii controller
    private Wiimote wiimote;    //Wii mote
    private Vector3 PointerPosition;    //Pointing Position

    private Camera camera;  //Main Camera

    // Use this for initialization
    private void Start()
    {
        // Hide mouse cursor
        //Cursor.visible = false;

        camera = Camera.main;

        currentBulletSpread = defaultBulletSpread;

        //Set the active of the return panel to false
        returnPanel.SetActive(false);
        DeadPanel.SetActive(false);
        NewHighscorePanel.SetActive(false);

        //Wii Set up
        WiiController = GameObject.Find("WiiController");
        wiimote = WiiController.GetComponent<WiiConnection>().wiimote;
    }

    // Update is called once per frame
    private void Update()
    {
        fireTimer += Time.deltaTime;

        int ret;

        if (ammosystem.bullet == 0)
        {
            Debug.Log("Reloading");
            reloadtimetracker += Time.deltaTime;
            if (reloadtimetracker >= ReloadTime)
            {
                Debug.Log("Reloaded");
                ammosystem.Reload();
                reloadtimetracker = 0;
            }
        }

        //If wiimote is assigned
        if (wiimote != null)
        {
            //Read Data
            do
            {
                ret = wiimote.ReadWiimoteData();
            } while (ret > 0);

            if (wiimote.Button.a)
            {
                print("A down");

                if (ammosystem.bullet != 0)
                {
                    if (fireTimer >= FireRate && overheat.overHeated == false)
                    {
                        if (goingbacktomainmenu == false && dead == false && highscore == false)
                        {
                            Fire();
                            //Update the Ammo Bar
                            ammosystem.AmmoUpdateUI();
                        }
                    }
                }
            }
            else if (wiimote.Button.home)
            {
                // Show the going back to main menu panel
                if (goingbacktomainmenu == true)
                {
                    ClickedNO();
                }
                else
                {
                    ReturnPanel();
                }
            }
            else
            {
                //Decrease the heating guage every 0.5 second
                overheat.CoolDownHeating();

                //Decreasing bullet spread over time
                currentBulletSpread -= Time.deltaTime * SpreadIncreaseRate;
                if (currentBulletSpread <= defaultBulletSpread)
                {
                    currentBulletSpread = defaultBulletSpread;
                }
            }
        }
        //Fall back on Mouse Input
        else
        {
            //If Left Click
            if (Input.GetMouseButton(0))
            {
                if (ammosystem.bullet != 0)
                {
                    if (fireTimer >= FireRate && overheat.overHeated == false)
                    {
                        if (goingbacktomainmenu == false && dead == false && highscore == false)
                        {
                            Fire();
                            //Update the Ammo Bar
                            ammosystem.AmmoUpdateUI();
                        }
                    }
                }
            }
            else if (Input.GetKeyDown(KeyCode.Escape))
            {
                // Show the going back to main menu panel
                if (goingbacktomainmenu == true)
                {
                    ClickedNO();
                }
                else
                {
                    ReturnPanel();
                }
            }
            else
            {
                //Decrease the heating guage every 0.5 second
                overheat.CoolDownHeating();

                //Decreasing bullet spread over time
                currentBulletSpread -= Time.deltaTime * SpreadIncreaseRate;
                if (currentBulletSpread <= defaultBulletSpread)
                {
                    currentBulletSpread = defaultBulletSpread;
                }
            }
        }

        //Wiimote detected and connected
        if (wiimote != null)
        {
            //Setting final position to IR's detected position
            float[] pointer = wiimote.Ir.GetPointingPosition();

            //Mapping the position to screen
            PointerPosition.x = pointer[0] * Screen.width;
            PointerPosition.y = pointer[1] * Screen.height;
        }
        else
        {
            PointerPosition = Input.mousePosition;
        }

        Crosshair.transform.position = PointerPosition;

        if (player.Health <= 0)
        {
            GOPanel();
        }

        if (Input.GetKeyDown(KeyCode.Insert))
        {
            if (highscorepanelpressed == false)
            {
                highscorepanelpressed = true;
            }
            else if (highscorepanelpressed == true)
            {
                DeadPanel.SetActive(false);
                NewHighscorePanel.SetActive(false);
                highscorepanelpressed = false;
                Time.timeScale = 1;
            }
        }

        if (highscorepanelpressed == true)
        {
            NewHighscore();
        }
    }

    private void Fire()
    {
        // Minus bulet from ammosystem
        ammosystem.AmmoFire();

        //Update the overheat bar
        overheat.OverheatbarUpdate();

        //Creating Bullet Spread
        Vector3 FinalPosition = Input.mousePosition;

        randomnumber = Random.Range(0, firingimages.Count);
        GameObject firing = Instantiate(firingimages[randomnumber], PointerPosition, Quaternion.identity) as GameObject;
        firing.SetActive(true);
        firing.transform.SetParent(canvas.transform);

        //Wiimote detected and connected , Use Wiimote's IR Position Instead
        if (wiimote != null)
        {
            //Setting final position to IR's detected position
            float[] pointer = wiimote.Ir.GetPointingPosition();

            //Mapping the position to screen
            FinalPosition.x = pointer[0] * Screen.width;
            FinalPosition.y = pointer[1] * Screen.height;
        }

        //print(FinalPosition);
        FinalPosition.x += Random.Range(-currentBulletSpread, currentBulletSpread);
        FinalPosition.y += Random.Range(-currentBulletSpread, currentBulletSpread);

        //Creating Ray based on final calculated position
        Ray ray = camera.ScreenPointToRay(FinalPosition);

        RaycastHit hit;

        //Checking if Ray has hit
        if (Physics.Raycast(ray, out hit))
        {
            int rand = Random.Range(1, 3);

            if(rand == 1)
            {
                VFXController.current.SpawnVFX(hit.point + (hit.normal * gap), Quaternion.LookRotation(hit.normal), VFXController.VFX_TYPE.SPARKS_TYPE1);
                //Instantiate(OnHitEffect, hit.point + (hit.normal * gap), Quaternion.LookRotation(hit.normal));  //Creating On Hit Effect
            }
            else
            {
                VFXController.current.SpawnVFX(hit.point + (hit.normal * gap), Quaternion.LookRotation(hit.normal), VFXController.VFX_TYPE.SPARKS_TYPE2);
                //Instantiate(OnHitEffect2, hit.point + (hit.normal * gap), Quaternion.LookRotation(hit.normal));  //Creating On Hit Effect
            }

            print(rand);
            Instantiate(BulletHole, hit.point + (hit.normal * gap), Quaternion.LookRotation(hit.normal));   //Creating Bullet Hole
            hit.transform.SendMessage("Injure", DamageOfBullet, SendMessageOptions.DontRequireReceiver);
        }

        fireTimer = 0.0f;   //Resetting the Timer
        currentBulletSpread += Time.deltaTime * SpreadIncreaseRate;  //Increasing spread of bullet
        if (currentBulletSpread > MaxBulletSpreadRange)
        {
            currentBulletSpread = MaxBulletSpreadRange;
        }
    }

    public void NewHighscore()
    {
        highscore = true;
        Time.timeScale = 0;
        DeadPanel.SetActive(true);
        NewHighscorePanel.SetActive(true);

        scoreKey = System.Int32.Parse(Scoreinput.text);
        nameKey = Nameinput.text;
    }

    public void HighscorePanelYES()
    {
        textmanager.Write(nameKey, scoreKey);
        highscorepanelpressed = false;
        NewHighscorePanel.SetActive(false);
    }

    public void ReturnPanel()
    {
        Time.timeScale = 0;
        returnPanel.SetActive(true);
        goingbacktomainmenu = true;
    }

    public void GOPanel()
    {
        Time.timeScale = 1;
        DeadPanel.SetActive(true);
        dead = true;
    }

    public void ClickedYES()
    {
        Time.timeScale = 1;
        fade.FadeMe();
        goingbacktomainmenu = false;
        dead = false;
    }

    public void ClickedNO()
    {
        Time.timeScale = 1;
        returnPanel.SetActive(false);
        goingbacktomainmenu = false;
    }

    public void ConnectWii()
    {
        if (wiimote != null)
        {
            WiimoteManager.Cleanup(wiimote);
            wiimote = null;
        }
        else
        {
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
    }
}