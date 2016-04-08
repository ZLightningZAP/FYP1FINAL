using UnityEngine;

public class Crosshair : MonoBehaviour
{
    private GameObject WiiController;

    // Use this for initialization
    private void Start()
    {
        WiiController = GameObject.Find("WiiController");
    }

    // Update is called once per frame
    private void Update()
    {
        transform.position = WiiController.GetComponent<WiiConnection>().IRposition;
    }
}