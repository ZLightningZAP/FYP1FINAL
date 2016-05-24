using UnityEngine;

public class FrameRateController : MonoBehaviour
{
    // Use this for initialization
    private void Start()
    {
    }

    private void Awake()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    private void Update()
    {
    }
}