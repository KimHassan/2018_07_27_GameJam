using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float hp = 30;
    public int atk;
    public float speed = 3;
    public float wide;
    public GameObject p;
    public GameObject ex;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        MoveUpdate();
	}
    private void MoveUpdate()
    {
        Vector3 dir = (p.transform.position - transform.position).normalized;
        if (Vector3.Distance(transform.position, p.transform.position) < wide)
        {
            //if(transform.position.x > p.transform.position.x)
                transform.position += new Vector3(dir.x, dir.y) * speed * Time.deltaTime;
            if(transform.position.x > p.transform.position.x)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            else
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            //else if (transform.position.x < p.transform.position.x)
                //transform.position += new Vector3(1, p.transform.position.y) * speed * Time.deltaTime;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            hp -= Player.power;

            if (hp <= 0)
            {
                Instantiate(ex,
              // Instantiate는 객체를 하나 생성(복제)합니다 첫번째 인자로는 생성할 객체의 원본을 넣어주고
              this.transform.position,
              //두번째 인자로는 생성될 위치를 넣어줍니다. this.transform.position은 자기자신의 위치를 나타냅니다.
              Quaternion.identity);
                Destroy(gameObject);
            }
            
        }

    }
}
