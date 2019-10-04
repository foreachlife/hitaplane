using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float speed = 1f;
    public GameObject bullet;
    private int x;
    private int y;
    public static Weapon _instance;


    public static Weapon GetWeapon{
        get{
            return _instance;
        }
    }

    private Transform bg;
    public  bool isfireOpen = false;
    public float shootRate = 0.5f;
    public static List<GameObject> bulletlist=new List<GameObject>();
    private
    
    void Awake(){
        _instance=this;
    }
    void Start()
    {
        bg = GameObject.Find("bg").transform;
        makeBullet();
    }


    void Update()
    {
       
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
                bulletlist.Add(g);
                int s=-10+i*10;
                g.transform.SetPositionAndRotation(new Vector3(transform.position.x+s, transform.position.y + 30, 0),transform.rotation);
            }
        }else{
             GameObject g = GameObject.Instantiate(bullet, new Vector3(transform.position.x, transform.position.y + 30, 0), transform.rotation);
                g.transform.SetParent(bg);
        }


    }
}
