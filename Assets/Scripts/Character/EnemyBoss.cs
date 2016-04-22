using UnityEngine.UI;

public class EnemyBoss : Character
{
    //Healthbar Image
    public Image healthBar;

    //Fill amount for the health bar
    private float HealthFillAmount;

    // Use this for initialization
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        // Update the healthbar
        HealthBarUpdate(Health);
        Move();
        Dead();
    }

    public void HealthBarUpdate(float health)
    {
        // Calculate the fill amount of the health bar
        HealthFillAmount = health / MaxHealth;
        healthBar.fillAmount = HealthFillAmount;
    }

    private void Move()
    {
    }

    private void Dead()
    {
        if (Health <= 0)
        {
            ScoreManager.AddCurrentScore(ScoreManager.ScoreType.BossKill);
            gameObject.SetActive(false);
        }
    }
}