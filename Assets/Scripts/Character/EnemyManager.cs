using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static List<Enemy> Enemy = new List<Enemy>();
    private static List<GameObject> CanBeSeen = new List<GameObject>();
    public static int trulyVisibleEnemy;

    private static int randomint;
    private static GameObject enemi;

    // Use this for initialization
    private void Start()
    {
        //Add any gameobject that has the enemy script into the list
        foreach (var enemy in FindObjectsOfType(typeof(Enemy)) as Enemy[])
        {
            Enemy.Add(enemy);
        }

        trulyVisibleEnemy = 0;
    }

    // Update is called once per frame
    private void Update()
    {
        Shooting();
    }

    public static void NumberOnScreen()
    {
        foreach (Enemy e in Enemy)
        {
            if (e.GetComponent<Enemy>().trulyVisible == true)
            {
                trulyVisibleEnemy += 1;
                CanBeSeen.Add(e.gameObject);
            }
        }
    }

    public static void CameraMoved()
    {
        trulyVisibleEnemy = 0;
        CanBeSeen.Clear();
    }

    public static void Shooting()
    {
        randomint = Random.Range(0, trulyVisibleEnemy);
        enemi = CanBeSeen[randomint];
        enemi.GetComponent<Enemy>().Shooting();
    }
}