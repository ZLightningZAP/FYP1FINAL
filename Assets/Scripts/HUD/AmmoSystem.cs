using UnityEngine;
using UnityEngine.UI;

public class AmmoSystem : MonoBehaviour
{
    private float MaxBullet = 1;
    private float currentBullet = 1;
    private int Bullet;

    public int BulletPerClip;
    public float bulletBelt = 0.01f;
    public int bullet { get { return Bullet; } set { Bullet = value; } }
    public Text bulletText;

    // Use this for initialization
    private void Start()
    {
        BulletPerClip = 100;
        Bullet = BulletPerClip;
    }

    // Update is called once per frame
    private void Update()
    {
        AmmoUpdateUI();
    }

    public void AmmoUpdateUI()
    {
        //Increase the heating guage
        currentBullet -= bulletBelt;
        //Clamps the current heat so that it doesnt go crazy
        currentBullet = Mathf.Clamp(currentBullet, 0, MaxBullet);

        bulletText.text = Bullet.ToString("F0");
    }

    public void Reload()
    {
        currentBullet = 1;
        Bullet = BulletPerClip;
    }

    public void AmmoFire()
    {
        Bullet -= 1;
    }
}