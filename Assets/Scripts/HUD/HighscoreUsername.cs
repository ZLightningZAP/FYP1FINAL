using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreUsername : MonoBehaviour
{
    private Text text;
    private string display = "";

    // Use this for initialization
    private void Start()
    {
        text = GetComponentInChildren<Text>();
        Display();
    }

    // Update is called once per frame
    private void Update()
    {
    }

    //Display something on the GUI canvas
    private void Display()
    {
        for (int i = 0; i < TextManager.Names.Count; i++)
        {
            display = display.ToString() + TextManager.Names[i] + "\n" + "\n";
        }

        text.text = display;
    }
}