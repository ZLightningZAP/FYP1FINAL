using UnityEngine;

public class Enemy : Character
{
    public GameObject Waypoint;
    public float MovementSpeed = 10f;
    public float Timetoshoot = 1f;
    public float Damage = 10;
    public float RecoilTime = 0.1f;
    public float RecoilAngle = 50;
    public float RecoilValue = 5;
    public float Thrust = 100f;
    public bool Obsolete = false;

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
    private bool recoil = false;
    private float timer2;

    private bool moving;
    private LookingPoint lk1;
    private LookingPoint2 lk2;
    private Rigidbody rb;

    private bool triggeredmove = false;
    public bool Triggeredmove { get { return triggeredmove; } set { triggeredmove = value; } }

    public bool Wave = false;
    private float randomnumber;
    private bool chosen = false;
    private bool shootyet = false;

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

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    protected override void Update()
    {
        // Base Update
        base.Update();

        if (triggeredmove == true && Waypoint != null)
        {
            Move();
        }

        if (Obsolete == false)
        {
            Dead();

            if (recoil == false && Wave == false)
            {
                Looking();
            }

            if (shootingyet == true && Wave == false)
            {
                Shooting();
            }

            if (recoil == true)
            {
                Recoil();
            }

            if (Wave == true && shootyet == false)
            {
                WaveShooting();
            }
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

            //Display rumble
            DisplayRumble();

            //Add score to the manager
            ScoreManager.AddCurrentScore(ScoreManager.ScoreType.EnemyKill);

            EnemyManager.updatedCount -= 1;

            //Disable the animations
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

        //Shootingbarrel will look at the camera
        shootingBarrel.gameObject.transform.LookAt(Camera.main.transform.position);

        timer += Time.deltaTime;
        if (timer >= Timetoshoot)
        {
            FindObjectOfType<Player>().Injure(Damage);
            print("Damaged by " + gameObject.name);
            //Play the sound effect for the enemy shooting at the player
            SoundManager.PlaySoundEffect(SoundManager.SoundEffect.Enemy_Fire);
            EnemyManager.shoot = false;
            shootingyet = false;
            timer = 0;
            aiming.SetActive(false);
            //Set the recoil to true to run the recoil function
            recoil = true;
        }
    }

    public void WaveShooting()
    {
        if (chosen == false)
        {
            randomnumber = Random.Range(2, 5);
            chosen = true;
        }
        randomnumber -= Time.deltaTime;
        if (randomnumber <= 1.2 && chosen == true)
        {
            anim.enabled = true;
            aiming.SetActive(true);

            //Shootingbarrel will look at the camera
            shootingBarrel.gameObject.transform.LookAt(Camera.main.transform.position);

            timer += Time.deltaTime;
            if (timer >= Timetoshoot)
            {
                FindObjectOfType<Player>().Injure(Damage);
                print("Damaged by " + gameObject.name);
                //Play the sound effect for the enemy shooting at the player
                SoundManager.PlaySoundEffect(SoundManager.SoundEffect.Enemy_Fire);
                shootingyet = false;
                timer = 0;
                aiming.SetActive(false);
                //Set the recoil to true to run the recoil function
                recoil = true;
                shootyet = true;
            }
        }
    }

    public void Recoil()
    {
        timer2 += Time.deltaTime;
        if (timer2 <= RecoilTime * 0.5)
        {
            shootingBarrel.gameObject.transform.Rotate(Vector3.left, RecoilAngle * Time.deltaTime);
            rb.AddForce(-transform.forward * Thrust);

            //Vector3 Direction = (shootingBarrel.gameObject.transform.position - Camera.main.transform.position).normalized;
            //gameObject.transform.Translate(-Direction * (Time.deltaTime * RecoilValue));
        }
        if (timer2 >= RecoilTime * 0.5 && timer2 <= RecoilTime)
        {
            shootingBarrel.gameObject.transform.Rotate(Vector3.right, -RecoilAngle * Time.deltaTime);
            rb.AddForce(transform.forward * Thrust);

            //Vector3 Direction = (shootingBarrel.gameObject.transform.position - Camera.main.transform.position).normalized;
            //gameObject.transform.Translate(Direction * (Time.deltaTime * RecoilValue));
        }
        else
        {
            recoil = false;
            timer2 = 0;
        }
    }

    public bool GetMovingState()
    {
        return moving;
    }

    public void DisplayRumble()
    {
        int rand = Random.Range(1, 5);

        print(rand);

        if (gameObject.tag == "M113")
        {
            switch (rand)
            {
                case 1:
                    EnemyController.current.SpawnEnemy(transform.position, Quaternion.identity, EnemyController.ENEMY_TYPE.M113_RUMBLE_TYPE1);
                    break;

                case 2:
                    EnemyController.current.SpawnEnemy(transform.position, Quaternion.identity, EnemyController.ENEMY_TYPE.M113_RUMBLE_TYPE2);
                    break;

                case 3:
                    EnemyController.current.SpawnEnemy(transform.position, Quaternion.identity, EnemyController.ENEMY_TYPE.M113_RUMBLE_TYPE3);
                    break;

                case 4:
                    EnemyController.current.SpawnEnemy(transform.position, Quaternion.identity, EnemyController.ENEMY_TYPE.M113_RUMBLE_TYPE4);
                    break;

                default:
                    EnemyController.current.SpawnEnemy(transform.position, Quaternion.identity, EnemyController.ENEMY_TYPE.M113_RUMBLE_TYPE1);
                    break;
            }
        }
        else if (gameObject.tag == "V200")
        {
            switch (rand)
            {
                case 1:
                    EnemyController.current.SpawnEnemy(transform.position, Quaternion.identity, EnemyController.ENEMY_TYPE.V200_RUMBLE_TYPE1);
                    break;

                case 2:
                    EnemyController.current.SpawnEnemy(transform.position, Quaternion.identity, EnemyController.ENEMY_TYPE.V200_RUMBLE_TYPE2);
                    break;

                case 3:
                    EnemyController.current.SpawnEnemy(transform.position, Quaternion.identity, EnemyController.ENEMY_TYPE.V200_RUMBLE_TYPE3);
                    break;

                case 4:
                    EnemyController.current.SpawnEnemy(transform.position, Quaternion.identity, EnemyController.ENEMY_TYPE.V200_RUMBLE_TYPE4);
                    break;

                default:
                    EnemyController.current.SpawnEnemy(transform.position, Quaternion.identity, EnemyController.ENEMY_TYPE.V200_RUMBLE_TYPE1);
                    break;
            }
        }
    }

    public void Rotate()
    {
        Vector3 targetDir = Waypoint.transform.position - transform.position;
        float step = 9999f;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0F);
        transform.rotation = Quaternion.LookRotation(newDir);
    }
}