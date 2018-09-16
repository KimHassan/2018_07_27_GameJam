using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

    GameObject Player;

	void Start () {
        Player = GameObject.FindGameObjectWithTag("Player");
	}
	
	void FixedUpdate () {
        
        transform.position = Vector3.Lerp(this.transform.position, new Vector3(
            Player.transform.position.x, Player.transform.position.y, this.transform.position.z), Time.deltaTime * 3f);
	}
}
