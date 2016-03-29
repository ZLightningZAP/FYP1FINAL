using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine.UI;

public class HighscoreNumber : MonoBehaviour
{
    public TextAsset HighscoreFile;

    private Text text;
    private string display = "";
    private int linesInFile;

    // Use this for initialization
    void Start()
    {
        text = GetComponentInChildren<Text>();
        Read();
        Display();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //Read the text file
    private void Read()
    {
        linesInFile = HighscoreFile.text.Split('\n').Count();
    }

    //Display something on the GUI canvas
    private void Display()
    {
        for (int i = 0; i < linesInFile; i++)
        {
            display = display.ToString() + (i + 1) + ". " + "\n";
        }

        text.text = display;
    }
}
