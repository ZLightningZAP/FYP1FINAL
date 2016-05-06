using System.Collections.Generic;
using UnityEngine;

public class EnemyRandomSpawn : MonoBehaviour
{
    public List<EnemySpawner> Spawners = new List<EnemySpawner>();
    public float SpawnXSecond = 2f;

    private float timer;
    private int randomnumber;

    // Use this for initialization
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= SpawnXSecond)
        {
            ChooseSpawn();
            timer = 0;
        }
    }

    private void ChooseSpawn()
    {
        randomnumber = Random.Range(0, Spawners.Count);
        Spawners[randomnumber].Spawn();
    }
}