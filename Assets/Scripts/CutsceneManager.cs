using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneManager : MonoBehaviour
{
    public List<GameObject> CutsceneWaypoint = new List<GameObject>();
    public List<GameObject> CutsceneLookpoint = new List<GameObject>();
    public float[] WaitTimes;
    public float MovementSpeed;
    public float RotationSpeed;
    public GameObject UIPanel;

    private InputHandler inputhandler;
    private Player player;
    private EnemyManager enemymanager;

    private float WaitTime;
    private Transform CurrentTransform;
    private Transform NextTransform;
    private Transform NextRotation;
    private int Index;
    private float distanceGap;

    // Use this for initialization
    private void Start()
    {
        inputhandler = FindObjectOfType<InputHandler>();
        player = FindObjectOfType<Player>();
        enemymanager = FindObjectOfType<EnemyManager>();

        //Disable the UI Panel on start
        UIPanel.SetActive(false);
        //Disable the input handler on start
        inputhandler.enabled = false;
        //Disable the player script so they wont take damage
        player.enabled = false;
        //Disable the enemy manager so enemy wont start firing
        enemymanager.enabled = false;

        //Set the current transform as the main camera transform
        CurrentTransform = GameObject.FindGameObjectWithTag("MainCamera").transform;
        NextTransform = CurrentTransform;
        Index = 0;
        distanceGap = 0.01f;

        //Check if there is at least 1 waypoint inside the list
        if (CutsceneWaypoint.Count > 0)
        {
            NextTransform = CutsceneWaypoint[Index].transform;
            WaitTime = WaitTimes[Index];
        }
    }

    // Update is called once per frame
    private void Update()
    {
    }
}