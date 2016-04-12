using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class VFXController : MonoBehaviour {

    public static VFXController current;

    public int PoolSize;    //Starting pool size
    public int GrowRate;    //Rate at which pool will grow when it is full

    public GameObject SparkType1_Object; //Object that will be pooled

    public GameObject ObjectType2;  //Another type of game object

    List<GameObject> SparkType1_Pool;   //List containing all the particle effects in the scene

    public enum VFX_TYPE
    {
        SPARKS_TYPE1,
        SPARKS_TYPE2,
        MAX_TYPE,
    };

    void Awake()
    {
        current = this;
    }

	// Use this for initialization
	void Start () {

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

    public GameObject SpawnVFX(Vector3 position, Quaternion rotation, VFX_TYPE type)
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
            if(i == (GrowRate - 1))
            {
                SparkType1_Pool[SparkType1_Pool.Count - 1].SetActive(true);
                return SparkType1_Pool[SparkType1_Pool.Count - 1];
            }
        }

        //If it reaches here, grow rate is 0 and 
        //all elements in the list is already in use
        return null;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
