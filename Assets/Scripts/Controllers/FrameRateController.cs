using UnityEngine;
using System.Collections;

public class FrameRateController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    void Awake()
    {
        Application.targetFrameRate = 60;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
