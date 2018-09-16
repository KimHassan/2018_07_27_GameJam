using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float speed = 10f;
    public float SpawnX;
    public float SpawnY;
    static public float hp = 8.0f;
    static public float power = 7.0f;
    private float TimeLeft = 2.0f;
    private float nextTime = 0.0f;
    public GameObject bulletPrefab;
    public Transform fire;


    Animator animator;
	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        MoveUpdate();
        ShowUpdate();
        Fire();
        if (Time.time > nextTime)
        {
            nextTime = Time.time + TimeLeft;
            setDirection();


        }


    }

    void MoveUpdate()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        float rote = Input.GetAxisRaw("Horizontal");
        //animator.SetBool("isMoving", false);
        //if (Input.GetButtonDown("Horizontal"))
        //{
        //    animator.SetBool("isMoving", true);

        //}

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePosition - transform.position).normalized;
        if (rote > 0)
        {
            // transform.localScale = new Vector3(1, 1, 1);
            //transform.Rotate(new Vector3(0, 180, 0), Space.Self);
           
                
        }
        else if (rote < 0)
        {
           // transform.localScale = new Vector3(-1, 1, 1);

            //transform.Rotate(new Vector3(0, 0, 0), Space.Self);
           
        }
        fire.right = direction;
        if (transform.localScale.x == 1)
        {
            fire.transform.localScale = new Vector3(1, 1, 1);
        }
        else if(transform.localScale.x == -1)
        {
            fire.transform.localScale = new Vector3(-1, -1, 1);
        }
        if (mousePosition.x > transform.position.x)
        {
            transform.localScale = new Vector3(1, 1, 1);

        }
        if (mousePosition.x < transform.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        transform.position += new Vector3(horizontal, vertical) * speed * Time.deltaTime;

        if(hp <0)
        {
            transform.position = new Vector3(SpawnX, SpawnY);
            hp = 8.0f;
        }
    }

    void ShowUpdate()
    {

    }
    void Fire()
    {
        //GameObject.Find("sound").GetComponent<AudioSource>().Play();
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = (mousePosition - transform.position).normalized;
            GameObject bullet = Instantiate(bulletPrefab) as GameObject;
            if(mousePosition.x > transform.position.x)
            {
                transform.localScale = new Vector3(1, 1, 1);
                
            }
            if (mousePosition.x < transform.position.x)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            bullet.transform.right = direction;
            bullet.transform.position = fire.position;

            

            Destroy(bullet, 4);
        }
        else
        {
           // Invoke("setDirection", 5.0f);
        }
    }
    void setDirection()
    {
        float rote = Input.GetAxisRaw("Horizontal");

        if (rote > 0)
        {
             transform.localScale = new Vector3(1, 1, 1);

        }
        else if (rote < 0)
        {
             transform.localScale = new Vector3(-1, 1, 1);

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag =="Enemy")
        {
            Vector3 dir = (collision.transform.position - transform.position).normalized;
            transform.position += new Vector3(dir.x, dir.y) * -75 * Time.deltaTime;
            hp -= 1.0f;
            // transform.position += new Vector3(horizontal, vertical) * speed * Time.deltaTime;
        }
        if (collision.transform.tag == "EnemyBullet")
        {

            hp -= 0.5f;
            // transform.position += new Vector3(horizontal, vertical) * speed * Time.deltaTime;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Enemy"))
        {
            /* 여기서 부터 추가된 부분*/
            
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
