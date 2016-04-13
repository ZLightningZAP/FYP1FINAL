using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<Enemy> enemylist = new List<Enemy>();

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
        Spawnenemies();
    }

    private void Spawnenemies()
    {
        for (int i = 0; i < enemylist.Count; i++)
        {
            enemylist[i].gameObject.SetActive(true);
        }

        //Set the parent of the gameobject to the world canvas
        //enemy.transform.SetParent(canvas.transform);
    }
}