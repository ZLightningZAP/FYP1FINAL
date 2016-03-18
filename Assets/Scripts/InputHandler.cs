using UnityEngine;
using System.Collections;

public class InputHandler : MonoBehaviour
{
    public GameObject BulletHole;   //Bullet Hole Graphic
    public ParticleSystem OnHitEffect;  //Particle Effect On Bullet Hit
    public OverHeating overheat;

    public float MaxBulletSpreadRange; //Maximum Range of Bullet Spread
    public float FireRate;  //Rate of Fire
    public float SpreadIncreaseRate; //Rate of increasing bullet spread

    private float gap = 0.1f;   //Gap for instantiating effects

    private float defaultBulletSpread = 0.1f;   //Default Range of Bullet Spread
    private float currentBulletSpread;  //Current Range of Bullet Spread
    private float fireTimer = 0.0f; //Use to keep track of time before last fire

    Camera camera;  //Main Camera

    // Use this for initialization
    void Start()
    {
        camera = Camera.main;

        currentBulletSpread = defaultBulletSpread;
    }

    // Update is called once per frame
    void Update()
    {
        fireTimer += Time.deltaTime;

        //If Left Click
        if (Input.GetMouseButton(0))
        {
            if (fireTimer >= FireRate && overheat.overHeated == false)
            {
                Fire(); //Do Fire
            }
        }
        else
        {
            //Decrease the heating guage every 0.5 second
            overheat.CoolDownHeating();

            //Decreasing bullet spread over time
            currentBulletSpread -= Time.deltaTime * SpreadIncreaseRate;
            if (currentBulletSpread <= defaultBulletSpread)
            {
                currentBulletSpread = defaultBulletSpread;
            }
        }
    }

    void Fire()
    {
        //Update the overheat bar
        overheat.OverheatbarUpdate();

        //Creating Bullet Spread
        Vector3 FinalPosition = Input.mousePosition;
        FinalPosition.x += Random.Range(-currentBulletSpread, currentBulletSpread);
        FinalPosition.y += Random.Range(-currentBulletSpread, currentBulletSpread);

        //Creating Ray based on final calculated position
        Ray ray = camera.ScreenPointToRay(FinalPosition);

        RaycastHit hit;

        //Checking if Ray has hit
        if (Physics.Raycast(ray, out hit))
        {
            Instantiate(OnHitEffect, hit.point + (hit.normal * gap), Quaternion.LookRotation(hit.normal));  //Creating On Hit Effect
            Instantiate(BulletHole, hit.point + (hit.normal * gap), Quaternion.LookRotation(hit.normal));   //Creating Bullet Hole 
            hit.transform.SendMessage("Injure", 10, SendMessageOptions.DontRequireReceiver);
        }

        fireTimer = 0.0f;   //Resetting the Timer
        currentBulletSpread += Time.deltaTime * SpreadIncreaseRate;  //Increasing spread of bullet
        if (currentBulletSpread > MaxBulletSpreadRange)
        {
            currentBulletSpread = MaxBulletSpreadRange;
        }
    }
}
