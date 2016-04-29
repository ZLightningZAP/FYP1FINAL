using System.Collections;
using UnityEngine;

public class CutsceneManager : MonoBehaviour
{
    //Cutscene

    public GameObject UIPanel;
    public InputHandler inputhandler;
    public int CutsceneEnd;

    private Player player;
    private bool runningcutscene = false;

    // Use this for initialization
    private void Start()
    {
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
    }

    // Update is called once per frame
    private void Update()
    {
    }
}