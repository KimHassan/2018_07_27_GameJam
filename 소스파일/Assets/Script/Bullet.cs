using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float speed = 20f;
    float m_fRot = 0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        m_fRot += Time.deltaTime * 20;

       // transform.localEulerAngles = new Vector3(0, 0, m_fRot);
        transform.Translate(Vector3.right * speed * Time.deltaTime);
        
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
            return;
        if(collision.gameObject.tag == "Block")
        {
            Destroy(gameObject);
        }
        if(collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "TileMap")
        {
            Destroy(gameObject);
        }

    }
}
