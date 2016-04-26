using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform[] Waypoints;   //Waypoints to move towards
    public Transform[] RotationPoints;  //Angles to rotate towards
    public float[] WaitTimes;   //Waiting Time for each way point

    public float MovementSpeed;    //Movement Speed of Camera
    public float RotationSpeed;     //Rotation Speed of Camera

    public float WaitBeforeShooting; //Waiting time before the enemy shoots the player

    private float WaitTime; //Time to wait before moving to next waypoint
    private float waitTimer;    //Count Timer

    //Position
    private Transform CurrentTransform;  //Current Position of Camera

    private Transform NextTransform; //Next Position to move towards

    //Rotation
    private Transform NextRotation; //Next Rotation to rotate towards

    private int Index;   //Current Index of waypoint
    private float distanceGap;  //Used to check if camera has reached target destination

    //Camera shake
    private bool Shaking = false;

    public bool goingtoshake = false;
    private bool UpdateOriginal = false;
    public float ShakeDuration = 0f;
    public float ShakeAmount = 0.7f;
    public float decreaseFactor = 1.0f;
    private Vector3 OriginalPos;
    private Vector3 OriginalRot;
    private bool Checked = false;
    public static bool Goingtoshoot = false;

    //Cutscene

    public EnemyManager enemiManager;
    public GameObject UIPanel;
    public InputHandler inputhandler;
    private Player player;
    private bool runningcutscene = false;
    public int CutsceneEnd;

    // Use this for initialization
    private void Start()
    {
        CurrentTransform = GameObject.FindGameObjectWithTag("MainCamera").transform;
        NextTransform = CurrentTransform;

        Index = 0;
        distanceGap = 0.01f;

        //Only if there is atleast 1 waypoint
        if (Waypoints.Length > 0)
        {
            NextTransform = Waypoints[Index];
            WaitTime = WaitTimes[Index];
        }

        // CUTSCENE
        //Disable the UI Panel on start
        UIPanel.SetActive(false);
        //Disable the input handler on start
        inputhandler.enabled = false;
        //Boolean to handle the running of the cutscene
        runningcutscene = true;
        //Disable the player script so they wont take damage
        player = GetComponentInChildren<Player>();
        player.enabled = false;

        //Play the ambient music
        SoundManager.PlayBackgroundMusic(SoundManager.BackgroundMusic.Ambient);
        SoundManager.SetBGMVolume(0.3f);
    }

    // Update is called once per frame
    private void Update()
    {
        if (goingtoshake == true)
        {
            Shake();
        }

        if (Shaking == false)
        {
            if (RotationPoints.Length > 0)
            {
                if (RotationPoints[Index].position != transform.position)
                {
                    Quaternion rotation = Quaternion.LookRotation(RotationPoints[Index].position - transform.position);
                    CurrentTransform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * RotationSpeed);
                    //print("rotating");
                }
            }

            if (Vector3.Distance(NextTransform.position, CurrentTransform.position) > distanceGap)
            {
                //Go towards the next position
                CurrentTransform.position = Vector3.MoveTowards(CurrentTransform.position, NextTransform.position, MovementSpeed * Time.deltaTime);
                if (Checked == true && runningcutscene == false)
                {
                    Checked = false;
                    enemiManager.CameraMoved();
                }
                if (Goingtoshoot == true && runningcutscene == false)
                {
                    Goingtoshoot = false;
                }
            }
            else
            {
                waitTimer += Time.deltaTime;

                if (waitTimer > WaitTime)
                {
                    //Only if its still within bounds of the waypoint
                    if (Waypoints.Length > Index + 1)
                    {
                        Index++;
                        NextTransform = Waypoints[Index];
                        WaitTime = WaitTimes[Index];
                        waitTimer = 0.0f;
                        print("Going to next point!");
                    }
                }

                if (CurrentTransform.position == Waypoints[CutsceneEnd].position)
                {
                    //Enable the player script
                    player.enabled = true;
                    //No more running of cut scene
                    runningcutscene = false;
                    //Enable the UI Panel
                    UIPanel.SetActive(true);
                    //Enable the input handler
                    inputhandler.enabled = true;
                }

                if (Checked == false && runningcutscene == false)
                {
                    //Check how many enemy on the screen when the camera stops moving
                    enemiManager.NumberOnScreen();
                    if (enemiManager.CanBeSeen.Count == 0)
                    {
                        return;
                    }
                    Checked = true;
                }

                if (Goingtoshoot == false && runningcutscene == false)
                {
                    enemiManager.Shooting();
                    Goingtoshoot = true;
                }
            }
        }
    }

    // Camera shake
    private void Shake()
    {
        if (UpdateOriginal == false)
        {
            OriginalPos = CurrentTransform.localPosition;
            UpdateOriginal = true;
        }

        if (ShakeDuration > 0)
        {
            CurrentTransform.localPosition = OriginalPos + Random.insideUnitSphere * ShakeAmount;
            ShakeDuration -= Time.deltaTime * decreaseFactor;
            Shaking = true;
        }
        else
        {
            ShakeDuration = 0f;
            Shaking = false;
            goingtoshake = false;
            UpdateOriginal = false;
        }
    }
}