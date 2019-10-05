using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{

    public GameObject enemyBullet;
    private Transform bg;
    void Start()
    {
        bg = GameObject.Find("bg").transform;
        makeEnemybullet();
    }


    void Update()
    {

    }

    void makeEnemybullet()
    {
        InvokeRepeating("MakeEnemybullet", 0, 2f);
    }

    void MakeEnemybullet()
    {
        if (transform.tag == "boss")
        {
            GameObject g = GameObject.Instantiate(enemyBullet, new Vector3(transform.position.x, transform.position.y - 30, 0), transform.rotation);
            g.transform.SetParent(bg);
            g.transform.tag = "bossBullet";
        }
        else
        {
            GameObject g = GameObject.Instantiate(enemyBullet, new Vector3(transform.position.x, transform.position.y - 30, 0), transform.rotation);
            g.transform.SetParent(bg);
        }

    }
}
