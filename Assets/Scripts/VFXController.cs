using System.Collections.Generic;
using UnityEngine;

public class VFXController : MonoBehaviour
{
    public static VFXController current;

    public int PoolSize;    //Starting pool size
    public int GrowRate;    //Rate at which pool will grow when it is full

    public GameObject SparkType1_Object; //Object that will be pooled
    public GameObject SparkType2_Object;  //Second Object that will be pooled

    public GameObject SmokeType1_Object;  //Smoke Effect that will be pooled

    private List<GameObject> SparkType1_Pool;   //List containing all the type 1 Spark Effects in the scene
    private List<GameObject> SparkType2_Pool;   //List containing all the type 2 Spark Effects in the scene

    private List<GameObject> SmokeType1_Pool;   //List containing all the type 1 Smoke Effects in the scene

    public enum VFX_TYPE
    {
        SPARKS_TYPE1,
        SPARKS_TYPE2,
        SMOKE_TYPE1,
        MAX_TYPE,
    };

    private void Awake()
    {
        current = this;
    }

    // Use this for initialization
    private void Start()
    {
        InitializeSpark_Type1();

        InitializeSpark_Type2();

        InitializeSmoke_Type1();
    }

    public GameObject SpawnVFX(Vector3 position, Quaternion rotation, VFX_TYPE type)
    {
        switch (type)
        {
            case VFX_TYPE.SPARKS_TYPE1:
                return SpawnSpark_Type1(position, rotation);

            case VFX_TYPE.SPARKS_TYPE2:
                return SpawnSpark_Type2(position, rotation);

            case VFX_TYPE.SMOKE_TYPE1:
                return SpawnSmoke_Type1(position, rotation);

            default:
                return null;
        }
    }

    // Update is called once per frame
    private void Update()
    {
    }

    /*************************************************
       Initialize Functions
     *************************************************/

    private void InitializeSpark_Type1()
    {
        //Only if object to be pooled is assigned
        if (SparkType1_Object != null)
        {
            //If does not exist
            if (SparkType1_Pool == null)
            {
                //Create new pool
                SparkType1_Pool = new List<GameObject>();
            }

            //Creating objects in the pool based on size
            for (int i = 0; i < PoolSize; i++)
            {
                GameObject obj = (GameObject)Instantiate(SparkType1_Object);
                obj.SetActive(false);
                SparkType1_Pool.Add(obj);
            }
        }
    }

    private void InitializeSpark_Type2()
    {
        //Only if object to be pooled is assigned
        if (SparkType2_Object != null)
        {
            //If does not exist
            if (SparkType2_Pool == null)
            {
                //Create new pool
                SparkType2_Pool = new List<GameObject>();
            }

            //Creating objects in the pool based on size
            for (int i = 0; i < PoolSize; i++)
            {
                GameObject obj = (GameObject)Instantiate(SparkType2_Object);
                obj.SetActive(false);
                SparkType2_Pool.Add(obj);
            }
        }
    }

    private void InitializeSmoke_Type1()
    {
        //Only if object to be pooled is assigned
        if (SmokeType1_Object != null)
        {
            //If does not exist
            if (SmokeType1_Pool == null)
            {
                //Create new pool
                SmokeType1_Pool = new List<GameObject>();
            }

            //Creating objects in the pool based on size
            for (int i = 0; i < PoolSize; i++)
            {
                GameObject obj = (GameObject)Instantiate(SmokeType1_Object);
                obj.SetActive(false);
                SmokeType1_Pool.Add(obj);
            }
        }
    }

    /*************************************************
        Spawning Functions
   *************************************************/

    private GameObject SpawnSpark_Type1(Vector3 position, Quaternion rotation)
    {
        //Getting the first non active game object in this pool
        for (int i = 0; i < SparkType1_Pool.Count; i++)
        {
            //Incase this game object is null, we create one and return it
            if (SparkType1_Pool[i] == null)
            {
                GameObject obj = (GameObject)Instantiate(SparkType1_Object);

                obj.transform.position = position;
                obj.transform.rotation = rotation;
                obj.SetActive(true);
                SparkType1_Pool[i] = obj;
                return SparkType1_Pool[i];
            }
            //Reuse when game object is not active
            if (!SparkType1_Pool[i].activeInHierarchy)
            {
                SparkType1_Pool[i].transform.position = position;
                SparkType1_Pool[i].transform.rotation = rotation;
                SparkType1_Pool[i].SetActive(true);
                return SparkType1_Pool[i];
            }
        }

        //Increase the size of the list based on the grow rate
        for (int i = 0; i < GrowRate; i++)
        {
            GameObject obj = (GameObject)Instantiate(SparkType1_Object);
            obj.SetActive(false);
            SparkType1_Pool.Add(obj);

            //When we have finished adding the new elements
            if (i == (GrowRate - 1))
            {
                SparkType1_Pool[SparkType1_Pool.Count - 1].SetActive(true);
                return SparkType1_Pool[SparkType1_Pool.Count - 1];
            }
        }

        //If it reaches here, grow rate is 0 and
        //all elements in the list is already in use
        return null;
    }

    private GameObject SpawnSpark_Type2(Vector3 position, Quaternion rotation)
    {
        //Getting the first non active game object in this pool
        for (int i = 0; i < SparkType2_Pool.Count; i++)
        {
            //Incase this game object is null, we create one and return it
            if (SparkType2_Pool[i] == null)
            {
                GameObject obj = (GameObject)Instantiate(SparkType2_Object);

                obj.transform.position = position;
                obj.transform.rotation = rotation;
                obj.SetActive(true);
                SparkType2_Pool[i] = obj;
                return SparkType2_Pool[i];
            }
            //Reuse when game object is not active
            if (!SparkType2_Pool[i].activeInHierarchy)
            {
                SparkType2_Pool[i].transform.position = position;
                SparkType2_Pool[i].transform.rotation = rotation;
                SparkType2_Pool[i].SetActive(true);
                return SparkType2_Pool[i];
            }
        }

        //Increase the size of the list based on the grow rate
        for (int i = 0; i < GrowRate; i++)
        {
            GameObject obj = (GameObject)Instantiate(SparkType2_Object);
            obj.SetActive(false);
            SparkType2_Pool.Add(obj);

            //When we have finished adding the new elements
            if (i == (GrowRate - 1))
            {
                SparkType2_Pool[SparkType1_Pool.Count - 1].SetActive(true);
                return SparkType2_Pool[SparkType1_Pool.Count - 1];
            }
        }

        //If it reaches here, grow rate is 0 and
        //all elements in the list is already in use
        return null;
    }

    private GameObject SpawnSmoke_Type1(Vector3 position, Quaternion rotation)
    {
        //Getting the first non active game object in this pool
        for (int i = 0; i < SmokeType1_Pool.Count; i++)
        {
            //Incase this game object is null, we create one and return it
            if (SmokeType1_Pool[i] == null)
            {
                GameObject obj = (GameObject)Instantiate(SmokeType1_Object);

                obj.transform.position = position;
                obj.transform.rotation = rotation;
                obj.SetActive(true);
                SmokeType1_Pool[i] = obj;
                return SmokeType1_Pool[i];
            }
            //Reuse when game object is not active
            if (!SmokeType1_Pool[i].activeInHierarchy)
            {
                SmokeType1_Pool[i].transform.position = position;
                SmokeType1_Pool[i].transform.rotation = rotation;
                SmokeType1_Pool[i].SetActive(true);
                return SmokeType1_Pool[i];
            }
        }

        //Increase the size of the list based on the grow rate
        for (int i = 0; i < GrowRate; i++)
        {
            GameObject obj = (GameObject)Instantiate(SmokeType1_Object);
            obj.SetActive(false);
            SmokeType1_Pool.Add(obj);

            //When we have finished adding the new elements
            if (i == (GrowRate - 1))
            {
                SmokeType1_Pool[SmokeType1_Pool.Count - 1].SetActive(true);
                return SmokeType1_Pool[SmokeType1_Pool.Count - 1];
            }
        }

        //If it reaches here, grow rate is 0 and
        //all elements in the list is already in use
        return null;
    }
}