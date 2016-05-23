using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    public List<Enemy> enemylist = new List<Enemy>();
    public List<EnemyBoss> bosslist = new List<EnemyBoss>();

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
        //print(gameObject.transform.name);
        for (int i = 0; i < enemylist.Count; i++)
        {
            enemylist[i].Triggeredmove = true;
            enemylist[i].gameObject.SetActive(true);
        }
        for (int i = 0; i < bosslist.Count; i++)
        {
            bosslist[i].gameObject.SetActive(true);
        }
    }
}