using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Imagess : MonoBehaviour {

    // Use this for initialization
    //private SpriteRenderer a;
    public Image DeImage;
    public Sprite[] sp;
   
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		if(Player.hp >= 7)
        {
            DeImage.sprite = sp[7];
        }
        else if (Player.hp >= 6)
        {
            DeImage.sprite = sp[6];
        }
        else if (Player.hp >= 5)
        {
            DeImage.sprite = sp[5];
        }
        else if (Player.hp >= 4)
        {
            DeImage.sprite = sp[4];
        }
        else if (Player.hp >= 3)
        {
            DeImage.sprite = sp[3];
        }
        else if (Player.hp >= 2)
        {
            DeImage.sprite = sp[2];
        }
        else if (Player.hp >= 1)
        {
            DeImage.sprite = sp[1];
        }
        else if (Player.hp == 0)
        {
            DeImage.sprite = sp[0];
        }
    }
}
