using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodMaker : MonoBehaviour {


    public GameObject propOne;

    private Transform bg;

    void Start()
    {
        bg = GameObject.Find("bg").transform;
        makeFood();
    }
	
	// Update is called once per frame
	void Update () {
		
	}


	
    void makeFood()
    {
        if (Random.Range(1, 10) > 1)
        {
            GameObject prop1 = Instantiate(propOne, new Vector3(Random.Range(0, 400), 900), transform.rotation);
            prop1.transform.SetParent(bg);
        }

    }
}
