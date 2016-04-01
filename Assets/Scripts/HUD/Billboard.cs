using UnityEngine;

public class Billboard : MonoBehaviour
{
    // Use this for initialization
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        transform.LookAt(Camera.main.transform.position, -Vector3.up);
    }
}