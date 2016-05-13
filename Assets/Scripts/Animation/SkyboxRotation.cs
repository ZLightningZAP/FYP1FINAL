using UnityEngine;
using System.Collections;

public class SkyboxRotation : MonoBehaviour {

    public float RotationSpeed;
    private float Angle;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Angle += Time.deltaTime * RotationSpeed;

        RenderSettings.skybox.SetFloat("_Rotation", Angle);
	}
}
