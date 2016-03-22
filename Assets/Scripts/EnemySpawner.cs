using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    //Public variables
    public GameObject Enemyprefab;
    public GameObject canvas;
    public float AmountToSpawn;
    public float Interval;

    //Private variable
    private float Spawntimer = 0;
    private int spawned = 0;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        Spawnenemies();
    }

    void Spawnenemies()
    {
        //Debug.Log("Triggered");

        //Add delta time to the spawn timer
        Spawntimer += Time.deltaTime;

        //Check if spawntimer is more than the interval && the spawned amount is not more than the specified amount
        if (Spawntimer >= Interval && spawned != AmountToSpawn)
        {
            //Create the enemy prefab and the current position
            GameObject enemy = Instantiate(Enemyprefab, transform.position, Quaternion.identity) as GameObject;
            //Set the parent of the gameobject to the world canvas
            enemy.transform.SetParent(canvas.transform);
            
            Spawntimer = 0;
            spawned += 1;
        }
    }
}
