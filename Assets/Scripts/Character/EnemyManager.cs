using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static List<Enemy> Enemy = new List<Enemy>();
    public static List<GameObject> CanBeSeen = new List<GameObject>();
    public static int trulyVisibleEnemy;

    private static int randomint;
    private static GameObject enemi;
    public static bool shoot = false;

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
        if (shoot == false)
        {
            CameraMovement.Goingtoshoot = false;
        }
        else if (CameraMovement.Goingtoshoot == true)
        {
            Shooting();
            shoot = true;
        }
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