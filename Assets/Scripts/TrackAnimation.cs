using UnityEngine;
using System.Collections;

public class TrackAnimation : MonoBehaviour {

    public int materialIndex = 0;
    public float scrollSpeed;
    public string textureName = "_MainTex";

	// Use this for initialization
	void Start () {
        scrollSpeed = 0.75f;
	}

    void Update()
    {
        float offset = Time.time * scrollSpeed;

        if (GetComponent<Renderer>().enabled)
        {
            GetComponent<Renderer>().materials[materialIndex].SetTextureOffset(textureName, new Vector2(0,offset));
        }
    }
}
