using UnityEngine;

public class TrackAnimation : MonoBehaviour
{
    private int materialIndex = 0;   //Material Index for object
    public float BaseScrollSpeed;   //Speed at which the UV will scroll
    private string textureName = "_MainTex"; //Directory of texture
    public GameObject TankToAnimate; //Enemy reference

    // Use this for initialization
    private void Start()
    {
        BaseScrollSpeed = 0.75f;
    }

    private void Update()
    {
        float offset = Time.time * BaseScrollSpeed;

        //Only do this if reference object is moving and renderer is enabled
        if (GetComponent<Renderer>().enabled && TankToAnimate.GetComponent<Enemy>().GetMovingState() == true)
        {
            GetComponent<Renderer>().materials[materialIndex].SetTextureOffset(textureName, new Vector2(0, -offset));
        }
    }
}