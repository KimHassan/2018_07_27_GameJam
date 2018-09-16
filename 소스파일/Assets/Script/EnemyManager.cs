using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

    public float x1;
    public float x2;
    public float y1;
    public float y2;
    public int count = 20;
    public GameObject Enemy;

    // Use this for initialization
    void Start () {
        for (int i = 0; i < count; i++)
        {
            float x = Random.Range(x1, x2);
            float y = Random.Range(y1, y2);

            GameObject Block = Instantiate(Enemy) as GameObject;

            Block.transform.position = new Vector3(x, y);
            Block.transform.parent = transform;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}


    // Use this for initialization
   
}
