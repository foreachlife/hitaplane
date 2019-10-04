﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyMaker : MonoBehaviour
{

    public GameObject enemy;
    
    public GameObject enemy2;
    private Transform bg;
    public Sprite[] enemys;
    public Sprite[] enemys2;
    void Start()
    {
        bg = GameObject.Find("bg").transform;
        InvokeRepeating("MakeEnemy", 0, 3f);
    }

    void Awake()
    {
        bg = GameObject.Find("bg").transform;
    }
    void Update()
    {   
        
    }
   
    void MakeEnemy()
    {
        int num = Random.Range(1, 100);
        int i = num % 2;
        int x = i == 1 ? -60 : 520;
        int y = Random.Range(420, 880);
        if(num<=20){
        GameObject g = Instantiate(enemy, new Vector3(x, y), bg.rotation);
        g.GetComponent<Image>().sprite = enemys[0];
        g.transform.SetParent(bg);
        }else{
        GameObject g = Instantiate(enemy2, new Vector3(x, y), bg.rotation);
        g.GetComponent<Image>().sprite = enemys2[0];
        g.transform.SetParent(bg);
        }
    }
}