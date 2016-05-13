using UnityEngine;
using System.Collections;

public class TrafficLightFlicker : MonoBehaviour {

    public Material OriginalMaterial;
    public Material SecondMaterial;

    public float TimeBeforeSwitch;

    private float timer;
    private Renderer meshrenderer;
    private Material prevMaterial;
	// Use this for initialization
	void Start () {
        meshrenderer = gameObject.gameObject.GetComponent<Renderer>();
        prevMaterial = OriginalMaterial;
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;

        if(timer > TimeBeforeSwitch)
        {
            if(prevMaterial == OriginalMaterial)
            {
                meshrenderer.material = SecondMaterial;
                prevMaterial = SecondMaterial;
                print("change");
            }
            else
            {
                meshrenderer.material = OriginalMaterial;
                prevMaterial = OriginalMaterial;
                print("change 2");
            }
            timer = 0;
        }
	}
}
