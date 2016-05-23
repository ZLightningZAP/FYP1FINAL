using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public GameObject Lookpoint;
    public float WaitTime;

    // Use this for initialization
    private void Start()
    {
        gameObject.GetComponent<Renderer>().enabled = false;
    }

    // Update is called once per frame
    private void Update()
    {
    }
}