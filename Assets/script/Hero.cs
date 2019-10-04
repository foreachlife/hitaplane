using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Hero : MonoBehaviour
{

    private int x;
    private int step = 4;
    private int y;
    public static Hero _hero;



    public static Hero getHero
    {
        get
        {
            return _hero;
        }
    }

    private Vector3 hero;

    private float volitory = 0.2f;

    void Awake()
    {

        _hero = this;
    }
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        Vector3 vector = transform.position;
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
        {
            x = 0;
            y = 0;
            step = 5;
            CancelInvoke();
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            x = -step;
            y = 0;
            MoveLeft();
            if (!Input.GetKeyUp(KeyCode.A))
            {
                InvokeRepeating("MoveLeft", 0, volitory);
            }
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            x = step;
            y = 0;
            MoveRight();
            if (!Input.GetKeyUp(KeyCode.D))
            {
                InvokeRepeating("MoveRight", 0, volitory);
            }
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            x = 0;
            y = step;
            MoveUp();
            if (!Input.GetKeyUp(KeyCode.W))
            {
                InvokeRepeating("MoveUp", 0, volitory);
            }
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            x = 0;
            y = -step;
            MoveDown();
            if (!Input.GetKeyUp(KeyCode.S))
            {
                InvokeRepeating("MoveDown", 0, volitory);
            }
        }

    }

    void MoveLeft()
    {

        if (transform.position.x > 30)
        {
            if (volitory > 0.2f)
            {
                volitory -= 0.08f;
            }
            else
            {
                volitory = 0.02f;
            }
            hero = gameObject.transform.localPosition;
            gameObject.transform.localPosition = new Vector3(hero.x + x, hero.y + y, hero.z);
        }

    }

    void MoveRight()
    {
        if (transform.position.x < 450)
        {
            if (volitory > 0.2f)
            {
                volitory -= 0.08f;
            }
            else
            {
                volitory = 0.02f;
            }
            hero = gameObject.transform.localPosition;
            gameObject.transform.localPosition = new Vector3(hero.x + x, hero.y + y, hero.z);
        }
    }
    void MoveUp()
    {
        if (transform.position.y < 850)
        {
            if (volitory > 0.2f)
            {
                volitory -= 0.08f;
            }
            else
            {
                volitory = 0.02f;
            }
            hero = gameObject.transform.localPosition;
            gameObject.transform.localPosition = new Vector3(hero.x + x, hero.y + y, hero.z);
        }
    }


    void MoveDown()
    {
        if (transform.position.y > 30)
        {
            hero = gameObject.transform.localPosition;
            gameObject.transform.localPosition = new Vector3(hero.x + x, hero.y + y, hero.z);
        }
    }



    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("enemy"))
        {
            Die();
        }
        else if (collider.gameObject.CompareTag("enemyBullet"))
        {
            Die();
        }

    }

    void Die()
    {
        print("-----------------die--------------------");
        hero = gameObject.transform.localPosition;
        gameObject.transform.localPosition = new Vector3(hero.x + x, hero.y + y, hero.z);
        Destroy(this);
        int score = UiController.Instance.score;
        PlayerPrefs.SetInt("lastScore", score);

        if (PlayerPrefs.GetInt("bestScore") < score)
        {
            PlayerPrefs.SetInt("bestScore", score);
        }
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
    }
}
