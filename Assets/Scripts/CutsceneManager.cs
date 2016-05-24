using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CutsceneManager : MonoBehaviour
{
    public GameObject CutsceneWaypointCanvas;
    private List<CutsceneWaypoint> CutWaypoint = new List<CutsceneWaypoint>();
    public List<CutsceneWaypoint> SortedCutWaypoint = new List<CutsceneWaypoint>();

    public float MovementSpeed;
    public float RotationSpeed;
    public GameObject UIPanel;

    private InputHandler inputhandler;
    private Player player;
    private EnemyManager enemymanager;

    private float WaitTime;
    private Transform CurrentTransform;
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
        Index = 0;
        distanceGap = 0.01f;

        foreach (var waypoint in FindObjectsOfType(typeof(CutsceneWaypoint)) as CutsceneWaypoint[])
        {
            CutWaypoint.Add(waypoint);
        }

        for (int i = 0; i < CutWaypoint.Count; i++)
        {
            CutWaypoint[i].GetComponentInChildren<Waypoint>().enabled = false;
        }

        SortedCutWaypoint = CutsceneWaypointCanvas.GetComponentsInChildren<CutsceneWaypoint>().ToList();
    }

    // Update is called once per frame
    private void Update()
    {
        if (SortedCutWaypoint[Index].gameObject.transform.position != transform.position)
        {
            if (SortedCutWaypoint[Index].Lookpoint != null)
            {
                Quaternion rotation = Quaternion.LookRotation(SortedCutWaypoint[Index].Lookpoint.gameObject.transform.position - transform.position);
                CurrentTransform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * RotationSpeed);
            }
            else
            {
                Quaternion rotation = Quaternion.LookRotation(SortedCutWaypoint[Index].gameObject.transform.position - transform.position);
                CurrentTransform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * RotationSpeed);
            }
        }

        if (Vector3.Distance(SortedCutWaypoint[Index].gameObject.transform.position, CurrentTransform.position) > distanceGap)
        {
            //Go towards the next position
            CurrentTransform.position = Vector3.MoveTowards(CurrentTransform.position, SortedCutWaypoint[Index].gameObject.transform.position, MovementSpeed * Time.deltaTime);
        }
        else
        {
            WaitTime += Time.deltaTime;

            if (WaitTime > SortedCutWaypoint[Index].WaitTime)
            {
                //Only if its still within bounds of the waypoint
                if (SortedCutWaypoint.Count > Index + 1)
                {
                    Index++;
                    WaitTime = 0.0f;
                }
            }
        }
    }
}