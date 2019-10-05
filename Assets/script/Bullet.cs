using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Bullet : MonoBehaviour
{

    private float speed = 100;

    public AudioClip bulletKick;

    public static bool alive=true;
    // Update is called once per frame
    void Update()
    {
        if (transform.tag == "bullet"&&alive)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                speed = speed * 3;
            }
            {
                float res = Hero.getHero.transform.position.x - transform.position.x;
                int result = res > 0 ? 1 : res < 0 ? -1 : 0;
                switch (result)
                {
                    case -1:
                        transform.Translate(new Vector2(0, 11) * speed * Time.deltaTime);
                        break;
                    case 1:
                        transform.Translate(new Vector2(0, 11) * speed * Time.deltaTime);
                        break;
                    default:
                        break;
                }
            }

            transform.Translate(Vector2.up * speed * Time.deltaTime * 8);
        }
        else if (alive&&transform.tag == "enemyBullet")
        {
            transform.Translate(Vector2.down * 300 * Time.deltaTime);
        }else if (alive&&transform.tag == "bossBullet")
        {
            float res = Hero.getHero.transform.position.x - transform.position.x;
                int result = res > 0 ? 1 : res < 0 ? -1 : 0;
                switch (result)
                {
                    case -1:
                        transform.Translate(new Vector2(-1, -11) * 10 * Time.deltaTime);
                        break;
                    case 1:
                        transform.Translate(new Vector2(1, -11) * 10 * Time.deltaTime);
                        break;
                    default:
                        break;
                }
        }

    }


    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (transform.tag == "bullet")
        {
            if (collider.gameObject.CompareTag("enemy")||collider.gameObject.CompareTag("enemy2")||collider.gameObject.CompareTag("boss"))
            {
                AudioSource.PlayClipAtPoint(bulletKick, Vector3.zero);
                Destroy(this.gameObject);
            }
            else if (collider.gameObject.CompareTag("border"))
            {
                Destroy(this.gameObject);
            }
        }
        else if (transform.tag == "enemyBullet" || transform.tag == "bossBullet")
        {
            if (collider.gameObject.CompareTag("border"))
            {
                AudioSource.PlayClipAtPoint(bulletKick, Vector3.zero);
                Destroy(this.gameObject);
            }
            else if (collider.gameObject.CompareTag("hero"))
            {
                AudioSource.PlayClipAtPoint(bulletKick, Vector3.zero);
                Destroy(this.gameObject);
            }
        }


    }
}
