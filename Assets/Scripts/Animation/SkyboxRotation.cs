using UnityEngine;

public class SkyboxRotation : MonoBehaviour
{
    public float RotationSpeed;
    private float Angle;

    // Use this for initialization
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        Angle += Time.deltaTime * RotationSpeed;

        RenderSettings.skybox.SetFloat("_Rotation", Angle);
    }
}