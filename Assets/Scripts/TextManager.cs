using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using System.Linq;

public class TextManager : MonoBehaviour
{
    public TextAsset textfile;

    private List<string> linesInFile = new List<string>();
    private List<string> Names = new List<string>();
    private List<string> Score = new List<string>();

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
            Score.Add(linesInFile[i]);
        }

        //foreach (string line in Names)
        //{
        //    Debug.Log(line);
        //}
        //foreach (string line in Score)
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
