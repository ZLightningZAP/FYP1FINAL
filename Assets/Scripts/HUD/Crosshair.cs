using UnityEngine;
using System.Collections;

public class Crosshair : MonoBehaviour {

    private GameObject WiiController;
	// Use this for initialization
	void Start () {

        WiiController = GameObject.Find("WiiController");
	}
	
	// Update is called once per frame
	void Update () {

        transform.position = WiiController.GetComponent<WiiConnection>().IRposition;
	}
}
