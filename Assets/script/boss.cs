using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class boss : MonoBehaviour
{

    // Use this for initialization

    private float x;
    private float y;
    public Sprite[] bossImg;
    private int life = 20;
    private bool isleft = false;
    private int i = 0;
    void Start()
    {

    }
    void Awake()
    {

    }
    // Update is called once per frame
    void Update()
    {
        x = transform.position.x;
        y = transform.position.y;
        if (y > 730)
        {
            transform.Translate(Vector2.down * 30 * Time.deltaTime);
        }
        else
        {
            if (isleft)
            {
                print("right");
                if (x > 340)
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
                print("left");
                if (x < 120)
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

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("bullet"))
        {
            life--;
            print("life: " + life);
            if (life <= 0)
            {
                InvokeRepeating("deadBoss", 0, 1f);
            }
        }
    }
    void deadBoss()
    {
        i++;
        transform.GetComponent<Image>().sprite = bossImg[i];
        if (transform.GetComponent<Image>().sprite == bossImg[5])
        {
            i = 0;
            life =20;
            UiController.Instance.UpdateScore(2000);
            CancelInvoke();
            Destroy(this.gameObject);
        }
    }
}
