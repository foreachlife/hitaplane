using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Bullet : MonoBehaviour
{

    private float speed = 100;

    public static bool fireOpen = false;


    public AudioClip bulletKick;
    public int x = 0;

    public int y = 1;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            speed = speed * 6;
        }
        float res = Weapon.GetWeapon.transform.position.x-transform.position.x;
        int result = res > 0 ? 1 : res < 0 ? -1 : 0;
        switch (result)
        {
            case -1:
                transform.Translate(new Vector2(1, 11) * speed * Time.deltaTime);
                break;
            case 1:
                transform.Translate(new Vector2(-1, 11) * speed * Time.deltaTime);
                break;
            default:
                transform.Translate(Vector2.up * speed * Time.deltaTime*8);
                break;
        }
    }


    private void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.gameObject.CompareTag("enemy"))
        {
            AudioSource.PlayClipAtPoint(bulletKick,Vector3.zero);
            Weapon.bulletlist.Remove(this.gameObject);
            Destroy(this.gameObject);
           
        }
        else if (collider.gameObject.CompareTag("border"))
        {
            Weapon.bulletlist.Remove(this.gameObject);
            Destroy(this.gameObject);
        } else if (collider.gameObject.CompareTag("boss"))
        {
            Destroy(this.gameObject);
        }

    }
}
