using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {

	
    public AudioClip bulletKick;

    // Update is called once per frame
    void Update()
    {
       transform.Translate(Vector2.down*300* Time.deltaTime);
    }


    private void OnTriggerEnter2D(Collider2D collider)
    {
         if (collider.gameObject.CompareTag("hero"))
        {	
			print("bullet die");
            AudioSource.PlayClipAtPoint(bulletKick,Vector3.zero);
            Destroy(this.gameObject);
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
        }  else if (collider.gameObject.CompareTag("border"))
        {
            Weapon.bulletlist.Remove(this.gameObject);
            Destroy(this.gameObject);
        }

    }
}
