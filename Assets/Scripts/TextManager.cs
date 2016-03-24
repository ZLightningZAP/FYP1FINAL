using UnityEngine;
using System.Collections;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;

public class TextManager : MonoBehaviour
{
    public TextAsset textfile;

    private List<string> linesInFile = new List<string>();
    private List<string> Names = new List<string>();
    private List<int> Score = new List<int>();

    // Use this for initialization
    void Start()
    {
        Read();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //Read the text file
    private void Read()
    {
        linesInFile = textfile.text.Split(' ', '\n').ToList();

        for (int i = 0; i < linesInFile.Count; i += 2)
        {
            Names.Add(linesInFile[i]);
        }

        for (int i = 1; i < linesInFile.Count; i += 2)
        {
            int result;
            Int32.TryParse(linesInFile[i], out result);
            Score.Add(result);
        }
    }

    //Write to the text file
    public void Write(string name, int score)
    {
        //sw.WriteLine("HIGHSCORE FILE");
        //sw.WriteLine("--------------");
        //sw.WriteLine();
        //for (int i = 1; i <= HighscoreAmount; i++)
        //{
        //    sw.WriteLine(i + ")");
        //}
    }
}
