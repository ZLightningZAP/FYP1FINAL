using UnityEngine;
using UnityEngine.UI;

public class BlinkingText : MonoBehaviour
{
    public float transitionTime = 1;
    public float waitTime = 2;

    private RawImage text;
    private bool gone = false;
    private float transition;
    private float wait;

    // Use this for initialization
    private void Start()
    {
        text = GetComponent<RawImage>();
        transition = transitionTime;
    }

    // Update is called once per frame
    private void Update()
    {
        TextTransitioning();
    }

    private void TextTransitioning()
    {
        transition += Time.deltaTime;

        if (gone == false && transition >= transitionTime)
        {
            wait += Time.deltaTime;
            if (wait >= waitTime)
            {
                text.CrossFadeAlpha(0.0f, transitionTime, false);
                gone = true;
                transition = 0;
                wait = 0;
            }
        }
        else if (gone == true && transition >= transitionTime)
        {
            text.CrossFadeAlpha(1.0f, transitionTime, false);
            gone = false;
            transition = 0;
        }
    }
}