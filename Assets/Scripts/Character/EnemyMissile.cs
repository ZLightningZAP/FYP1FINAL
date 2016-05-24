using UnityEngine;

public class EnemyMissile : Character
{
    public float MovementSpeed = 10.0f;   //Speed at which the missile travels
    public float RotationSpeed = 10.0f;   //Rotation Speed of missile while travelling

    public float Damage = 10;   //Damage that missile is able to inflict

    // Use this for initialization
    protected override void Start()
    {
        // Base Start
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        // Base Update
        base.Update();

        Dead();
        Move();
    }

    private void Dead()
    {
        //If enemy has 0 health, active will be set to false
        if (health == 0)
        {
            //Creating Explosion Effect
            VFXController.current.SpawnVFX(transform.position, Quaternion.identity, VFXController.VFX_TYPE.DEBRIS);
            VFXController.current.SpawnVFX(transform.position, Quaternion.identity, VFXController.VFX_TYPE.EXPLOSION_TYPE1);
            VFXController.current.SpawnVFX(transform.position, Quaternion.identity, VFXController.VFX_TYPE.EXPLOSIONSPARK_TYPE1);

            //Increasing score as destroyed by player
            ScoreManager.AddCurrentScore(ScoreManager.ScoreType.MissileDestroyed);

            SoundManager.PlaySoundEffect(SoundManager.SoundEffect.DroneImpact);
            //Deactivate object
            gameObject.SetActive(false);
        }
    }

    private void Move()
    {
        //Move towards target position
        GetComponent<Rigidbody>().velocity = (transform.rotation * Vector3.forward) * MovementSpeed;

        transform.Rotate(0, 0, RotationSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Getting point of contact (position & rotation based on contactpoint normal)
        ContactPoint contact = collision.contacts[0];
        Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
        Vector3 pos = contact.point;

        //Creating Explosion Effect on contact point
        VFXController.current.SpawnVFX(pos, rot, VFXController.VFX_TYPE.DEBRIS);
        VFXController.current.SpawnVFX(pos, rot, VFXController.VFX_TYPE.EXPLOSION_TYPE1);
        VFXController.current.SpawnVFX(pos, rot, VFXController.VFX_TYPE.EXPLOSIONSPARK_TYPE1);

        if (collision.gameObject.name == "Main Camera")
        {
            FindObjectOfType<Player>().Injure(Damage);
            SoundManager.PlaySoundEffect(SoundManager.SoundEffect.DroneImpact);
            print("Damaged by " + gameObject.name);
        }

        //Deactivate game object
        gameObject.SetActive(false);
    }
}