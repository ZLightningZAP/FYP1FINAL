using System.Collections.Generic;
using UnityEngine;

public class DroneSpawner : MonoBehaviour
{
    public List<EnemyDrone> dronelist = new List<EnemyDrone>();

    public GameObject canvas;

    public int chance;
    private int random;
    private bool spawned = false;

    // Use this for initialization
    private void Start()
    {
        gameObject.GetComponent<Renderer>().enabled = false;
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        random = Random.Range(0, 101);
        if (random <= chance && spawned == false)
        {
            SpawnDrones();
            spawned = true;
        }
    }

    private void SpawnDrones()
    {
        for (int i = 0; i < dronelist.Count; i++)
        {
            dronelist[i].gameObject.SetActive(true);
            dronelist[i].gameObject.transform.SetParent(canvas.transform);
        }
    }
}