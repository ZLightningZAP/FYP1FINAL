using UnityEngine;

public class LifeTime : MonoBehaviour
{
    public float lifetime;

    private float lifeTimer;

    // Use this for initialization
    private void Start()
    {
        lifeTimer = 0.0f;
    }

    // Update is called once per frame
    private void Update()
    {
        lifeTimer += Time.deltaTime;

        if (lifeTimer > lifetime)
        {
            Destroy(gameObject);
        }
    }
}