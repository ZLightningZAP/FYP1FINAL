using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    public float Speed = 10.0f;
    public int Damage = 5;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Bullet will mmove forward
        transform.Translate(Vector3.forward * Speed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        //Destroy the bullet upon collision with another object
        Destroy(gameObject);
    }
}
