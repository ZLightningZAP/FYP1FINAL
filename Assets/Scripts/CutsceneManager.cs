using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneManager : MonoBehaviour
{
    public List<GameObject> CutsceneWaypoint = new List<GameObject>();
    public GameObject UIPanel;
    public InputHandler inputhandler;
    public Player player;

    // Use this for initialization
    private void Start()
    {
        //Disable the UI Panel on start
        UIPanel.SetActive(false);
        //Disable the input handler on start
        inputhandler.enabled = false;
        //Disable the player script so they wont take damage
        player.enabled = false;
    }

    // Update is called once per frame
    private void Update()
    {
    }
}