using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DisplayMultiplier : MonoBehaviour
{
    private Text text;
    private float multiply;

    // Use this for initialization
    private void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    private void Update()
    {
        multiply = ScoreManager.CurrentMultiplier;
        text.text = "x" + multiply.ToString("0");
    }
}