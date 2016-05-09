using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject waypoint;

    private int randomwaypoint;
    private GameObject enemi;
    private int randomenemi;

    private float timer;
    private float ChanceUpdateTime;

    private int V200SpawnChance;
    private int M113SpawnChance;
    private int AMX10SpawnChance;

    // Use this for initialization
    private void Start()
    {
        timer = 0.0f;
        ChanceUpdateTime = 6.0f;
        V200SpawnChance = 100;
        M113SpawnChance = 0;
        AMX10SpawnChance = 0;
    }

    // Update is called once per frame
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= ChanceUpdateTime)
        {
            UpdateSpawnChances();
            timer = 0.0f;
        }
    }

    public void Spawn()
    {
        int rand = Random.Range(1, 101);
        if (rand <= V200SpawnChance)
        {
            enemi = EnemyController.current.SpawnEnemy(transform.position, Quaternion.identity, EnemyController.ENEMY_TYPE.ENEMY_V200);
        }
        else if (rand > V200SpawnChance && rand <= V200SpawnChance + M113SpawnChance)
        {
            enemi = EnemyController.current.SpawnEnemy(transform.position, Quaternion.identity, EnemyController.ENEMY_TYPE.ENEMY_M113);
        }
        else
        {
            enemi = EnemyController.current.SpawnEnemy(transform.position, Quaternion.identity, EnemyController.ENEMY_TYPE.ENEMY_AMX10);
        }
        enemi.GetComponent<Enemy>().Heal(100);
        enemi.GetComponent<Enemy>().Waypoint = waypoint;
        enemi.GetComponent<Enemy>().Rotate();
        enemi.GetComponent<Enemy>().Triggeredmove = true;
    }

    private void UpdateSpawnChances()
    {
        V200SpawnChance -= 20;
        M113SpawnChance += 15;
        AMX10SpawnChance += 5;
    }

    public GameObject GetEnemi()
    {
        return enemi;
    }
}