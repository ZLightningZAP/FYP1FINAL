using UnityEngine;
using UnityEngine.UI;

public class AmmoSystem : MonoBehaviour
{
    private int MaxHeat = 1;
    private float MaxBullet = 1;
    private float currentBullet = 1;
    private int Bullet;

    public int BulletPerClip;
    public float bulletBelt = 0.01f;
    public int bullet { get { return Bullet; } set { Bullet = value; } }
    public Image BulletUI;

    // Use this for initialization
    private void Start()
    {
        BulletPerClip = 100;
        Bullet = BulletPerClip;
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public void AmmoUpdateUI()
    {
        //Increase the heating guage
        currentBullet -= bulletBelt;
        //Clamps the current heat so that it doesnt go crazy
        currentBullet = Mathf.Clamp(currentBullet, 0, MaxBullet);

        //Check if the current heating bar is not null
        //Update the current heating bar transform
        if (BulletUI != null)
        {
            BulletUI.fillAmount = currentBullet;
        }
    }

    public void Reload()
    {
        currentBullet = 1;
        AmmoUpdateUI();
        Bullet = BulletPerClip;
    }

    public void AmmoFire()
    {
        Bullet -= 1;
    }
}