using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject waypoint;
    public List<Enemy> Enemylist = new List<Enemy>();

    private int randomwaypoint;
    private GameObject enemi;
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
        randomenemi = Random.Range(0, Enemylist.Count);
        enemi = Instantiate(Enemylist[randomenemi].gameObject, gameObject.transform.position, Quaternion.identity) as GameObject;
        enemi.GetComponent<Enemy>().Waypoint = waypoint;
        enemi.GetComponent<Enemy>().Triggeredmove = true;
    }

    public GameObject GetEnemi()
    {
        return enemi;
    }
}