using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SliderAuto : MonoBehaviour
{
    public float Speed;
    public MainMenuTransition mainmenu;

    private Scrollbar slider;
    private float transitiontime;
    private float waittime;

    private float time;
    private float secondtime;

    // Use this for initialization
    void Start()
    {
        slider = GetComponentInChildren<Scrollbar>();
        transitiontime = mainmenu.TransitionTiming;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time >= transitiontime + 1)
        {
            Slide();
        }
        if(time >= transitiontime * 2)
        {
            time = 0;
        }

        if(slider.value == 1)
        {
            secondtime += Time.deltaTime;
            if(secondtime >= 3)
            {
                Reset();
                secondtime = 0;
            }
        }

    }

    void Slide()
    {
        slider.value += Speed;
    }

    void Reset()
    {
        slider.value = 0;
    }
}
