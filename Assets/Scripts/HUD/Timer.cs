using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    //Set the starting timer countdown to start from 10
    public float TimerCountdown = 0;

    public Text text;

    // Use this for initialization
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        //Timer will countdown using delta time
        TimerCountdown += Time.deltaTime;
        //Timer countdown is converted to string with 1 d.p
        text.text = TimerCountdown.ToString("F1");
    }
}