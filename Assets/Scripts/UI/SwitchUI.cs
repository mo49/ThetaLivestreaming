using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchUI : MonoBehaviour {

	Transform mainCameraTrans;
	Text castTimeText;

	void Awake () {
		mainCameraTrans = GameObject.FindGameObjectWithTag("MainCamera").transform;
	}
	
	void Update () {
		transform.LookAt(mainCameraTrans);
	}

	public void SetCastTime(string text) {
		castTimeText = transform.Find("CastTime").gameObject.GetComponent<Text>();
		
		castTimeText.text = text;
	}
}
