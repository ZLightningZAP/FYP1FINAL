using UnityEngine;
using UnityEngine.UI;

public class SliderAuto : MonoBehaviour
{
    public float Speed;

    private Scrollbar slider;

    public float waittime;
    private float timer;
    private bool goingup;

    // Use this for initialization
    private void Start()
    {
        slider = GetComponentInChildren<Scrollbar>();
        slider.value = 0;
        goingup = true;

        SoundManager.PlayBackgroundMusic(SoundManager.BackgroundMusic.MainMenu);

    }

    // Update is called once per frame
    private void Update()
    {
        timer += Time.deltaTime;

        if (goingup)
        {
            SlideUp();
        }
        else
        {
            SlideDown();
        }
    }

    private void SlideUp()
    {
        slider.value += Speed * Time.deltaTime;
        if (slider.value >= 1)
        {
            slider.value = 1;

            if (timer >= waittime)
            {
                if (goingup)
                {
                    goingup = false;
                }
                else
                {
                    goingup = true;
                }

                timer = 0;
            }
        }
    }

    private void SlideDown()
    {
        slider.value -= Speed * Time.deltaTime;
        if (slider.value <= 0)
        {
            slider.value = 0;

            if (timer >= waittime)
            {
                if (goingup)
                {
                    goingup = false;
                }
                else
                {
                    goingup = true;
                }

                timer = 0;
            }
        }
    }

    private void Reset()
    {
        slider.value = 0;
    }
}