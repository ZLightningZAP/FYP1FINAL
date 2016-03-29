using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine.UI;

public class HighscoreUsername : MonoBehaviour
{

    public TextAsset HighscoreFile;

    private Text text;
    private string display = "";
    private List<string> linesInFile = new List<string>();
    private List<string> HighscoreName = new List<string>();

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
        linesInFile = HighscoreFile.text.Split(' ', '\n').ToList();

        for (int i = 0; i < linesInFile.Count; i += 2)
        {
            HighscoreName.Add(linesInFile[i]);
        }
    }

    //Display something on the GUI canvas
    private void Display()
    {
        for (int i = 0; i < HighscoreName.Count; i++)
        {
            display = display.ToString() + HighscoreName[i] + "\n";
        }

        text.text = display;
    }
}
