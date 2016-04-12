using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class VFXController : MonoBehaviour {

    public static VFXController current;

    public int PoolSize;    //Starting pool size
    public int GrowRate;    //Rate at which pool will grow when it is full

    public GameObject pooledObject; //Object that will be pooled

    public GameObject ObjectType2;  //Another type of game object

    List<GameObject> particlePool;   //List containing all the particle effects in the scene

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

        //If does not exist
        if (particlePool == null)
        {
            //Create new pool
            particlePool = new List<GameObject>();
        }

        for (int i = 0; i < PoolSize; i++)
        {
            GameObject obj = (GameObject)Instantiate(pooledObject);
            obj.SetActive(false);
            particlePool.Add(obj);
        }
	}

    public GameObject SpawnVFX(Vector3 position, Quaternion rotation, VFX_TYPE type)
    {
        //Getting the first non active game object in this pool
        for (int i = 0; i < particlePool.Count; i++)
        {
            //Incase this game object is null, we create one and return it
            if (particlePool[i] == null)
            {
                GameObject obj = (GameObject)Instantiate(pooledObject);

                obj.transform.position = position;
                obj.transform.rotation = rotation;
                obj.SetActive(true);
                particlePool[i] = obj;
                return particlePool[i];
            }
            //Reuse when game object is not active
            if (!particlePool[i].activeInHierarchy)
            {
                particlePool[i].transform.position = position;
                particlePool[i].transform.rotation = rotation;
                particlePool[i].SetActive(true);
                return particlePool[i];
            }
        }

        //Increase the size of the list based on the grow rate
        for (int i = 0; i < GrowRate; i++)
        {
            GameObject obj = (GameObject)Instantiate(pooledObject);
            obj.SetActive(false);
            particlePool.Add(obj);

            //When we have finished adding the new elements
            if(i == (GrowRate - 1))
            {
                particlePool[particlePool.Count - 1].SetActive(true);
                return particlePool[particlePool.Count - 1];
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
