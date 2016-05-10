using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIPanelManager : MonoBehaviour
{
    public enum UIPanel
    {
        ReturnToMainMenu,
        GameOver,
        NewHighscore,
    }

    public GameObject[] UILIST = new GameObject[Enum.GetNames(typeof(UIPanel)).Length];

    private static GameObject[] uilist = new GameObject[Enum.GetNames(typeof(UIPanel)).Length];

    // Use this for initialization
    private void Start()
    {
        for (int i = 0; i < Enum.GetNames(typeof(UIPanel)).Length; ++i)
        {
            UILIST[i].SetActive(false);
            uilist[i] = UILIST[i];
        }
    }

    // Update is called once per frame
    private void Update()
    {
    }

    static public void ShowUIPanel(UIPanel panel)
    {
        uilist[(int)panel].SetActive(true);
        Time.timeScale = 0;
    }

    static public void DisableUIPanel(UIPanel panel)
    {
        uilist[(int)panel].SetActive(false);
        Time.timeScale = 1;
    }

    public void ClickedYes()
    {
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
        Time.timeScale = 1;
        DisableUIPanel(UIPanelManager.UIPanel.ReturnToMainMenu);
    }
}