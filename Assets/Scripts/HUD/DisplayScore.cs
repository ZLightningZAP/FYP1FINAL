﻿using UnityEngine;
using UnityEngine.UI;

public class DisplayScore : MonoBehaviour
{
    public Text text;
    private int oldscore;
    private int newscore;

    // Use this for initialization
    private void Start()
    {
        oldscore = 0;
        newscore = 0;
    }

    // Update is called once per frame
    private void Update()
    {
        newscore = ScoreManager.CurrentScore;

        if (newscore > oldscore)
        {
            oldscore += 1;
            text.text = oldscore.ToString();
        }
        else
        {
            text.text = newscore.ToString();
        }
    }
}