using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public List<Enemy> enemies = new List<Enemy>();
    public List<GameObject> CanBeSeen = new List<GameObject>();
    public static int trulyVisibleEnemy;

    private static int randomint;
    private static GameObject enemi;
    public static bool shoot = false;
    private static int randomagain = -1;
    public static int updatedCount;

    // Use this for initialization
    private void Start()
    {
        //Add any gameobject that has the enemy script into the list
        foreach (var enemy in FindObjectsOfType(typeof(Enemy)) as Enemy[])
        {
            enemies.Add(enemy);
        }
        for (int i = 0; i < enemies.Count; i++)
        {
            enemies[i].gameObject.SetActive(false);
        }

        trulyVisibleEnemy = 0;
        updatedCount = 0;
    }

    // Update is called once per frame
    private void Update()
    {
        if (updatedCount != trulyVisibleEnemy)
        {
            CameraMoved();
            NumberOnScreen();
        }
        else
        {
            if (shoot == false)
            {
                return;
            }
            else if (CameraMovement.Goingtoshoot == true)
            {
                Shooting();
                shoot = true;
            }
        }
    }

    public void NumberOnScreen()
    {
        foreach (Enemy e in enemies)
        {
            if (e.GetComponent<Enemy>().trulyVisible == true)
            {
                updatedCount += 1;
                trulyVisibleEnemy += 1;
                CanBeSeen.Add(e.gameObject);
            }
        }
    }

    public void CameraMoved()
    {
        updatedCount = 0;
        trulyVisibleEnemy = 0;
        randomagain = -1;
        CanBeSeen.Clear();
    }

    public void Shooting()
    {
        randomint = Random.Range(0, trulyVisibleEnemy);

        if (randomagain != randomint)
        {
            enemi = CanBeSeen[randomint];
            enemi.GetComponent<Enemy>().Shooting();
            randomagain = randomint;
        }
    }
}