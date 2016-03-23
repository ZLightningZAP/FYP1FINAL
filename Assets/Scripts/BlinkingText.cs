using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BlinkingText : MonoBehaviour
{
    public float transitionTime = 1;

    Text text;
    private bool gone;
    private float transition;

    // Use this for initialization
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        TextTransitioning();
    }

    void TextTransitioning()
    {
        transition += Time.deltaTime;

        if (gone == false && transition >= transitionTime)
        {
            text.CrossFadeAlpha(0.0f, transitionTime, false);
            gone = true;
            transition = 0;
        }
        else if (gone == true && transition >= transitionTime)
        {
            text.CrossFadeAlpha(1.0f, transitionTime, false);
            gone = false;
            transition = 0;
        }
    }
}
