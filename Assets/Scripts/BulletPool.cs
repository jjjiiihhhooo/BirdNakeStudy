using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public static BulletPool instance;

    [SerializeField] private int size;
    [SerializeField] private Bullet bullet;

    [SerializeField] private List<Bullet> bulletList;


    private void Awake()
    {
        instance = this;
        bulletList = new List<Bullet>();

    }

    private void Start()
    {
        for (int i = 0; i < size; i++)
        {
            CreatePool();
        }
    }
    private void CreatePool()
    {
        Bullet temp = Instantiate(bullet, transform);
        bulletList.Add(temp);
        temp.gameObject.SetActive(false);
    }

    public Bullet PopBullet()
    {
        Bullet temp = null;
        for (int i = 0; i < bulletList.Count; i++)
        {
            if (bulletList[i].gameObject.activeSelf == false)
            {
                temp = bulletList[i];
                break;
            }
        }
        if (temp == null)
        {
            CreatePool();
            temp = bulletList[bulletList.Count - 1];
        }
        return temp;
    }
}
