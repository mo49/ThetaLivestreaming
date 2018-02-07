using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchUI : MonoBehaviour {

	Transform mainCameraTrans;

	void Start () {
		mainCameraTrans = GameObject.FindGameObjectWithTag("MainCamera").transform;
	}
	
	void Update () {
		transform.LookAt(mainCameraTrans);
	}
}
