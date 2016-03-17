using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float TimerCountdown = 10;
    public Text text;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Timer will countdown using delta time
        TimerCountdown -= Time.deltaTime;
        //Timer text is converted to string
        text.text = TimerCountdown.ToString("F1");
    }
}
