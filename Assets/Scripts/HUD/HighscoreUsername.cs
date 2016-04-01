using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreUsername : MonoBehaviour
{
    public TextAsset HighscoreFile;

    private Text text;
    private string display = "";
    private List<string> linesInFile = new List<string>();
    private List<string> HighscoreName = new List<string>();

    // Use this for initialization
    private void Start()
    {
        text = GetComponentInChildren<Text>();
        Read();
        Display();
    }

    // Update is called once per frame
    private void Update()
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
            display = display.ToString() + HighscoreName[i] + "\n" + "\n";
        }

        text.text = display;
    }
}