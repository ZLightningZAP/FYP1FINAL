using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBoss : Character
{
    //Healthbar Image
    public Image healthBar;

    public float MovementSpeed = 10f;
    public float ChargeTime = 3f;
    public float Damage = 50;
    public float RechargeTime = 5f;

    public GameObject WaypointCanvas;
    private List<Waypoint> waypoints = new List<Waypoint>();
    private List<Waypoint> SortedWaypoint = new List<Waypoint>();

    //Fill amount for the health bar
    private float HealthFillAmount;

    private int index;
    private float Gap;
    private float timer;
    private float timer2;
    public GameObject aiming;
    public GameObject firing;
    private Animator anim;
    private GameObject SmokeEffect;
    private Rigidbody rb;
    private Weakpoint wp;

    private ShootingBarrel shootingBarrel;
    private bool Shootbeforechargetime = false;
    private float waitTimer;

    private Transform CurrentTransform;
    private bool shown = false;

    private int counter;
    public int Limit;
    private bool cancelled = false;

    // Use this for initialization
    protected override void Start()
    {
        base.Start();
        Gap = 0.01f;
        index = 0;

        anim = aiming.GetComponent<Animator>();
        anim.enabled = false;
        aiming.SetActive(false);
        shootingBarrel = GetComponentInChildren<ShootingBarrel>();
        rb = GetComponent<Rigidbody>();
        wp = GetComponent<Weakpoint>();

        if (WaypointCanvas != null)
        {
            foreach (var waypoint in FindObjectsOfType(typeof(Waypoint)) as Waypoint[])
            {
                waypoints.Add(waypoint);
            }

            SortedWaypoint = WaypointCanvas.GetComponentsInChildren<Waypoint>().ToList();
        }

        CurrentTransform = gameObject.transform;
        //Set the gameobject to active on start
        //gameObject.SetActive(false);

        wp.enabled = false;

        shown = false;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        if (gameObject.activeSelf == true)
        {
            // Update the healthbar
            HealthBarUpdate(Health);
            Dead();
            Shooting();
            if (waypoints.Count != 0)
            {
                Move();
            }
        }
    }

    public void HealthBarUpdate(float health)
    {
        // Calculate the fill amount of the health bar
        HealthFillAmount = health / MaxHealth;
        healthBar.fillAmount = HealthFillAmount;
    }

    private void Move()
    {
        if (Vector3.Distance(SortedWaypoint[index].gameObject.transform.position, CurrentTransform.position) > Gap)
        {
            //Go towards the next position
            CurrentTransform.position = Vector3.MoveTowards(CurrentTransform.position, SortedWaypoint[index].gameObject.transform.position, MovementSpeed * Time.deltaTime);
        }
        else
        {
            waitTimer += Time.deltaTime;

            if (waitTimer > SortedWaypoint[index].WaitTime)
            {
                //Only if its still within bounds of the waypoint
                if (SortedWaypoint.Count > index + 1)
                {
                    index++;
                    waitTimer = 0.0f;
                    print("Going to next point!");
                }
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
            ScoreManager.AddCurrentScore(ScoreManager.ScoreType.BossKill);
            //Disable the animations
            anim.enabled = false;
            aiming.SetActive(false);

            //Deactivate object
            gameObject.SetActive(false);

            if (shown == false)
            {
                if (ScoreManager.CurrentScore >= TextManager.Score[TextManager.Score.Count - 1])
                {
                    UIPanelManager.ShowUIPanel(UIPanelManager.UIPanel.NewHighscore);
                    shown = true;
                }
                else
                {
                    UIPanelManager.ShowUIPanel(UIPanelManager.UIPanel.GameOver);
                }
            }
        }
    }

    private void Shooting()
    {
        shootingBarrel.gameObject.transform.LookAt(Camera.main.transform.position);

        if (Shootbeforechargetime == false)
        {
            anim.enabled = true;
            aiming.SetActive(true);
            timer += Time.deltaTime;

            //Enable the weakpoint
            wp.enabled = true;
            print("Weakpoint Active");
            if (cancelled == true)
            {
                print("Attack Cancelled");
                anim.enabled = false;
                aiming.SetActive(false);
                wp.enabled = false;
                timer = 0;
                Shootbeforechargetime = true;
                return;
            }

            if (timer >= ChargeTime && cancelled == false)
            {
                //FindObjectOfType<Player>().Injure(Damage);
                Vector3 n = Camera.main.transform.position - firing.transform.position;
                VFXController.current.SpawnVFX(firing.transform.position, Quaternion.LookRotation(n), VFXController.VFX_TYPE.BULLETS_LARGE);
                VFXController.current.SpawnVFX(firing.transform.position, Quaternion.LookRotation(n), VFXController.VFX_TYPE.MUZZLEFLASH);
                timer = 0;
                aiming.SetActive(false);
                Shootbeforechargetime = true;
            }
        }
        else
        {
            print("Recharging");
            timer2 += Time.deltaTime;
            if (timer2 >= RechargeTime)
            {
                print("Recharged");
                Shootbeforechargetime = false;
                timer2 = 0;
            }
        }
    }

    private void Cancel(int i)
    {
        counter += i;
        if (counter >= Limit)
        {
            cancelled = true;
            counter = 0;
        }
    }
}