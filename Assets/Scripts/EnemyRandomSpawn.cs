using System.Collections.Generic;
using UnityEngine;

public class EnemyRandomSpawn : MonoBehaviour
{
    public List<EnemySpawner> Spawners = new List<EnemySpawner>();
    public float StartingSpawnRate = 2f;
    public float TimeBeforeIncreaseRate = 10.0f;

    private float timer;
    private int randomnumber;

    private float spawnRateTimer;

    // Use this for initialization
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        timer += Time.deltaTime;
        spawnRateTimer += Time.deltaTime;

        if (timer >= StartingSpawnRate)
        {
            ChooseSpawn();
            timer = 0;
        }

        if (spawnRateTimer >= TimeBeforeIncreaseRate)
        {
            StartingSpawnRate *= 0.5f;
            spawnRateTimer = 0.0f;
        }
    }

    private void ChooseSpawn()
    {
        for (int i = 0; i < Spawners.Count; ++i)
        {
            randomnumber = Random.Range(0, Spawners.Count);
            if (Spawners[randomnumber].GetEnemi() == null)
            {
                Spawners[randomnumber].Spawn();
                break;
            }
            else if (Spawners[randomnumber].GetEnemi().activeInHierarchy == false)
            {
                Spawners[randomnumber].Spawn();
                break;
            }
        }
    }
}