using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour {
    public float speed;
    public float hp = 100;
    public float atk;
    private float TimeLeft = 2.0f;
    private float nextTime = 0.0f;
    public GameObject p;
    public GameObject bulletPrefab;
    private bool skill;
	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {

        Vector3 dir = (p.transform.position - transform.position).normalized;
        if (Vector3.Distance(transform.position, p.transform.position) < 30)
        {
            if (Time.time > nextTime)
            {
                nextTime = Time.time + TimeLeft;
                TimeLeft = Random.Range(0, 2);
                MoveUpdate();
                Fire();
            }
        }
    }

    void Fire()
    {
        
            for (int i = 0; i < 8; i++)
            {
            int num = 3;
                if (i == 0)
                {
                    Vector2 direction = new Vector2(-1, 1);
                    GameObject bullet = Instantiate(bulletPrefab) as GameObject;
                    bullet.transform.up = direction;
                    bullet.transform.position = transform.position;
                Destroy(bullet, num);
            }
                else if (i == 1)
                {
                    Vector2 direction = new Vector2(1, 1);
                    GameObject bullet = Instantiate(bulletPrefab) as GameObject;
                    bullet.transform.up = direction;
                    bullet.transform.position = transform.position;
                Destroy(bullet, num);
            }
                else if (i == 2)
                {
                    Vector2 direction = new Vector2(-1, -1);
                    GameObject bullet = Instantiate(bulletPrefab) as GameObject;
                    bullet.transform.up = direction;
                    bullet.transform.position = transform.position;
                Destroy(bullet, num);
            }
                else if (i == 3)
                {
                    Vector2 direction = new Vector2(1, -1);
                    GameObject bullet = Instantiate(bulletPrefab) as GameObject;
                    bullet.transform.up = direction;
                    bullet.transform.position = transform.position;
                Destroy(bullet, num);
            }
                else if (i == 4)
                {
                    Vector2 direction = new Vector2(0, 1);
                    GameObject bullet = Instantiate(bulletPrefab) as GameObject;
                    bullet.transform.up = direction;
                    bullet.transform.position = transform.position;
                Destroy(bullet, num);
            }
                else if (i == 5)
                {
                    Vector2 direction = new Vector2(1, 0);
                    GameObject bullet = Instantiate(bulletPrefab) as GameObject;
                    bullet.transform.up = direction;
                    bullet.transform.position = transform.position;
                Destroy(bullet, num);
            }
                else if (i == 6)
                {
                    Vector2 direction = new Vector2(-1, 0);
                    GameObject bullet = Instantiate(bulletPrefab) as GameObject;
                    bullet.transform.up = direction;
                    bullet.transform.position = transform.position;
                Destroy(bullet, num);
            }
                else if (i == 7)
                {
                    Vector2 direction = new Vector2(0, -1);
                    GameObject bullet = Instantiate(bulletPrefab) as GameObject;
                    bullet.transform.up = direction;
                    bullet.transform.position = transform.position;
                Destroy(bullet, num);
            }

          //  Destroy(bullet, 3);

        }


    }

    void MoveUpdate()
    {
        //Vector3 dir = (p.transform.position - transform.position).normalized;
        //if (Vector3.Distance(transform.position, p.transform.position) < 30)
        //{
            //if(transform.position.x > p.transform.position.x)
            //transform.position += new Vector3(dir.x, dir.y) * speed * Time.deltaTime;
            if (transform.position.x > p.transform.position.x)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            else
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
       // }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            hp -= Player.power;

            if (hp <= 0)
            {
                Destroy(gameObject);
                SceneManager.LoadScene("Final");
            }


        }
    }
}
