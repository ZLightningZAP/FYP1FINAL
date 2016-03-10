using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PrintObjective : MonoBehaviour
{
    Text text;
    private int objectivetextsize;

    // Use this for initialization
    void Start()
    {
        // Set up the reference.
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (manager.CurrentObjective)
        //{
        //    objectivetextsize = manager.CurrentObjective.GetDescription().ToString().Length;
        //    if (objectivetextsize >= 25)
        //    {
        //        text.fontSize = 20;
        //        text.text = manager.CurrentObjective.GetDescription().ToString();
        //    }
        //    else if (objectivetextsize <= 24)
        //    {
        //        text.fontSize = 25;
        //        text.text = manager.CurrentObjective.GetDescription().ToString();
        //    }
        //}    
    }
}
