using UnityEngine;
using System.Collections;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;

public class TextManager : MonoBehaviour
{
    public TextAsset textfile;

    private StreamWriter writer;
    private List<string> linesInFile = new List<string>();
    private List<string> Names = new List<string>();
    private List<int> Score = new List<int>();
    private bool added = false;

    //Use this for initialization
    void Start()
    {
        Read();
        //Write("KEITH", 88888);
    }

    //Update is called once per frame
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
    //HIGHEST SCORE IS IN THE FRONT OF THE LIST
    //LIST STARTS FROM 0
    //NAME <= 5 CHARACTERS
    public void Write(string name, int score)
    {
        added = false;

        //Check if the score is less than the last highscore on the list
        if (score < Score[Score.Count - 1])
        {
            return;
        }
        else
        {
            for (int i = 0; i < Score.Count; i++)
            {
                //Check if the score is equal to any of the score on the list
                if (score == Score[i])
                {
                    //Add the score into the list
                    if (added == false)
                    {
                        //Insert the score below the same score
                        Score.Insert(i + 1, score);
                        Names.Insert(i + 1, name);
                        added = true;
                    }

                    //Check if the list size is more than 10
                    if (Score.Count >= 11)
                    {
                        //Remove the 11 score from the list
                        Score.Remove(Score[Score.Count - 1]);
                        Names.Remove(Names[Names.Count - 1]);
                    }

                    writer = new StreamWriter("Assets/Text File/Highscore.txt");
                    for (int o = 0; o < Score.Count; o++)
                    {
                        if (o < Score.Count - 1)
                        {
                            writer.WriteLine(Names[o] + " " + Score[o]);
                        }
                        else
                        {
                            writer.Write(Names[o] + " " + Score[o]);
                        }

                    }
                    writer.Close();

                    return;
                }

                    //Check if the score is higher than any of the score on the list
                else if (score >= Score[i])
                {
                    //Add the score infront of the first score
                    if (added == false)
                    {
                        //Insert the score below the same score
                        Score.Insert(i, score);
                        Names.Insert(i, name);
                        added = true;
                    }

                    //Check if the list size is more than 10
                    if (Score.Count >= 11)
                    {
                        //Remove the 11 score from the list
                        Score.Remove(Score[Score.Count - 1]);
                        Names.Remove(Names[Names.Count - 1]);
                    }

                    writer = new StreamWriter("Assets/Text File/Highscore.txt");
                    for (int o = 0; o < Score.Count; o++)
                    {
                        if (o < Score.Count - 1)
                        {
                            writer.WriteLine(Names[o] + " " + Score[o]);
                        }
                        else
                        {
                            writer.Write(Names[o] + " " + Score[o]);
                        }
                    }
                    writer.Close();

                    return;
                }
            }
        }
    }
}
