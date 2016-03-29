using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine.UI;

public class HighscoreScore : MonoBehaviour {

    public TextAsset HighscoreFile;

    private Text text;
    private string display = "";
    private List<string> linesInFile = new List<string>();
    private List<int> HS = new List<int>();

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

        for (int i = 1; i < linesInFile.Count; i += 2)
        {
            int result;
            Int32.TryParse(linesInFile[i], out result);
            HS.Add(result);
        }
    }

    //Display something on the GUI canvas
    private void Display()
    {
        for (int i = 0; i < HS.Count; i++)
        {
            display = display.ToString() + HS[i] + "\n";
        }

        text.text = display;
    }
}
