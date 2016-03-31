using UnityEngine;
using System.Collections;

public class CameraShaking : MonoBehaviour
{
    public CameraMovement MainCamera;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider collision)
    {

        MainCamera.goingtoshake = true;
        if(collision.gameObject.name == "Main Camera")
        {
            GameObject.Find("Main Camera").SendMessage("Shake");
        }
    }
}
