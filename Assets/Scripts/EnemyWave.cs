using UnityEngine;
using System.Collections.Generic;

public class EnemyWave : MonoBehaviour {

    public List<Enemy> Wave_5s = new List<Enemy>();
    public List<Enemy> Wave_10s = new List<Enemy>();
    public List<Enemy> Wave_15s = new List<Enemy>();
    public List<Enemy> Wave_20s = new List<Enemy>();
    public List<Enemy> Wave_25s = new List<Enemy>();
    public List<Enemy> Wave_30s = new List<Enemy>();

    private float timer;    //Used to keep track of elapsed time

    private bool Wave5s_Spawned;
    private bool Wave10s_Spawned;
    private bool Wave15s_Spawned;
    private bool Wave20s_Spawned;
    private bool Wave25s_Spawned;
    private bool Wave30s_Spawned;

    
	// Use this for initialization
	void Start () {
        timer = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;

        if(timer > 5.0f  && !Wave5s_Spawned)
        {
            for (int i = 0; i < Wave_5s.Count; i++)
            {
                Wave_5s[i].Triggeredmove = true;
                Wave_5s[i].gameObject.SetActive(true);
            }
            Wave5s_Spawned = true;
        }
        else if (timer > 5.0f && !Wave10s_Spawned)
        {
            for (int i = 0; i < Wave_10s.Count; i++)
            {
                Wave_10s[i].Triggeredmove = true;
                Wave_10s[i].gameObject.SetActive(true);
            }
            Wave10s_Spawned = true;
        }
        else if (timer > 5.0f && !Wave15s_Spawned)
        {
            for (int i = 0; i < Wave_15s.Count; i++)
            {
                Wave_15s[i].Triggeredmove = true;
                Wave_15s[i].gameObject.SetActive(true);
            }
            Wave15s_Spawned = true;
        }
        else if (timer > 5.0f && !Wave20s_Spawned)
        {
            for (int i = 0; i < Wave_20s.Count; i++)
            {
                Wave_20s[i].Triggeredmove = true;
                Wave_20s[i].gameObject.SetActive(true);
            }
            Wave20s_Spawned = true;
        }
        else if(timer > 5.0f  && !Wave25s_Spawned)
        {
            for (int i = 0; i < Wave_25s.Count; i++)
            {
                Wave_25s[i].Triggeredmove = true;
                Wave_25s[i].gameObject.SetActive(true);
            }
            Wave25s_Spawned = true;
        }
        else if (timer > 5.0f && !Wave30s_Spawned)
        {
            for (int i = 0; i < Wave_30s.Count; i++)
            {
                Wave_30s[i].Triggeredmove = true;
                Wave_30s[i].gameObject.SetActive(true);
            }
            Wave30s_Spawned = true;
        }
	}

}
