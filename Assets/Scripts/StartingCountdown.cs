using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class StartingCountdown : MonoBehaviour
{
    public bool countdown = false;
    public float CountDownStart = 3;
    public GameObject crosshair;

    private Text text;
    private InputHandler inputhandler;
    private OverHeating overheating;
    private AmmoSystem ammosystem;
    private EnemyManager manager;
    private Timer timer;

    //private CameraMovement movement;
    private Player player;

    private EnemyRandomSpawn spawn;
    private SoundManager sound;

    // Use this for initialization
    private void Start()
    {
        text = GetComponent<Text>();
        inputhandler = FindObjectOfType<InputHandler>();
        overheating = FindObjectOfType<OverHeating>();
        ammosystem = FindObjectOfType<AmmoSystem>();
        manager = FindObjectOfType<EnemyManager>();
        timer = FindObjectOfType<Timer>();
        //movement = FindObjectOfType<CameraMovement>();
        player = FindObjectOfType<Player>();
        spawn = FindObjectOfType<EnemyRandomSpawn>();
        sound = FindObjectOfType<SoundManager>();
        RenderSettings.skybox.SetFloat("_Rotation", 0);
    }

    // Update is called once per frame
    private void Update()
    {
        if (countdown == true)
        {
            crosshair.SetActive(false);
            DisableScripts();
            //Disable the text on the overheat to not cover the countdown
            overheating.overheatBlinking.enabled = false;
            overheating.ReleaseTrigger.enabled = false;
            CountDownStart -= Time.deltaTime;
            text.text = CountDownStart.ToString("F0");
            if (CountDownStart <= 0)
            {
                crosshair.SetActive(true);
                EnableScripts();
                text.enabled = false;
                countdown = false;
            }
        }
    }

    private void DisableScripts()
    {
        inputhandler.enabled = false;
        overheating.enabled = false;
        ammosystem.enabled = false;
        manager.enabled = false;
        timer.enabled = false;
        //movement.enabled = false;
        player.enabled = false;
        spawn.enabled = false;
        sound.enabled = false;
    }

    private void EnableScripts()
    {
        inputhandler.enabled = true;
        overheating.enabled = true;
        ammosystem.enabled = true;
        manager.enabled = true;
        timer.enabled = true;
        //movement.enabled = true;
        player.enabled = true;
        spawn.enabled = true;
        sound.enabled = true;
    }
}