using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public static EnemyController current;

    public int PoolSize;    //Starting pool size
    public int GrowRate;    //Rate at which pool will grow when it is full

    public GameObject Canvas;   //World Canvas

    public GameObject EnemyMissile_Object; //Missile Object that will be pooled

    private List<GameObject> EnemyMissile_Pool; //List containing all enemy missiles in the scene

    //Every type of enemy available in game
    public enum ENEMY_TYPE
    {
        ENEMY_MISSILE,
        MAX_ENEMY,
    };

    // Use this for initialization
    private void Start()
    {
        InitializeMissilePool();
    }

    private void Awake()
    {
        current = this;
    }

    // Update is called once per frame
    private void Update()
    {
    }

    // Main function that will be called by other scripts to create VFX effects
    public GameObject SpawnEnemy(Vector3 position, Quaternion rotation, ENEMY_TYPE type)
    {
        switch (type)
        {
            case ENEMY_TYPE.ENEMY_MISSILE:
                return SpawnMissile(position, rotation);

            default:
                return null;
        }
    }

    /*************************************************
       Initialize Functions
     *************************************************/

    private void InitializeMissilePool()
    {
        //Only if object to be pooled is assigned
        if (EnemyMissile_Object != null)
        {
            //If pool does not exist
            if (EnemyMissile_Pool == null)
            {
                //Create new pool
                EnemyMissile_Pool = new List<GameObject>();
            }

            //Creating objects in the pool based on size
            for (int i = 0; i < PoolSize; i++)
            {
                GameObject obj = (GameObject)Instantiate(EnemyMissile_Object);
                obj.transform.SetParent(Canvas.transform);
                obj.SetActive(false);
                EnemyMissile_Pool.Add(obj);
            }
        }
    }

    /*************************************************
    Spawning Functions
    *************************************************/

    private GameObject SpawnMissile(Vector3 position, Quaternion rotation)
    {
        //Check if pool exists
        if (EnemyMissile_Pool != null)
        {
            //Getting the first non active game object in this pool
            for (int i = 0; i < EnemyMissile_Pool.Count; i++)
            {
                //Incase this game object is null, we create one and return it
                if (EnemyMissile_Pool[i] == null)
                {
                    GameObject obj = (GameObject)Instantiate(EnemyMissile_Object);

                    obj.transform.position = position;
                    obj.transform.rotation = rotation;
                    obj.SetActive(true);
                    EnemyMissile_Pool[i] = obj;
                    return EnemyMissile_Pool[i];
                }
                //Reuse when game object is not active
                if (!EnemyMissile_Pool[i].activeInHierarchy)
                {
                    EnemyMissile_Pool[i].transform.position = position;
                    EnemyMissile_Pool[i].transform.rotation = rotation;
                    EnemyMissile_Pool[i].SetActive(true);
                    return EnemyMissile_Pool[i];
                }
            }

            //Increase the size of the list based on the grow rate
            for (int i = 0; i < GrowRate; i++)
            {
                GameObject obj = (GameObject)Instantiate(EnemyMissile_Object);
                obj.SetActive(false);
                EnemyMissile_Pool.Add(obj);

                //When we have finished adding the new elements
                if (i == (GrowRate - 1))
                {
                    EnemyMissile_Pool[EnemyMissile_Pool.Count - 1].SetActive(true);
                    return EnemyMissile_Pool[EnemyMissile_Pool.Count - 1];
                }
            }
        }

        //If it reaches here, grow rate is 0 and
        //all elements in the list is already in use
        // OR
        //No game object is assigned thus pool is not created

        return null;
    }
}