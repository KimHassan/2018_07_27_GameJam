﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explotion : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        Destroy(this.gameObject, 0.8f);
        //객체가 생성된 뒤 0.8초 뒤에 객체를 삭제합니다.
    }
    void Update()
    {

    }
}
