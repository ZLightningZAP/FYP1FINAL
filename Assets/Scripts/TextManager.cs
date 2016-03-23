using UnityEngine;
using System.Collections;
using System.IO;
using System;

public class TextManager : MonoBehaviour
{
    public TextAsset textfile;

    private StreamWriter sw;
    private string[] linesInFile;

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
        linesInFile = textfile.text.Split(' ', '\n');

        //Debugging Line
        //foreach (string line in linesInFile)
        //{
        //    Debug.Log(line);
        //}
    }

    //Write to the text file
    public void Write()
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
