using UnityEngine;

public class LifeTime : MonoBehaviour
{
    public float lifetime;  //Time Allowed to be alive

    private float lifeTimer;    //Used to track elapsed Time

    // Use this for initialization
    private void Start()
    {
        lifeTimer = 0.0f;
    }

    // Update is called once per frame
    private void Update()
    {
        lifeTimer += Time.deltaTime;

        //Destroy it once its lifetime is up
        if (lifeTimer > lifetime)
        {
            Destroy(gameObject);
        }
    }
}