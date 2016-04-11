using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class VFXController : MonoBehaviour {

    public int PoolSize;    //Starting pool size

    static private List<ParticleSystem> particlePool;   //List containing all the particle effects in the scene

	// Use this for initialization
	void Start () {

        //If does not exist
        if (particlePool == null)
        {
            //Create new pool
            particlePool = new List<ParticleSystem>();
        }

        for (int i = 0; i < PoolSize; i++)
        {

        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
