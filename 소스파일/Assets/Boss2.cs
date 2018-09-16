using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss2 : MonoBehaviour {

    // Use this for initialization
    public float speed;
    public float hp = 100;
    public float atk;
    private float TimeLeft = 2.0f;
    private float nextTime = 0.0f;
    public GameObject p;
    public GameObject bulletPrefab;
    private bool skill;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        Vector3 dir = (p.transform.position - transform.position).normalized;
        if (Vector3.Distance(transform.position, p.transform.position) < 30)
        {
            if (Time.time > nextTime)
            {
                nextTime = Time.time + TimeLeft;
                TimeLeft = Random.Range(0, 2);
               
                Fire();
            }
        }
    }

    void Fire()
    {

        GameObject bullet = Instantiate(bulletPrefab) as GameObject;
        Vector2 direction = (p.transform.position - transform.position).normalized;
        if (p.transform.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(1, 1, 1);

        }
        if (p.transform.position.x < transform.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        bullet.transform.up = direction;
        bullet.transform.position = transform.position;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            hp -= Player.power;

            if (hp <= 0)
            {
                Destroy(gameObject);

            }


        }
    }

}

