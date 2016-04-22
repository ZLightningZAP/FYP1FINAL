using System.Collections.Generic;
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

    public List<Waypoint> waypoints = new List<Waypoint>();

    //Fill amount for the health bar
    private float HealthFillAmount;

    private int index;
    private float Gap;
    private float timer;
    private float timer2;
    public GameObject aiming;
    private Animator anim;
    private ShootingBarrel shootingBarrel;
    private bool Shootbeforechargetime = false;

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
        //Set the gameobject to active on start
        //gameObject.SetActive(false);
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
        if (Vector3.Distance(waypoints[index].transform.position, transform.position) > Gap)
        {
            //Go towards the next position
            transform.position = Vector3.MoveTowards(transform.position, waypoints[index].transform.position, MovementSpeed * Time.deltaTime);
        }
        else if (transform.position == waypoints[index].transform.position)
        {
            if (index < waypoints.Count)
            {
                index += 1;
            }
        }
    }

    private void Dead()
    {
        if (Health <= 0)
        {
            ScoreManager.AddCurrentScore(ScoreManager.ScoreType.BossKill);
            gameObject.SetActive(false);
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
            if (timer >= ChargeTime)
            {
                //FindObjectOfType<Player>().Injure(Damage);
                timer = 0;
                aiming.SetActive(false);
                Shootbeforechargetime = true;
            }
        }
        else
        {
            timer2 += Time.deltaTime;
            if (timer2 >= RechargeTime)
            {
                Shootbeforechargetime = false;
                timer2 = 0;
            }
        }
    }
}