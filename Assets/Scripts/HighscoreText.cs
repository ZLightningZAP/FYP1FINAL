using UnityEngine;
using UnityEngine.UI;

public class HighscoreText : MonoBehaviour
{
    private Text text;

    // Use this for initialization
    private void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    private void Update()
    {
        text.text = ScoreManager.CurrentScore.ToString("0");
    }
}