using UnityEngine;

public class TrackAnimation : MonoBehaviour
{
    public int materialIndex = 0;
    public float scrollSpeed;
    public string textureName = "_MainTex";

    // Use this for initialization
    private void Start()
    {
        scrollSpeed = 0.75f;
    }

    private void Update()
    {
        float offset = Time.time * scrollSpeed;

        if (GetComponent<Renderer>().enabled)
        {
            GetComponent<Renderer>().materials[materialIndex].SetTextureOffset(textureName, new Vector2(0, offset));
        }
    }
}