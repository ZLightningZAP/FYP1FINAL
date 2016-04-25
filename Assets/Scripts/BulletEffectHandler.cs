using UnityEngine;
using System.Collections;

public class BulletEffectHandler : MonoBehaviour {

    private float gap = 0.1f;   //Gap for instantiating effects

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void EffectResponse(RaycastHit hit)
    {
        string type = hit.transform.tag;

        if (type == "SpeedTree")
        {

        }
        else
        {
            int rand = Random.Range(1, 3);

            if (rand == 1)
            {
                VFXController.current.SpawnVFX(hit.point + (hit.normal * gap), Quaternion.LookRotation(hit.normal), VFXController.VFX_TYPE.SPARKS_TYPE1);
                //Instantiate(OnHitEffect, hit.point + (hit.normal * gap), Quaternion.LookRotation(hit.normal));  //Creating On Hit Effect
            }
            else
            {
                VFXController.current.SpawnVFX(hit.point + (hit.normal * gap), Quaternion.LookRotation(hit.normal), VFXController.VFX_TYPE.SPARKS_TYPE2);
            }


        }
    }
}
