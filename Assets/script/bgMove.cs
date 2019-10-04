using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgMove : MonoBehaviour {

    private Transform bg;

    private float x;
    private float y;

private Material m_material;
    void Start()
    {
        bg = GameObject.Find("bg").transform;
		
       
    }

    // Update is called once per frame
    void Update()
    {
		 x = transform.position.x;
         y = transform.position.y;
	   transform.Translate(Vector3.down * Time.deltaTime * 153f);
	   if(y<=-430)
	   {
		  transform.position=new Vector3(transform.position.x,1285,transform.position.z);
	   }

    }
}
