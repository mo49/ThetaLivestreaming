﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	void Start () {
		float speed = Random.Range(20f, 30f);
		Transform MainCamTrans = GameObject.FindGameObjectWithTag ("MainCamera").transform;
		GetComponent<Rigidbody>().AddForce(MainCamTrans.forward * speed, ForceMode.VelocityChange);
	}
	
}
