using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

    public GameObject enemy;
    private float speed = 3f;
    private float x;
    private float y;

    public Sprite[] spritesOne;

    private int life = 5;
    private Transform bg;
    private int i = 0;

    void Start()
    {
        bg = GameObject.Find("bg").transform;
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
        transform.Translate(new Vector2(x, y) * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collider)
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
    }
    void deadEnemy()
    {
        i++;
        transform.GetComponent<Image>().sprite = spritesOne[i];
        if (transform.GetComponent<Image>().sprite == spritesOne[3])
        {
            i = 0;
            life = 5;
            UiController.Instance.UpdateScore();
            CancelInvoke();
            Destroy(this.gameObject);
            
        }
        
       
       

    }
}
