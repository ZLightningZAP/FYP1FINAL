using UnityEngine;
using System.Collections;

public class MainMenuFade : MonoBehaviour {

    public GameObject UICanvas; //Main UI canvas

    private CanvasGroup UICanvas_Group; //UI Canvas's Component

    public float FadeInterval;  //Interval per fade
    public float FadeSpeed;    //Speed of animation

    private bool FadeIn;    //Controlling varaibles
    private bool FadeOut;

    private float timer;    //Timer to track
	// Use this for initialization
	void Start () {
        //Check if UICanvas is assigned first, then get its component once
        if(UICanvas != null)
        {
            UICanvas_Group = UICanvas.GetComponent<CanvasGroup>();
            UICanvas_Group.alpha = 0;
        }

        //Init
        FadeOut = false;
        FadeIn = false;
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;

        if(timer > FadeInterval)
        {
            if (UICanvas_Group.alpha <= 0)
            {
                FadeIn = true;
                FadeOut = false;
            }
            else if (UICanvas_Group.alpha >= 1)
            {
                FadeIn = false;
                FadeOut = true;
            }
            timer = 0;
        }

        Fade();
	}

    //Controls animation
    private void Fade()
    {
        if (FadeIn)
        {
            UICanvas_Group.alpha += FadeSpeed * Time.deltaTime;

            if (UICanvas_Group.alpha >= 1)
            {
                FadeIn = false;
                UICanvas_Group.alpha = 1;
            }
        }
        else if (FadeOut)
        {
            UICanvas_Group.alpha -= FadeSpeed * Time.deltaTime;

            if (UICanvas_Group.alpha <= 0)
            {
                FadeOut = false;
                UICanvas_Group.alpha = 0;
            }
        }
    }
}
