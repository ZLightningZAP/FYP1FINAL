using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class TextManager : MonoBehaviour
{
    private static StreamWriter writer;
    private static int result;
    public static List<string> Tempdata = new List<string>();
    public static List<string> linesInFile = new List<string>();
    public static List<string> Names = new List<string>();
    public static List<int> Score = new List<int>();
    private static bool added = false;
    public static bool read = false;

    //Use this for initialization
    private void Start()
    {
        Read();
        //Write("KEITH", 88888);
    }

    //Update is called once per frame
    private void Update()
    {
    }

    //Read the text file
    public void Read()
    {
        StreamReader reader = new StreamReader(Application.streamingAssetsPath + "/Highscore.txt");
        while (!reader.EndOfStream)
        {
            linesInFile.Add(reader.ReadLine());
        }

        for (int i = 0; i < linesInFile.Count; i++)
        {
            var temptempdata = (linesInFile[i].Split(' '));
            foreach (var data in temptempdata)
            {
                Tempdata.Add(data);
            }
        }

        for (int i = 0; i < Tempdata.Count; i += 2)
        {
            Names.Add(Tempdata[i]);
        }

        for (int i = 1; i < Tempdata.Count; i += 2)
        {
            Int32.TryParse(Tempdata[i], out result);
            Score.Add(result);
        }
        read = true;
        reader.Close();
    }

    //Write to the text file
    //HIGHEST SCORE IS IN THE FRONT OF THE LIST
    //LIST STARTS FROM 0
    //NAME <= 5 CHARACTERS
    public static void Write(string name, int score)
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

                    StreamWriter writer = new StreamWriter(Application.streamingAssetsPath + "/Highscore.txt");
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

                    StreamWriter writer = new StreamWriter(Application.streamingAssetsPath + "/Highscore.txt");
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