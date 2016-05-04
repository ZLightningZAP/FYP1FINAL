using UnityEngine;

public class BulletEffectHandler : MonoBehaviour
{
    private float gap = 0.1f;   //Gap for instantiating effects

    // Use this for initialization
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public void EffectResponse(RaycastHit hit)
    {
        string type = hit.transform.tag;

        if (type == "SpeedTree")
        {
        }
        else if (type == "Road")
        {
            VFXController.current.SpawnVFX(hit.point + (hit.normal * gap), Quaternion.LookRotation(hit.normal), VFXController.VFX_TYPE.DUSTCLOUD);
        }
        else
        {
            int rand = Random.Range(1, 3);

            if (rand == 1)
            {
                VFXController.current.SpawnVFX(hit.point + (hit.normal * gap), Quaternion.LookRotation(hit.normal), VFXController.VFX_TYPE.SPARKS_TYPE1);
            }
            else
            {
                VFXController.current.SpawnVFX(hit.point + (hit.normal * gap), Quaternion.LookRotation(hit.normal), VFXController.VFX_TYPE.SPARKS_TYPE2);
            }
        }
    }
}