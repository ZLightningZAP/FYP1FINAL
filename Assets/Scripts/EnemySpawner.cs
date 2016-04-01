using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //Public variables
    public GameObject Enemyprefab;

    public GameObject canvas;
    public List<GameObject> Spawnlist;
    public float Interval;

    //Private variable
    private float Spawntimer = 0;

    // Use this for initialization
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        Spawnenemies();
    }

    private void Spawnenemies()
    {
        //Add delta time to the spawn timer
        Spawntimer += Time.deltaTime;

        //Check if spawntimer is more than the interval && the spawned amount is not more than the specified amount
        if (Spawntimer >= Interval)
        {
            for (int i = 0; i <= Spawnlist.Count; i++)
            {
                //Create the enemy prefab and the current position
                GameObject enemy = Instantiate(Enemyprefab, Spawnlist[i].transform.position, Quaternion.identity) as GameObject;

                //Set the parent of the gameobject to the world canvas
                enemy.transform.SetParent(canvas.transform);
            }

            //Reset the spawner timer and add 1 to enemy spawned on the world
            Spawntimer = 0;
        }
    }
}