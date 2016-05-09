using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public static EnemyController current;

    public int PoolSize;    //Starting pool size
    public int GrowRate;    //Rate at which pool will grow when it is full

    public GameObject Canvas;   //World Canvas

    //Objects
    public GameObject EnemyMissile_Object; //Missile Object that will be pooled
    public GameObject EnemyV200_Object; //Enemy Object that will be pooled
    public GameObject EnemyM113_Object; //Enemy Object that will be pooled
    public GameObject EnemyAMX10_Object; //Enemy Object that will be pooled

    public GameObject V200RumbleType1_Object; //V200 Rumble Type 1 Object that will be pooled
    public GameObject V200RumbleType2_Object; //V200 Rumble Type 2 Object that will be pooled
    public GameObject V200RumbleType3_Object; //V200 Rumble Type 3 Object that will be pooled
    public GameObject V200RumbleType4_Object; //V200 Rumble Type 4 Object that will be pooled

    public GameObject M113RumbleType1_Object; //M113 Rumble Type 1 Object that will be pooled
    public GameObject M113RumbleType2_Object; //M113 Rumble Type 2 Object that will be pooled
    public GameObject M113RumbleType3_Object; //M113 Rumble Type 3 Object that will be pooled
    public GameObject M113RumbleType4_Object; //M113 Rumble Type 4 Object that will be pooled

    //Pools
    private List<GameObject> EnemyMissile_Pool;       //List containing all enemy missiles in the scene
    private List<GameObject> EnemyV200_Pool; //List containing all enemies of this type in the scene
    private List<GameObject> EnemyM113_Pool; //List containing all enemies of this type in the scene
    private List<GameObject> EnemyAMX10_Pool; //List containing all enemies of this type in the scene

    private List<GameObject> V200RumbleType1_Pool;    //List containing all V200 rumble type 1 in the scene
    private List<GameObject> V200RumbleType2_Pool;    //List containing all V200 rumble type 2 in the scene
    private List<GameObject> V200RumbleType3_Pool;    //List containing all V200 rumble type 3 in the scene
    private List<GameObject> V200RumbleType4_Pool;    //List containing all V200 rumble type 4 in the scene

    private List<GameObject> M113RumbleType1_Pool;    //List containing all M113 rumble type 1 in the scene
    private List<GameObject> M113RumbleType2_Pool;    //List containing all M113 rumble type 2 in the scene
    private List<GameObject> M113RumbleType3_Pool;    //List containing all M113 rumble type 3 in the scene
    private List<GameObject> M113RumbleType4_Pool;    //List containing all M113 rumble type 4 in the scene




    //Every type of enemy available in game
    public enum ENEMY_TYPE
    {
        ENEMY_MISSILE,
        ENEMY_V200,
        ENEMY_M113,
        ENEMY_AMX10,
        V200_RUMBLE_TYPE1,
        V200_RUMBLE_TYPE2,
        V200_RUMBLE_TYPE3,
        V200_RUMBLE_TYPE4,
        M113_RUMBLE_TYPE1,
        M113_RUMBLE_TYPE2,
        M113_RUMBLE_TYPE3,
        M113_RUMBLE_TYPE4,
        MAX_ENEMY,
    };

    // Use this for initialization
    private void Start()
    {
        InitializeMissilePool();
        InitializeEnemyPool();
        InitializeRumblePool();
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

            case ENEMY_TYPE.ENEMY_V200:
                return SpawnV200(position, rotation);

            case ENEMY_TYPE.ENEMY_M113:
                return SpawnM113(position, rotation);

            case ENEMY_TYPE.ENEMY_AMX10:
                return SpawnAMX10(position, rotation);

            case ENEMY_TYPE.V200_RUMBLE_TYPE1:
                return SpawnV200RumbleType1(position, rotation);

            case ENEMY_TYPE.V200_RUMBLE_TYPE2:
                return SpawnV200RumbleType2(position, rotation);

            case ENEMY_TYPE.V200_RUMBLE_TYPE3:
                return SpawnV200RumbleType3(position, rotation);

            case ENEMY_TYPE.V200_RUMBLE_TYPE4:
                return SpawnV200RumbleType4(position, rotation);

            case ENEMY_TYPE.M113_RUMBLE_TYPE1:
                return SpawnM113RumbleType1(position, rotation);

            case ENEMY_TYPE.M113_RUMBLE_TYPE2:
                return SpawnM113RumbleType2(position, rotation);

            case ENEMY_TYPE.M113_RUMBLE_TYPE3:
                return SpawnM113RumbleType3(position, rotation);

            case ENEMY_TYPE.M113_RUMBLE_TYPE4:
                return SpawnM113RumbleType4(position, rotation);

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

    private void InitializeEnemyPool()
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

        //Only if object to be pooled is assigned
        if (EnemyAMX10_Object != null)
        {
            //If pool does not exist
            if (EnemyAMX10_Pool == null)
            {
                //Create new pool
                EnemyAMX10_Pool = new List<GameObject>();
            }

            //Creating objects in the pool based on size
            for (int i = 0; i < PoolSize; i++)
            {
                GameObject obj = (GameObject)Instantiate(EnemyAMX10_Object);
                obj.transform.SetParent(Canvas.transform);
                obj.SetActive(false);
                EnemyAMX10_Pool.Add(obj);
            }
        }
    }

    private void InitializeRumblePool()
    {
        /****************
         * V200 Rumbles
         ****************/
        //Only if object to be pooled is assigned
        if (V200RumbleType1_Object != null)
        {
            //If pool does not exist
            if (V200RumbleType1_Pool == null)
            {
                //Create new pool
                V200RumbleType1_Pool = new List<GameObject>();
            }

            //Creating objects in the pool based on size
            for (int i = 0; i < PoolSize; i++)
            {
                GameObject obj = (GameObject)Instantiate(V200RumbleType1_Object);
                obj.transform.SetParent(Canvas.transform);
                obj.SetActive(false);
                V200RumbleType1_Pool.Add(obj);
            }
        }

        //Only if object to be pooled is assigned
        if (V200RumbleType2_Object != null)
        {
            //If pool does not exist
            if (V200RumbleType2_Pool == null)
            {
                //Create new pool
                V200RumbleType2_Pool = new List<GameObject>();
            }

            //Creating objects in the pool based on size
            for (int i = 0; i < PoolSize; i++)
            {
                GameObject obj = (GameObject)Instantiate(V200RumbleType2_Object);
                obj.transform.SetParent(Canvas.transform);
                obj.SetActive(false);
                V200RumbleType2_Pool.Add(obj);
            }
        }

        //Only if object to be pooled is assigned
        if (V200RumbleType3_Object != null)
        {
            //If pool does not exist
            if (V200RumbleType3_Pool == null)
            {
                //Create new pool
                V200RumbleType3_Pool = new List<GameObject>();
            }

            //Creating objects in the pool based on size
            for (int i = 0; i < PoolSize; i++)
            {
                GameObject obj = (GameObject)Instantiate(V200RumbleType3_Object);
                obj.transform.SetParent(Canvas.transform);
                obj.SetActive(false);
                V200RumbleType3_Pool.Add(obj);
            }
        }

        //Only if object to be pooled is assigned
        if (V200RumbleType4_Object != null)
        {
            //If pool does not exist
            if (V200RumbleType4_Pool == null)
            {
                //Create new pool
                V200RumbleType4_Pool = new List<GameObject>();
            }

            //Creating objects in the pool based on size
            for (int i = 0; i < PoolSize; i++)
            {
                GameObject obj = (GameObject)Instantiate(V200RumbleType4_Object);
                obj.transform.SetParent(Canvas.transform);
                obj.SetActive(false);
                V200RumbleType4_Pool.Add(obj);
            }
        }

        /****************
         * M113 Rumbles
         ****************/
        //Only if object to be pooled is assigned
        if (M113RumbleType1_Object != null)
        {
            //If pool does not exist
            if (M113RumbleType1_Pool == null)
            {
                //Create new pool
                M113RumbleType1_Pool = new List<GameObject>();
            }

            //Creating objects in the pool based on size
            for (int i = 0; i < PoolSize; i++)
            {
                GameObject obj = (GameObject)Instantiate(M113RumbleType1_Object);
                obj.transform.SetParent(Canvas.transform);
                obj.SetActive(false);
                M113RumbleType1_Pool.Add(obj);
            }
        }

        //Only if object to be pooled is assigned
        if (M113RumbleType2_Object != null)
        {
            //If pool does not exist
            if (M113RumbleType2_Pool == null)
            {
                //Create new pool
                M113RumbleType2_Pool = new List<GameObject>();
            }

            //Creating objects in the pool based on size
            for (int i = 0; i < PoolSize; i++)
            {
                GameObject obj = (GameObject)Instantiate(M113RumbleType2_Object);
                obj.transform.SetParent(Canvas.transform);
                obj.SetActive(false);
                M113RumbleType2_Pool.Add(obj);
            }
        }

        //Only if object to be pooled is assigned
        if (M113RumbleType3_Object != null)
        {
            //If pool does not exist
            if (M113RumbleType3_Pool == null)
            {
                //Create new pool
                M113RumbleType3_Pool = new List<GameObject>();
            }

            //Creating objects in the pool based on size
            for (int i = 0; i < PoolSize; i++)
            {
                GameObject obj = (GameObject)Instantiate(M113RumbleType3_Object);
                obj.transform.SetParent(Canvas.transform);
                obj.SetActive(false);
                M113RumbleType3_Pool.Add(obj);
            }
        }

        //Only if object to be pooled is assigned
        if (M113RumbleType4_Object != null)
        {
            //If pool does not exist
            if (M113RumbleType4_Pool == null)
            {
                //Create new pool
                M113RumbleType4_Pool = new List<GameObject>();
            }

            //Creating objects in the pool based on size
            for (int i = 0; i < PoolSize; i++)
            {
                GameObject obj = (GameObject)Instantiate(M113RumbleType4_Object);
                obj.transform.SetParent(Canvas.transform);
                obj.SetActive(false);
                M113RumbleType4_Pool.Add(obj);
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
                obj.transform.SetParent(Canvas.transform);
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
                obj.transform.SetParent(Canvas.transform);
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
                obj.transform.SetParent(Canvas.transform);
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

    private GameObject SpawnAMX10(Vector3 position, Quaternion rotation)
    {
        //Check if pool exists
        if (EnemyAMX10_Pool != null)
        {
            //Getting the first non active game object in this pool
            for (int i = 0; i < EnemyAMX10_Pool.Count; i++)
            {
                //Incase this game object is null, we create one and return it
                if (EnemyAMX10_Pool[i] == null)
                {
                    GameObject obj = (GameObject)Instantiate(EnemyAMX10_Object);

                    obj.transform.position = position;
                    obj.transform.rotation = rotation;
                    obj.SetActive(true);
                    EnemyAMX10_Pool[i] = obj;
                    return EnemyAMX10_Pool[i];
                }
                //Reuse when game object is not active
                if (!EnemyAMX10_Pool[i].activeInHierarchy)
                {
                    EnemyAMX10_Pool[i].transform.position = position;
                    EnemyAMX10_Pool[i].transform.rotation = rotation;
                    EnemyAMX10_Pool[i].SetActive(true);
                    return EnemyAMX10_Pool[i];
                }
            }

            //Increase the size of the list based on the grow rate
            for (int i = 0; i < GrowRate; i++)
            {
                GameObject obj = (GameObject)Instantiate(EnemyAMX10_Object);
                obj.transform.SetParent(Canvas.transform);
                obj.SetActive(false);
                EnemyAMX10_Pool.Add(obj);

                //When we have finished adding the new elements
                if (i == (GrowRate - 1))
                {
                    EnemyAMX10_Pool[EnemyAMX10_Pool.Count - 1].SetActive(true);
                    return EnemyAMX10_Pool[EnemyAMX10_Pool.Count - 1];
                }
            }
        }

        //If it reaches here, grow rate is 0 and
        //all elements in the list is already in use
        // OR
        //No game object is assigned thus pool is not created

        return null;
    }

    private GameObject SpawnV200RumbleType1(Vector3 position, Quaternion rotation)
    {
        //Check if pool exists
        if (V200RumbleType1_Pool != null)
        {
            //Getting the first non active game object in this pool
            for (int i = 0; i < V200RumbleType1_Pool.Count; i++)
            {
                //Incase this game object is null, we create one and return it
                if (V200RumbleType1_Pool[i] == null)
                {
                    GameObject obj = (GameObject)Instantiate(V200RumbleType1_Object);

                    obj.transform.position = position;
                    obj.transform.rotation = rotation;
                    obj.SetActive(true);
                    V200RumbleType1_Pool[i] = obj;
                    return V200RumbleType1_Pool[i];
                }
                //Reuse when game object is not active
                if (!V200RumbleType1_Pool[i].activeInHierarchy)
                {
                    V200RumbleType1_Pool[i].transform.position = position;
                    V200RumbleType1_Pool[i].transform.rotation = rotation;
                    V200RumbleType1_Pool[i].SetActive(true);
                    return V200RumbleType1_Pool[i];
                }
            }

            //Increase the size of the list based on the grow rate
            for (int i = 0; i < GrowRate; i++)
            {
                GameObject obj = (GameObject)Instantiate(V200RumbleType1_Object);
                obj.SetActive(false);
                V200RumbleType1_Pool.Add(obj);

                //When we have finished adding the new elements
                if (i == (GrowRate - 1))
                {
                    V200RumbleType1_Pool[V200RumbleType1_Pool.Count - 1].SetActive(true);
                    return V200RumbleType1_Pool[V200RumbleType1_Pool.Count - 1];
                }
            }
        }

        //If it reaches here, grow rate is 0 and
        //all elements in the list is already in use
        // OR
        //No game object is assigned thus pool is not created

        return null;
    }

    private GameObject SpawnV200RumbleType2(Vector3 position, Quaternion rotation)
    {
        //Check if pool exists
        if (V200RumbleType2_Pool != null)
        {
            //Getting the first non active game object in this pool
            for (int i = 0; i < V200RumbleType2_Pool.Count; i++)
            {
                //Incase this game object is null, we create one and return it
                if (V200RumbleType2_Pool[i] == null)
                {
                    GameObject obj = (GameObject)Instantiate(V200RumbleType2_Object);

                    obj.transform.position = position;
                    obj.transform.rotation = rotation;
                    obj.SetActive(true);
                    V200RumbleType2_Pool[i] = obj;
                    return V200RumbleType2_Pool[i];
                }
                //Reuse when game object is not active
                if (!V200RumbleType2_Pool[i].activeInHierarchy)
                {
                    V200RumbleType2_Pool[i].transform.position = position;
                    V200RumbleType2_Pool[i].transform.rotation = rotation;
                    V200RumbleType2_Pool[i].SetActive(true);
                    return V200RumbleType2_Pool[i];
                }
            }

            //Increase the size of the list based on the grow rate
            for (int i = 0; i < GrowRate; i++)
            {
                GameObject obj = (GameObject)Instantiate(V200RumbleType2_Object);
                obj.SetActive(false);
                V200RumbleType2_Pool.Add(obj);

                //When we have finished adding the new elements
                if (i == (GrowRate - 1))
                {
                    V200RumbleType2_Pool[V200RumbleType2_Pool.Count - 1].SetActive(true);
                    return V200RumbleType2_Pool[V200RumbleType2_Pool.Count - 1];
                }
            }
        }

        //If it reaches here, grow rate is 0 and
        //all elements in the list is already in use
        // OR
        //No game object is assigned thus pool is not created

        return null;
    }

    private GameObject SpawnV200RumbleType3(Vector3 position, Quaternion rotation)
    {
        //Check if pool exists
        if (V200RumbleType3_Pool != null)
        {
            //Getting the first non active game object in this pool
            for (int i = 0; i < V200RumbleType3_Pool.Count; i++)
            {
                //Incase this game object is null, we create one and return it
                if (V200RumbleType3_Pool[i] == null)
                {
                    GameObject obj = (GameObject)Instantiate(V200RumbleType3_Object);

                    obj.transform.position = position;
                    obj.transform.rotation = rotation;
                    obj.SetActive(true);
                    V200RumbleType3_Pool[i] = obj;
                    return V200RumbleType3_Pool[i];
                }
                //Reuse when game object is not active
                if (!V200RumbleType3_Pool[i].activeInHierarchy)
                {
                    V200RumbleType3_Pool[i].transform.position = position;
                    V200RumbleType3_Pool[i].transform.rotation = rotation;
                    V200RumbleType3_Pool[i].SetActive(true);
                    return V200RumbleType3_Pool[i];
                }
            }

            //Increase the size of the list based on the grow rate
            for (int i = 0; i < GrowRate; i++)
            {
                GameObject obj = (GameObject)Instantiate(V200RumbleType3_Object);
                obj.SetActive(false);
                V200RumbleType3_Pool.Add(obj);

                //When we have finished adding the new elements
                if (i == (GrowRate - 1))
                {
                    V200RumbleType3_Pool[V200RumbleType3_Pool.Count - 1].SetActive(true);
                    return V200RumbleType3_Pool[V200RumbleType3_Pool.Count - 1];
                }
            }
        }

        //If it reaches here, grow rate is 0 and
        //all elements in the list is already in use
        // OR
        //No game object is assigned thus pool is not created

        return null;
    }

    private GameObject SpawnV200RumbleType4(Vector3 position, Quaternion rotation)
    {
        //Check if pool exists
        if (V200RumbleType4_Pool != null)
        {
            //Getting the first non active game object in this pool
            for (int i = 0; i < V200RumbleType4_Pool.Count; i++)
            {
                //Incase this game object is null, we create one and return it
                if (V200RumbleType4_Pool[i] == null)
                {
                    GameObject obj = (GameObject)Instantiate(V200RumbleType4_Object);

                    obj.transform.position = position;
                    obj.transform.rotation = rotation;
                    obj.SetActive(true);
                    V200RumbleType4_Pool[i] = obj;
                    return V200RumbleType4_Pool[i];
                }
                //Reuse when game object is not active
                if (!V200RumbleType4_Pool[i].activeInHierarchy)
                {
                    V200RumbleType4_Pool[i].transform.position = position;
                    V200RumbleType4_Pool[i].transform.rotation = rotation;
                    V200RumbleType4_Pool[i].SetActive(true);
                    return V200RumbleType4_Pool[i];
                }
            }

            //Increase the size of the list based on the grow rate
            for (int i = 0; i < GrowRate; i++)
            {
                GameObject obj = (GameObject)Instantiate(V200RumbleType4_Object);
                obj.SetActive(false);
                V200RumbleType4_Pool.Add(obj);

                //When we have finished adding the new elements
                if (i == (GrowRate - 1))
                {
                    V200RumbleType4_Pool[V200RumbleType4_Pool.Count - 1].SetActive(true);
                    return V200RumbleType4_Pool[V200RumbleType4_Pool.Count - 1];
                }
            }
        }

        //If it reaches here, grow rate is 0 and
        //all elements in the list is already in use
        // OR
        //No game object is assigned thus pool is not created

        return null;
    }

    private GameObject SpawnM113RumbleType1(Vector3 position, Quaternion rotation)
    {
        //Check if pool exists
        if (M113RumbleType1_Pool != null)
        {
            //Getting the first non active game object in this pool
            for (int i = 0; i < M113RumbleType1_Pool.Count; i++)
            {
                //Incase this game object is null, we create one and return it
                if (M113RumbleType1_Pool[i] == null)
                {
                    GameObject obj = (GameObject)Instantiate(M113RumbleType1_Object);

                    obj.transform.position = position;
                    obj.transform.rotation = rotation;
                    obj.SetActive(true);
                    M113RumbleType1_Pool[i] = obj;
                    return M113RumbleType1_Pool[i];
                }
                //Reuse when game object is not active
                if (!M113RumbleType1_Pool[i].activeInHierarchy)
                {
                    M113RumbleType1_Pool[i].transform.position = position;
                    M113RumbleType1_Pool[i].transform.rotation = rotation;
                    M113RumbleType1_Pool[i].SetActive(true);
                    return M113RumbleType1_Pool[i];
                }
            }

            //Increase the size of the list based on the grow rate
            for (int i = 0; i < GrowRate; i++)
            {
                GameObject obj = (GameObject)Instantiate(M113RumbleType1_Object);
                obj.SetActive(false);
                M113RumbleType1_Pool.Add(obj);

                //When we have finished adding the new elements
                if (i == (GrowRate - 1))
                {
                    M113RumbleType1_Pool[M113RumbleType1_Pool.Count - 1].SetActive(true);
                    return M113RumbleType1_Pool[M113RumbleType1_Pool.Count - 1];
                }
            }
        }

        //If it reaches here, grow rate is 0 and
        //all elements in the list is already in use
        // OR
        //No game object is assigned thus pool is not created

        return null;
    }

    private GameObject SpawnM113RumbleType2(Vector3 position, Quaternion rotation)
    {
        //Check if pool exists
        if (M113RumbleType2_Pool != null)
        {
            //Getting the first non active game object in this pool
            for (int i = 0; i < M113RumbleType2_Pool.Count; i++)
            {
                //Incase this game object is null, we create one and return it
                if (M113RumbleType2_Pool[i] == null)
                {
                    GameObject obj = (GameObject)Instantiate(M113RumbleType2_Object);

                    obj.transform.position = position;
                    obj.transform.rotation = rotation;
                    obj.SetActive(true);
                    M113RumbleType2_Pool[i] = obj;
                    return M113RumbleType2_Pool[i];
                }
                //Reuse when game object is not active
                if (!M113RumbleType2_Pool[i].activeInHierarchy)
                {
                    M113RumbleType2_Pool[i].transform.position = position;
                    M113RumbleType2_Pool[i].transform.rotation = rotation;
                    M113RumbleType2_Pool[i].SetActive(true);
                    return M113RumbleType2_Pool[i];
                }
            }

            //Increase the size of the list based on the grow rate
            for (int i = 0; i < GrowRate; i++)
            {
                GameObject obj = (GameObject)Instantiate(M113RumbleType2_Object);
                obj.SetActive(false);
                M113RumbleType2_Pool.Add(obj);

                //When we have finished adding the new elements
                if (i == (GrowRate - 1))
                {
                    M113RumbleType2_Pool[M113RumbleType2_Pool.Count - 1].SetActive(true);
                    return M113RumbleType2_Pool[M113RumbleType2_Pool.Count - 1];
                }
            }
        }

        //If it reaches here, grow rate is 0 and
        //all elements in the list is already in use
        // OR
        //No game object is assigned thus pool is not created

        return null;
    }

    private GameObject SpawnM113RumbleType3(Vector3 position, Quaternion rotation)
    {
        //Check if pool exists
        if (M113RumbleType3_Pool != null)
        {
            //Getting the first non active game object in this pool
            for (int i = 0; i < M113RumbleType3_Pool.Count; i++)
            {
                //Incase this game object is null, we create one and return it
                if (M113RumbleType3_Pool[i] == null)
                {
                    GameObject obj = (GameObject)Instantiate(M113RumbleType3_Object);

                    obj.transform.position = position;
                    obj.transform.rotation = rotation;
                    obj.SetActive(true);
                    M113RumbleType3_Pool[i] = obj;
                    return M113RumbleType3_Pool[i];
                }
                //Reuse when game object is not active
                if (!M113RumbleType3_Pool[i].activeInHierarchy)
                {
                    M113RumbleType3_Pool[i].transform.position = position;
                    M113RumbleType3_Pool[i].transform.rotation = rotation;
                    M113RumbleType3_Pool[i].SetActive(true);
                    return M113RumbleType3_Pool[i];
                }
            }

            //Increase the size of the list based on the grow rate
            for (int i = 0; i < GrowRate; i++)
            {
                GameObject obj = (GameObject)Instantiate(M113RumbleType3_Object);
                obj.SetActive(false);
                M113RumbleType3_Pool.Add(obj);

                //When we have finished adding the new elements
                if (i == (GrowRate - 1))
                {
                    M113RumbleType3_Pool[M113RumbleType3_Pool.Count - 1].SetActive(true);
                    return M113RumbleType3_Pool[M113RumbleType3_Pool.Count - 1];
                }
            }
        }

        //If it reaches here, grow rate is 0 and
        //all elements in the list is already in use
        // OR
        //No game object is assigned thus pool is not created

        return null;
    }

    private GameObject SpawnM113RumbleType4(Vector3 position, Quaternion rotation)
    {
        //Check if pool exists
        if (M113RumbleType4_Pool != null)
        {
            //Getting the first non active game object in this pool
            for (int i = 0; i < M113RumbleType4_Pool.Count; i++)
            {
                //Incase this game object is null, we create one and return it
                if (M113RumbleType4_Pool[i] == null)
                {
                    GameObject obj = (GameObject)Instantiate(M113RumbleType4_Object);

                    obj.transform.position = position;
                    obj.transform.rotation = rotation;
                    obj.SetActive(true);
                    M113RumbleType4_Pool[i] = obj;
                    return M113RumbleType4_Pool[i];
                }
                //Reuse when game object is not active
                if (!M113RumbleType4_Pool[i].activeInHierarchy)
                {
                    M113RumbleType4_Pool[i].transform.position = position;
                    M113RumbleType4_Pool[i].transform.rotation = rotation;
                    M113RumbleType4_Pool[i].SetActive(true);
                    return M113RumbleType4_Pool[i];
                }
            }

            //Increase the size of the list based on the grow rate
            for (int i = 0; i < GrowRate; i++)
            {
                GameObject obj = (GameObject)Instantiate(M113RumbleType4_Object);
                obj.SetActive(false);
                M113RumbleType4_Pool.Add(obj);

                //When we have finished adding the new elements
                if (i == (GrowRate - 1))
                {
                    M113RumbleType4_Pool[M113RumbleType4_Pool.Count - 1].SetActive(true);
                    return M113RumbleType4_Pool[M113RumbleType4_Pool.Count - 1];
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