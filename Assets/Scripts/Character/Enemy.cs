using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : Character
{
    //Healthbar Image
    public Image healthBar;

    public GameObject Waypoint;
    public float MovementSpeed = 10f;
    public GameObject Cube1;
    public GameObject Cube2;

    //Fill amount for the health bar
    private float HealthFillAmount;

    //Smoke Effect
    private GameObject SmokeEffect;

    private float Gap;
    private ShootingBarrel shootingBarrel;
    private Camera camera;
    private int randomInt;
    private bool assigned = false;

    // Use this for initialization
    protected override void Start()
    {
        // Base Start
        base.Start();
        Gap = 0.01f;
        shootingBarrel = GetComponentInChildren<ShootingBarrel>();
        camera = Camera.main;
        //gameObject.SetActive(false);
    }

    // Update is called once per frame
    protected override void Update()
    {
        // Base Update
        base.Update();

        //HealthBar
        //HealthBarUpdate(Health);

        Dead();
        Move();
        Shooting();
    }

    public void HealthBarUpdate(float health)
    {
        // Calculate the fill amount of the health bar
        HealthFillAmount = health / MaxHealth;
        healthBar.fillAmount = HealthFillAmount;

        // If the health amount drop below 30%, the color of the healthbar will change to red
        if (healthBar.fillAmount <= 0.3)
        {
            healthBar.color = Color.red;
        }

        // If the health amount drop below 70%, the color of the healthbar will change to yellow
        else if (healthBar.fillAmount <= 0.7)
        {
            healthBar.color = Color.yellow;
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

            //Deactivate object
            gameObject.SetActive(false);
        }
    }

    private void Move()
    {
        if (Waypoint != null)
        {
            if (Vector3.Distance(Waypoint.transform.position, transform.position) > Gap)
            {
                //Go towards the next position
                transform.position = Vector3.MoveTowards(transform.position, Waypoint.transform.position, MovementSpeed * Time.deltaTime);
            }
        }
        else
        {
            return;
        }
    }

    private void Shooting()
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
            shootingBarrel.gameObject.transform.LookAt(Cube1.transform.position);
            //print("Looking at Looking Point 1!");
        }
        else if (randomInt == 2 && assigned == true)
        {
            // The shooting barrel will always rotate to look at Looking Point 2
            shootingBarrel.gameObject.transform.LookAt(Cube1.transform.position);
            //print("Looking at Looking Point 2!");
        }

        //Check if the object can be seen by the camera
        bool visible = GetComponentInChildren<Renderer>().isVisible;

        //Debug if the object can be seen
        if (visible == true)
        {
            //It can be seen by the camera
            print(gameObject.transform.name + " Can be seen");

            Ray ray = Camera.main.ViewportPointToRay(Camera.main.WorldToViewportPoint(gameObject.transform.position));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.collider.gameObject.name);
            }
        }
        else
        {
            //Dont check anything
            print(gameObject.transform.name + " Cannot be seen");
        }
    }
}