using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BadLand : MonoBehaviour
{

    public GameObject enemy;
    public GameObject boss;
    private Transform bg;
    public Sprite[] bossImg;
    public Sprite[] enemys;
    private float lostTime;

    void Start()
    {
        bg = GameObject.Find("bg").transform;

        InvokeRepeating("MakeEnemy", 0, 3f);
    }

    void Awake()
    {
         bg=GameObject.Find("bg").transform;
       
                MakeBoss();
         
    }
    void Update()
    {   
         
       
    }
    void MakeBoss(){
         GameObject g = Instantiate(boss, new Vector2(220,1000),bg.rotation);
         g.GetComponent<Image>().sprite = bossImg[0];
         g.transform.SetParent(bg);
    }
    void MakeEnemy()
    {
        int num = Random.Range(1, 100);
        int i = num % 2;
        int x = i == 1 ? -60 : 520;
        int y = Random.Range(420,880);
        GameObject g = Instantiate(enemy, new Vector3(x,y),bg.rotation);
        g.GetComponent<Image>().sprite = enemys[0];
        g.transform.SetParent(bg);
    }
}
