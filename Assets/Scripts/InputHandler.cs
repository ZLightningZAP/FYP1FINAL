﻿using UnityEngine;
using UnityEngine.UI;
using WiimoteApi;

public class InputHandler : MonoBehaviour
{
    public GameObject BulletHole;   //Bullet Hole Graphic
    public ParticleSystem OnHitEffect;  //Particle Effect On Bullet Hit
    public OverHeating overheat;
    public AmmoSystem ammosystem;
    public Image Crosshair;

    public float MaxBulletSpreadRange; //Maximum Range of Bullet Spread
    public float FireRate;  //Rate of Fire
    public float SpreadIncreaseRate; //Rate of increasing bullet spread
    public float ReloadTime;

    private float gap = 0.1f;   //Gap for instantiating effects
    private float defaultBulletSpread = 0.1f;   //Default Range of Bullet Spread
    private float currentBulletSpread;  //Current Range of Bullet Spread
    private float fireTimer = 0.0f; //Use to keep track of time before last fire

    private float reloadtimetracker;

    public float DamageOfBullet = 10;

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
                        Fire();
                        //Update the Ammo Bar
                        ammosystem.AmmoUpdateUI();
                    }
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
                        Fire();
                        //Update the Ammo Bar
                        ammosystem.AmmoUpdateUI();
                    }
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

        // Crosshair following mouse
        Crosshair.transform.position = PointerPosition;

        //print(PointerPosition);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
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
            Instantiate(OnHitEffect, hit.point + (hit.normal * gap), Quaternion.LookRotation(hit.normal));  //Creating On Hit Effect
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
}