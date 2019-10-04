using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BossMaker : MonoBehaviour
{

    // Use this for initialization

    private Transform bg;
    public Sprite[] bossImg;

    public GameObject boss;
    private float count = 0;
    void Start()
    {
        bg = GameObject.Find("bg").transform;
        InvokeRepeating("MakeBoss", 0, 3f);
    }

    // Update is called once per frame
    void Update()
    {
		
    }

    void MakeBoss()
    {
		count++;
        print(count);
        if (count % 5 == 0)
        {
            GameObject g = Instantiate(boss, new Vector2(220, 1000), bg.rotation);
            g.GetComponent<Image>().sprite = bossImg[0];
            g.transform.SetParent(bg);
        }
    }
}
