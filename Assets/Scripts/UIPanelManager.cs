using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIPanelManager : MonoBehaviour
{
    public enum UIPanel
    {
        ReturnToMainMenu,
        GameOver,
        NewHighscore,
    }

    public GameObject[] UILIST = new GameObject[Enum.GetNames(typeof(UIPanel)).Length];
    public InputField Nameinput;

    private static InputHandler inputhandler;
    private static OverHeating overheating;
    private static AmmoSystem ammosystem;
    private static EnemyManager manager;
    private static Timer timer;

    private bool updating = false;
    private string nameKey;
    private int scoreKey;
    private static GameObject[] uilist = new GameObject[Enum.GetNames(typeof(UIPanel)).Length];

    private static UnityStandardAssets.ImageEffects.BlurOptimized BlurEffect;

    // Use this for initialization
    private void Start()
    {
        for (int i = 0; i < Enum.GetNames(typeof(UIPanel)).Length; ++i)
        {
            UILIST[i].SetActive(false);
            uilist[i] = UILIST[i];
        }

        inputhandler = FindObjectOfType<InputHandler>();
        overheating = FindObjectOfType<OverHeating>();
        ammosystem = FindObjectOfType<AmmoSystem>();
        manager = FindObjectOfType<EnemyManager>();
        timer = FindObjectOfType<Timer>();

        BlurEffect = Camera.main.gameObject.GetComponent<UnityStandardAssets.ImageEffects.BlurOptimized>();
        BlurEffect.enabled = false;
    }

    // Update is called once per frame
    private void Update()
    {
        if (updating == true)
        {
            NewHighscore();
        }
    }

    static public void ShowUIPanel(UIPanel panel)
    {
        Cursor.visible = true;
        DisableScripts();
        uilist[(int)panel].SetActive(true);
        Time.timeScale = 0;
        BlurEffect.enabled = true;
    }

    static public void DisableUIPanel(UIPanel panel)
    {
        Cursor.visible = false;
        if (panel != UIPanelManager.UIPanel.NewHighscore)
        {
            EnableScripts();
        }
        uilist[(int)panel].SetActive(false);
        BlurEffect.enabled = false;
    }

    public void ClickedYes()
    {
        SoundManager.PlaySoundEffect(SoundManager.SoundEffect.ButtonClick);
        DisableScripts();
        ScoreManager.ResetCurrentScore();
        Time.timeScale = 1;
        for (int i = 0; i < Enum.GetNames(typeof(UIPanel)).Length; ++i)
        {
            UILIST[i].SetActive(false);
        }
        SceneManager.LoadScene(1);
    }

    public void ClickedNo()
    {
        SoundManager.PlaySoundEffect(SoundManager.SoundEffect.ButtonClick);
        EnableScripts();
        Time.timeScale = 1;
        DisableUIPanel(UIPanelManager.UIPanel.ReturnToMainMenu);
    }

    public void NewHighscore()
    {
        updating = true;
        DisableScripts();
        Time.timeScale = 0;
        UIPanelManager.ShowUIPanel(UIPanelManager.UIPanel.NewHighscore);
    }

    public void HighscorePanelYES()
    {
        SoundManager.PlaySoundEffect(SoundManager.SoundEffect.ButtonClick);
        nameKey = Nameinput.text;
        if (Nameinput.text == "")
        {
            nameKey = "Test";
        }
        updating = false;
        scoreKey = ScoreManager.CurrentScore;
        TextManager.Write(nameKey, scoreKey);
        UIPanelManager.DisableUIPanel(UIPanelManager.UIPanel.NewHighscore);
        UIPanelManager.ShowUIPanel(UIPanelManager.UIPanel.GameOver);
    }

    static private void DisableScripts()
    {
        inputhandler.enabled = false;
        overheating.enabled = false;
        ammosystem.enabled = false;
        manager.enabled = false;
        timer.enabled = false;
    }

    static private void EnableScripts()
    {
        inputhandler.enabled = true;
        overheating.enabled = true;
        ammosystem.enabled = true;
        manager.enabled = true;
        timer.enabled = true;
    }
}