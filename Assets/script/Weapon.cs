using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bullet;
    public static Weapon _instance;


    public static Weapon GetWeapon
    {
        get
        {
            return _instance;
        }
    }

    private Transform bg;
    public static bool isfireOpen = false;
    public float shootRate = 0.5f;

    void Awake()
    {
        _instance = this;
    }
    void Start()
    {
        bg = GameObject.Find("bg").transform;
        if (transform.tag == "hero")
        {   
            makeBullet();
        }
        else if (transform.tag == "enemy" || transform.tag == "boss")
        {
            makeEnemybullet();
        }
    }


    void Update()
    {
        if(isfireOpen){
            
        }
    }
    void makeBullet()
    {
        InvokeRepeating("MakeBullet", 0, shootRate);

    }
    public void MakeBullet()
    {
        if (isfireOpen)
        {
            for (int i = 0; i < 3; i++)
            {
                GameObject g = GameObject.Instantiate(bullet, new Vector3(transform.position.x, transform.position.y + 30, 0), transform.rotation);
                g.transform.SetParent(bg);
                int s = -20 + i * 20;
                g.transform.tag = "bullet";
                g.transform.SetPositionAndRotation(new Vector3(transform.position.x + s, transform.position.y, 0), transform.rotation);

            }
        }
        else
        {
            GameObject g = GameObject.Instantiate(bullet, new Vector3(transform.position.x, transform.position.y + 30, 0), transform.rotation);
            g.transform.SetParent(bg);
            g.transform.tag = "bullet";
        }


    }


    void makeEnemybullet()
    {
        InvokeRepeating("MakeEnemybullet", 0, 2f);
    }

    void MakeEnemybullet()
    {
        if (transform.tag == "boss")
        {
            for (int i = 0; i < 3; i++)
            {
                GameObject g = GameObject.Instantiate(bullet, new Vector3(transform.position.x, transform.position.y - 50, 0), transform.rotation);
                g.transform.SetParent(bg);
                int s = -30 + i * 30;
                g.transform.tag = "bossBullet";
                g.transform.SetPositionAndRotation(new Vector3(transform.position.x + s, transform.position.y, 0), transform.rotation);

            }
        }
        else
        {
            GameObject g = GameObject.Instantiate(bullet, new Vector3(transform.position.x, transform.position.y - 30, 0), transform.rotation);
            g.transform.SetParent(bg);
            g.transform.tag = "enemyBullet";
        }

    }
}
