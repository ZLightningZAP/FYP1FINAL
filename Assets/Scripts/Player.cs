using UnityEngine;
using System.Collections;

public class Player : Character
{

    public GameObject BulletHole;
    public ParticleSystem BulletSpark;
    private float FireRate;

    private float gap = 0.1f;

    Camera camera;

    // Use this for initialization
    protected override void Start()
    {
        // Base Start
        base.Start();
        camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    protected override void Update()
    {
        // Base Update
        base.Update();

        //If Left Click
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Instantiate(BulletSpark, hit.point, transform.rotation);

                Instantiate(BulletHole, hit.point + (hit.normal * gap), Quaternion.LookRotation(hit.normal));
            }
        }
    }
}
