using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public static EnemyController current;

    public int PoolSize;    //Starting pool size
    public int GrowRate;    //Rate at which pool will grow when it is full

    public GameObject Canvas;   //World Canvas

    public GameObject EnemyMissile_Object; //Missile Object that will be pooled
    public GameObject EnemyM113_Object; //M113 Object that will be pooled
    public GameObject EnemyV200_Object; //V200 Object that will be pooled

    private List<GameObject> EnemyMissile_Pool; //List containing all enemy missiles in the scene
    private List<GameObject> EnemyM113_Pool;    //List containing all enemy m113 in the scene
    private List<GameObject> EnemyV200_Pool;    //List containing all enemy v200 in the scene

    //Every type of enemy available in game
    public enum ENEMY_TYPE
    {
        ENEMY_MISSILE,
        ENEMY_M113,
        ENEMY_V200,
        MAX_ENEMY,
    };

    // Use this for initialization
    private void Start()
    {
        InitializeMissilePool();
        InitializeM113Pool();
        InitializeV200Pool();
    }

    private void Awake()
    {
        current = this;
    }

    // Update is called once per frame
    private void Update()
    {
    }

    // Main function that will be called by other scripts to spawn enemies
    public GameObject SpawnEnemy(Vector3 position, Quaternion rotation, ENEMY_TYPE type)
    {
        switch (type)
        {
            case ENEMY_TYPE.ENEMY_MISSILE:
                return SpawnMissile(position, rotation);

            case ENEMY_TYPE.ENEMY_M113:
                return SpawnM113(position, rotation);

            case ENEMY_TYPE.ENEMY_V200:
                return SpawnV200(position, rotation);

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

    private void InitializeM113Pool()
    {
        //Only if object to be pooled is assigned
        if (EnemyM113_Object != null)
        {
            //If pool does not exist
            if (EnemyM113_Pool == null)
            {
                //Create new pool
                EnemyM113_Pool = new List<GameObject>();
            }

            //Creating objects in the pool based on size
            for (int i = 0; i < PoolSize; i++)
            {
                GameObject obj = (GameObject)Instantiate(EnemyM113_Object);
                obj.transform.SetParent(Canvas.transform);
                obj.SetActive(false);
                EnemyM113_Pool.Add(obj);
            }
        }
    }

    private void InitializeV200Pool()
    {
        //Only if object to be pooled is assigned
        if (EnemyV200_Object != null)
        {
            //If pool does not exist
            if (EnemyV200_Pool == null)
            {
                //Create new pool
                EnemyV200_Pool = new List<GameObject>();
            }

            //Creating objects in the pool based on size
            for (int i = 0; i < PoolSize; i++)
            {
                GameObject obj = (GameObject)Instantiate(EnemyV200_Object);
                obj.transform.SetParent(Canvas.transform);
                obj.SetActive(false);
                EnemyV200_Pool.Add(obj);
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

    private GameObject SpawnM113(Vector3 position, Quaternion rotation)
    {
        //Check if pool exists
        if (EnemyM113_Pool != null)
        {
            //Getting the first non active game object in this pool
            for (int i = 0; i < EnemyM113_Pool.Count; i++)
            {
                //Incase this game object is null, we create one and return it
                if (EnemyM113_Pool[i] == null)
                {
                    GameObject obj = (GameObject)Instantiate(EnemyM113_Object);

                    obj.transform.position = position;
                    obj.transform.rotation = rotation;
                    obj.SetActive(true);
                    EnemyM113_Pool[i] = obj;
                    return EnemyM113_Pool[i];
                }
                //Reuse when game object is not active
                if (!EnemyM113_Pool[i].activeInHierarchy)
                {
                    EnemyM113_Pool[i].transform.position = position;
                    EnemyM113_Pool[i].transform.rotation = rotation;
                    EnemyM113_Pool[i].SetActive(true);
                    return EnemyM113_Pool[i];
                }
            }

            //Increase the size of the list based on the grow rate
            for (int i = 0; i < GrowRate; i++)
            {
                GameObject obj = (GameObject)Instantiate(EnemyM113_Object);
                obj.SetActive(false);
                EnemyM113_Pool.Add(obj);

                //When we have finished adding the new elements
                if (i == (GrowRate - 1))
                {
                    EnemyM113_Pool[EnemyM113_Pool.Count - 1].SetActive(true);
                    return EnemyM113_Pool[EnemyM113_Pool.Count - 1];
                }
            }
        }

        //If it reaches here, grow rate is 0 and
        //all elements in the list is already in use
        // OR
        //No game object is assigned thus pool is not created

        return null;
    }

    private GameObject SpawnV200(Vector3 position, Quaternion rotation)
    {
        //Check if pool exists
        if (EnemyV200_Pool != null)
        {
            //Getting the first non active game object in this pool
            for (int i = 0; i < EnemyV200_Pool.Count; i++)
            {
                //Incase this game object is null, we create one and return it
                if (EnemyV200_Pool[i] == null)
                {
                    GameObject obj = (GameObject)Instantiate(EnemyV200_Object);

                    obj.transform.position = position;
                    obj.transform.rotation = rotation;
                    obj.SetActive(true);
                    EnemyV200_Pool[i] = obj;
                    return EnemyV200_Pool[i];
                }
                //Reuse when game object is not active
                if (!EnemyV200_Pool[i].activeInHierarchy)
                {
                    EnemyV200_Pool[i].transform.position = position;
                    EnemyV200_Pool[i].transform.rotation = rotation;
                    EnemyV200_Pool[i].SetActive(true);
                    return EnemyV200_Pool[i];
                }
            }

            //Increase the size of the list based on the grow rate
            for (int i = 0; i < GrowRate; i++)
            {
                GameObject obj = (GameObject)Instantiate(EnemyV200_Object);
                obj.SetActive(false);
                EnemyV200_Pool.Add(obj);

                //When we have finished adding the new elements
                if (i == (GrowRate - 1))
                {
                    EnemyV200_Pool[EnemyV200_Pool.Count - 1].SetActive(true);
                    return EnemyV200_Pool[EnemyV200_Pool.Count - 1];
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