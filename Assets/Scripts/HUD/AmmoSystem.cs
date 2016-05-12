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
    public GameObject BulletPlacementbox;

    private float x;
    private float y;
    private float sizeX;
    private float sizeY;
    private float Xup;
    private float Yup;
    private Vector2 coordinate;

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
            bulletshell[i].GetComponent<RectTransform>().SetParent(canvas.transform, false);
        }

        //Getting the bottom left coordinate of the box
        Vector2 temppos = BulletPlacementbox.GetComponent<RectTransform>().position;
        coordinate = temppos - (BulletPlacementbox.GetComponent<RectTransform>().sizeDelta * 0.5f);

        x = (BulletPlacementbox.GetComponent<RectTransform>().sizeDelta.x * 0.5f);
        y = (BulletPlacementbox.GetComponent<RectTransform>().sizeDelta.y * 0.5f);
        sizeX = BulletPlacementbox.GetComponent<RectTransform>().sizeDelta.x;
        sizeY = BulletPlacementbox.GetComponent<RectTransform>().sizeDelta.y;
        Xup = sizeX / 67;
        Yup = sizeY / 3;

        x = (BulletPlacementbox.GetComponent<RectTransform>().sizeDelta.x * 0.5f);
        for (int i = 0; i < 67; ++i)
        {
            bulletshell[i].GetComponent<RectTransform>().localPosition = new Vector2(0 - x, 0 + Yup);
            x -= Xup;
        }

        x = (BulletPlacementbox.GetComponent<RectTransform>().sizeDelta.x * 0.5f);
        for (int i = 67; i < 134; ++i)
        {
            bulletshell[i].GetComponent<RectTransform>().localPosition = new Vector2(0 - x, 0);
            x -= Xup;
        }

        x = (BulletPlacementbox.GetComponent<RectTransform>().sizeDelta.x * 0.5f);
        for (int i = 134; i < 200; ++i)
        {
            bulletshell[i].GetComponent<RectTransform>().localPosition = new Vector2(0 - x, 0 - Yup);
            x -= Xup;
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