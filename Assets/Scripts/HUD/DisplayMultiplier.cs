using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DisplayMultiplier : MonoBehaviour
{
    private Text text;
    private int multiply;

    // Use this for initialization
    private void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    private void Update()
    {
        multiply = ScoreManager.CurrentMultiplier;
        text.text = multiply.ToString("0");
    }
}