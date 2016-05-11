using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoSystem : MonoBehaviour
{
    private int Bullet;

    public int BulletPerClip;
    public int bullet { get { return Bullet; } set { Bullet = value; } }

    private List<GameObject> bulletshell = new List<GameObject>();
    public Text bulletText;

    public GameObject bulletshells;
    public GameObject canvas;
    private float x;
    private float y;

    private Color originalColor;

    // Use this for initialization
    private void Start()
    {
        Bullet = BulletPerClip;

        originalColor = bulletshells.gameObject.GetComponent<Image>().color;

        for (int i = 0; i < BulletPerClip; ++i)
        {
            GameObject go = Instantiate(bulletshells) as GameObject;
            bulletshell.Add(go);
            bulletshell[i].transform.SetParent(canvas.transform, false);
        }

        x = 850;
        for (int i = 0; i < 67; ++i)
        {
            bulletshell[i].transform.position = new Vector3(x, 50, 0);
            x += 3;
        }

        x = 850;
        for (int i = 67; i < 134; ++i)
        {
            bulletshell[i].transform.position = new Vector3(x, 37, 0);
            x += 3;
        }

        x = 850;
        for (int i = 134; i < 200; ++i)
        {
            bulletshell[i].transform.position = new Vector3(x, 24, 0);
            x += 3;
        }
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

        for (int i = 0; i < BulletPerClip; ++i)
        {
            bulletshell[i].gameObject.GetComponent<Image>().color = originalColor;
        }
    }

    public void AmmoFire()
    {
        Bullet -= 1;
        Color color = new Color();
        color.a = 0.5f;
        bulletshell[Bullet].gameObject.GetComponent<Image>().color = color;
    }
}