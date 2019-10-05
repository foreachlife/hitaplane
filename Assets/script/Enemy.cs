using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

    private float speed = 3f;
    private float x;
    private float y;

    public Sprite[] enemyImg1;
    public Sprite[] enemyImg2;
    private int life = 5;
    private int enemy2life=7;
    private int i = 0;
    private int j = 0;
    private int k = 0;
    private bool isleft = false;
    private float bx;
    private float by;
    public Sprite[] bossImg;
    private int bosslife = 100;
    void Start()
    {
    }
    void Awake()
    {
        x = transform.position.x;
        y = transform.position.y;
        x = x > 0 ? Random.Range(-15, 0) : Random.Range(5, 20);
        y = y > 0 ? Random.Range(-15, 0) : Random.Range(30, 50);

    }
    void Update()
    {
        if (transform.tag == "boss")
        {
            bx = transform.position.x;
            by = transform.position.y;
            if (by > 730)
            {
                transform.Translate(Vector2.down * 30 * Time.deltaTime);
            }
            else
            {
                if (isleft)
                {
                    if (bx > 340)
                    {
                        isleft = false;
                    }
                    else
                    {
                        transform.Translate(Vector2.right * 30 * Time.deltaTime);
                    }
                }
                else if (!isleft)
                {
                    if (bx < 120)
                    {
                        isleft = true;
                    }
                    else
                    {
                        transform.Translate(Vector2.left * 30 * Time.deltaTime);
                    }
                }
            }
        }
        else if (transform.tag == "enemy"||transform.tag=="enemy2")
        {
            transform.Translate(new Vector2(x, y) * speed * Time.deltaTime);
        }

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {

        if (transform.tag == "enemy")
        {
            if (collider.gameObject.CompareTag("border"))
            {
                Destroy(this.gameObject);
            }
            else if (collider.gameObject.CompareTag("bullet"))
            {
                life--;
                if (life <= 0)
                {
                    InvokeRepeating("deadEnemy", 0, 0.1f);
                }
            }
        }else if(transform.tag == "enemy2"){
             if (collider.gameObject.CompareTag("border"))
            {
                Destroy(this.gameObject);
            }
            else if (collider.gameObject.CompareTag("bullet"))
            {
                enemy2life--;
                if (enemy2life <= 0)
                {
                    InvokeRepeating("deadEnemy", 0, 0.1f);
                }
            }
        }
        else if (transform.tag == "boss")
        {
            if (collider.gameObject.CompareTag("bullet"))
            {
                bosslife--;
                if (bosslife <= 0)
                {
                    InvokeRepeating("deadBoss", 0, 2f);
                }
            }
        }
    }
    void deadEnemy()
    {
        if (transform.tag == "enemy")
        {
            i++;
            transform.GetComponent<Image>().sprite = enemyImg1[i];
            if (transform.GetComponent<Image>().sprite == enemyImg1[3])
            {
                i = 0;
                life = 5;
                UiController.Instance.UpdateScore();
                CancelInvoke();
                Destroy(this.gameObject);

            }
        }

        else if (transform.tag == "enemy2")
        {
            j++;
            transform.GetComponent<Image>().sprite = enemyImg2[j];
            if (transform.GetComponent<Image>().sprite == enemyImg2[3])
            {
                j = 0;
                enemy2life = 7;
                UiController.Instance.UpdateScore(500);
                CancelInvoke();
                Destroy(this.gameObject);
            }
        }
    }

    void deadBoss()
    {
        k++;
        transform.GetComponent<Image>().sprite = bossImg[k];
        if (transform.GetComponent<Image>().sprite == bossImg[5])
        {
            k = 0;
            bosslife = 20;
            UiController.Instance.UpdateScore(2000);
            CancelInvoke();
            Destroy(this.gameObject);
        }
    }
}
