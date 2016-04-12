using UnityEngine;
using System.Collections;

public class DeactivateVFX : MonoBehaviour {

    public float lifetime;  //Time allowed to be alive

    private float lifeTimer;    //Timer to track elapsed time

    // Use this for initialization
    private void Start()
    {
        lifeTimer = 0.0f;
    }

    // Update is called once per frame
    private void Update()
    {
        lifeTimer += Time.deltaTime;

        //Deactivate the object once its lifetime is up
        if (lifeTimer > lifetime)
        {
            //Reset the timer
            lifeTimer = 0.0f;

            //Deactivate
            gameObject.SetActive(false);
        }
    }
}
