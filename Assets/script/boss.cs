using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	void Awake(){
	 
	}
	// Update is called once per frame
	void Update () {
		
		if(Time.time<9){
			transform.Translate(Vector2.down*30* Time.deltaTime);
		}
	}
 
}
