using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	
	void Update () {
		transform.Translate(Vector2.down * 100 * Time.deltaTime);
	}

	private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("hero"))
        {
		   Weapon.GetWeapon.isfireOpen=true;
           Destroy(this.gameObject);
        }else if(collider.gameObject.CompareTag("border")){
			 Destroy(this.gameObject);
		}

    }



}
