using System.Collections;
using UnityEngine;

public class EnemyDrone : MonoBehaviour
{
    //Movement speed of the drone
    public float movementSpeed = 10f;

    // Use this for initialization
    private void Start()
    {
        //Set the game object to be false on start
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
    }
}