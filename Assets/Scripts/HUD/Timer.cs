using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    //Set the starting timer countdown to start from 10
    public float TimerCountUp = 0;

    public float CountingDownFrom = 30;

    private Text text;

    public bool Countdown = false;

    // Use this for initialization
    private void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Countdown == false)
        {
            //Timer will countdown using delta time
            TimerCountUp += Time.deltaTime;
            //Timer countdown is converted to string with 1 d.p
            text.text = TimerCountUp.ToString("F1");
        }
        else
        {
            //Timer will countdown using delta time
            CountingDownFrom -= Time.deltaTime;
            //Timer countdown is converted to string with 1 d.p
            text.text = CountingDownFrom.ToString("F1");

            if (CountingDownFrom <= 0)
            {
                UIPanelManager.ShowUIPanel(UIPanelManager.UIPanel.GameOver);
            }
        }
    }
}