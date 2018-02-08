﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour {

	[SerializeField] Transform targetTrans;
	[SerializeField] bool isTargetXValid = true;
	[SerializeField] bool isTargetYValid = true;
	[SerializeField] bool isTargetZValid = true;

	Transform objTrans;

	void Start () {
		objTrans = gameObject.transform;
	}
	
	void Update () {
		objTrans.LookAt(new Vector3(
			isTargetXValid ? targetTrans.position.x : objTrans.position.x,
			isTargetYValid ? targetTrans.position.y : objTrans.position.y,
			isTargetZValid ? targetTrans.position.z : objTrans.position.z
		));
	}
}
