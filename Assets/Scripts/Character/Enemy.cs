﻿using UnityEngine;

public class Enemy : Character
{
    public GameObject Waypoint;
    public float MovementSpeed = 10f;
    public float Timetoshoot = 1f;
    public float Damage = 10;

    public GameObject aiming;
    private Animator anim;

    //Smoke Effect
    private GameObject SmokeEffect; //Used to keep track

    private float Gap;
    private ShootingBarrel shootingBarrel;
    private int randomInt;
    private bool assigned = false;
    private bool visible;
    public bool trulyVisible;
    private bool shootingyet = false;
    private float timer;

    private bool moving;
    private LookingPoint lk1;
    private LookingPoint2 lk2;

    // Use this for initialization
    protected override void Start()
    {
        // Base Start
        base.Start();
        Gap = 0.01f;
        shootingBarrel = GetComponentInChildren<ShootingBarrel>();
        trulyVisible = false;

        anim = aiming.GetComponent<Animator>();
        anim.enabled = false;
        aiming.SetActive(false);
        moving = false;

        //Get the looking point from the camera
        lk1 = FindObjectOfType<LookingPoint>();
        lk2 = FindObjectOfType<LookingPoint2>();

        //gameObject.SetActive(false);
    }

    // Update is called once per frame
    protected override void Update()
    {
        // Base Update
        base.Update();

        Dead();
        if (Waypoint != null)
        {
            Move();
        }
        Looking();
        if (shootingyet == true)
        {
            Shooting();
        }
    }

    private void Dead()
    {
        //When Health drops below 50, start our smoke effect here
        //If Smoke effect is null, shows that this is the first time it has started
        if (health <= 50 && SmokeEffect == null)
        {
            SmokeEffect = VFXController.current.SpawnVFX(transform.position, Quaternion.identity, VFXController.VFX_TYPE.SMOKE_TYPE1);
        }
        //Else check if it is still active
        else if (health <= 50 && !SmokeEffect.activeInHierarchy)
        {
            SmokeEffect = VFXController.current.SpawnVFX(transform.position, Quaternion.identity, VFXController.VFX_TYPE.SMOKE_TYPE1);
        }

        //If enemy has 0 health, active will be set to false
        if (health == 0)
        {
            //Creating Explosion Effect
            VFXController.current.SpawnVFX(transform.position, Quaternion.identity, VFXController.VFX_TYPE.DEBRIS);
            VFXController.current.SpawnVFX(transform.position, Quaternion.identity, VFXController.VFX_TYPE.EXPLOSION_TYPE1);
            VFXController.current.SpawnVFX(transform.position, Quaternion.identity, VFXController.VFX_TYPE.EXPLOSIONSPARK_TYPE1);

            //Stop smoke effect if it is active
            if (SmokeEffect.activeInHierarchy)
            {
                SmokeEffect.SetActive(false);
            }

            ScoreManager.AddCurrentScore(ScoreManager.ScoreType.EnemyKill);

            EnemyManager.updatedCount -= 1;

            anim.enabled = false;
            aiming.SetActive(false);

            //Deactivate object
            gameObject.SetActive(false);
        }
    }

    private void Move()
    {
        if (Vector3.Distance(Waypoint.transform.position, transform.position) > Gap)
        {
            //Go towards the next position
            transform.position = Vector3.MoveTowards(transform.position, Waypoint.transform.position, MovementSpeed * Time.deltaTime);
            if (!moving)
            {
                moving = true;
            }
        }
        else
        {
            if (moving)
            {
                moving = false;
            }
            return;
        }
    }

    private void Looking()
    {
        //Assign a random number
        if (assigned == false)
        {
            randomInt = Random.Range(0, 3);
            assigned = true;
        }

        //Assign the random number for the enemy to look at the object
        if (randomInt == 0 && assigned == true)
        {
            // The shooting barrel will always rotate to look at the camera
            shootingBarrel.gameObject.transform.LookAt(Camera.main.transform.position);
            //print("Looking at camera!");
        }
        else if (randomInt == 1 && assigned == true)
        {
            // The shooting barrel will always rotate to look at Looking Point 1
            shootingBarrel.gameObject.transform.LookAt(lk1.transform.position);
            //print("Looking at Looking Point 1!");
        }
        else if (randomInt == 2 && assigned == true)
        {
            // The shooting barrel will always rotate to look at Looking Point 2
            shootingBarrel.gameObject.transform.LookAt(lk2.transform.position);
            //print("Looking at Looking Point 2!");
        }

        //Check if the object can be seen by the camera
        visible = GetComponentInChildren<Renderer>().isVisible;

        //Debug if the object can be seen
        if (visible == true)
        {
            //Send a ray from the camera to the object
            Ray ray = Camera.main.ViewportPointToRay(Camera.main.WorldToViewportPoint(gameObject.transform.position));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                //If the ray hit and object name is the same
                if (hit.collider.gameObject.name == gameObject.name)
                {
                    //Debug.Log(gameObject.name + " CAN BE SEEN!");
                    //It is not blocked by any object and can be seen
                    trulyVisible = true;
                }
            }
            else
            {
                trulyVisible = false;
            }
        }
        else
        {
            trulyVisible = false;
        }
    }

    public void Shooting()
    {
        shootingyet = true;
        anim.enabled = true;
        aiming.SetActive(true);

        timer += Time.deltaTime;
        if (timer >= Timetoshoot)
        {
            shootingBarrel.gameObject.transform.LookAt(Camera.main.transform.position);
            //FindObjectOfType<Player>().Injure(Damage);
            print("Damaged by " + gameObject.name);
            EnemyManager.shoot = false;
            shootingyet = false;
            timer = 0;
            aiming.SetActive(false);
        }
    }

    public bool GetMovingState()
    {
        return moving;
    }
}