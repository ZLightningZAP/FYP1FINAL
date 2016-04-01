using UnityEngine;

public class CameraShaking : MonoBehaviour
{
    public CameraMovement MainCamera;

    // Use this for initialization
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void OnTriggerEnter(Collider collision)
    {
        MainCamera.goingtoshake = true;
        if (collision.gameObject.name == "Main Camera")
        {
            GameObject.Find("Main Camera").SendMessage("Shake");
        }
    }
}