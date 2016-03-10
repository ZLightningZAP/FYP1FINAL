using UnityEngine;
using System.Collections;

public class LifeTime : MonoBehaviour {

    public float lifetime;

    private float lifeTimer;

	// Use this for initialization
	void Start () {
        lifeTimer = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {

        lifeTimer += Time.deltaTime;

        if (lifeTimer > lifetime)
        {
            Destroy(gameObject);
        }
	}
}
