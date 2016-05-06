using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<GameObject> Waypoint = new List<GameObject>();
    public List<Enemy> Enemylist = new List<Enemy>();

    private int randomwaypoint;
    private int randomenemi;

    // Use this for initialization
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public void Spawn()
    {
        randomwaypoint = Random.Range(0, Waypoint.Count);
        randomenemi = Random.Range(0, Enemylist.Count);

        Instantiate(Enemylist[randomenemi].gameObject, gameObject.transform.position, Quaternion.identity);
        Enemylist[randomenemi].Waypoint = Waypoint[randomwaypoint];
        Enemylist[randomenemi].Triggeredmove = true;
    }
}