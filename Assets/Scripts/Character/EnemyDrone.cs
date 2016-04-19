using System.Collections;
using UnityEngine;

public class EnemyDrone : MonoBehaviour
{
    //Movement speed of the drone
    public float movementSpeed = 10f;

    public float MissileDelay;
    public float dieTimer;
    public GameObject Missile;

    private bool spawned = false;

    private float timekeeper;

    // Use this for initialization
    private void Start()
    {
        //Set the game object to be false on start
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
        if (gameObject.activeSelf == true)
        {
            gameObject.transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
            timekeeper += Time.deltaTime;

            if (timekeeper >= MissileDelay && spawned == false)
            {
                Missile.SetActive(true);
                spawned = true;
            }
            if (timekeeper >= dieTimer)
            {
                gameObject.SetActive(false);
            }
        }
    }
}