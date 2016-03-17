using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    //Set the starting timer countdown to start from 10
    public float TimerCountdown = 0;
    public Text text;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Timer will countdown using delta time
        TimerCountdown += Time.deltaTime;
        //Timer countdown is converted to string with 1 d.p
        text.text = TimerCountdown.ToString("F1");
    }
}
