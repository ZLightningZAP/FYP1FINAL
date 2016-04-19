using System.Collections.Generic;
using UnityEngine;

public class DroneSpawner : MonoBehaviour
{
    public List<Enemy> dronelist = new List<Enemy>();

    public GameObject canvas;

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
        SpawnDrones();
    }

    private void SpawnDrones()
    {
        for (int i = 0; i < dronelist.Count; i++)
        {
            dronelist[i].gameObject.SetActive(true);
        }

        //Set the parent of the gameobject to the world canvas
        //enemy.transform.SetParent(canvas.transform);
    }
}