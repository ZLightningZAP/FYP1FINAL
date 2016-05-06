using UnityEngine;
using UnityEngine.UI;

public class HighscoreNumber : MonoBehaviour
{
    private Text text;
    private string display = "";
    private int linesInFile;

    // Use this for initialization
    private void Start()
    {
        text = GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (TextManager.read == true)
        {
            Read();
            Display();
            TextManager.read = false;
        }
    }

    //Read the text file
    private void Read()
    {
        linesInFile = TextManager.Tempdata.Count;
    }

    //Display something on the GUI canvas
    private void Display()
    {
        for (int i = 0; i < linesInFile; i++)
        {
            display = display.ToString() + (i + 1) + ". " + "\n" + "\n";
        }

        text.text = display;
    }
}