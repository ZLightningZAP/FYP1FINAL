using UnityEngine;
using UnityEngine.UI;

public class AmmoSystem : MonoBehaviour
{
    private int Bullet;

    public int BulletPerClip;
    public int bullet { get { return Bullet; } set { Bullet = value; } }
    public Text bulletText;

    // Use this for initialization
    private void Start()
    {
        Bullet = BulletPerClip;
    }

    // Update is called once per frame
    private void Update()
    {
        AmmoUpdateUI();
    }

    public void AmmoUpdateUI()
    {
        bulletText.text = Bullet.ToString("F0");
    }

    public void Reload()
    {
        Bullet = BulletPerClip;
    }

    public void AmmoFire()
    {
        Bullet -= 1;
    }
}