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
        DisableScripts();
        uilist[(int)panel].SetActive(true);
        Time.timeScale = 0;
    }

    static public void DisableUIPanel(UIPanel panel)
    {
        if (panel != UIPanelManager.UIPanel.NewHighscore)
        {
            EnableScripts();
        }
        uilist[(int)panel].SetActive(false);
        Time.timeScale = 0;
    }

    public void ClickedYes()
    {
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
        EnableScripts();
        Time.timeScale = 1;
        DisableUIPanel(UIPanelManager.UIPanel.ReturnToMainMenu);
    }

    public void NewHighscore()
    {
        updating = true;
        DisableScripts();
        Time.timeScale = 0;
        UIPanelManager.ShowUIPanel(UIPanelManager.UIPanel.GameOver);
        UIPanelManager.ShowUIPanel(UIPanelManager.UIPanel.NewHighscore);
    }

    public void HighscorePanelYES()
    {
        nameKey = Nameinput.text;
        if (Nameinput.text == "")
        {
            nameKey = "Test";
        }
        updating = false;
        scoreKey = ScoreManager.CurrentScore;
        TextManager.Write(nameKey, scoreKey);
        UIPanelManager.DisableUIPanel(UIPanelManager.UIPanel.NewHighscore);
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