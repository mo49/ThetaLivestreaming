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

	public void SetCastTime(float count) {
		castTimeText = transform.Find("CastTime").gameObject.GetComponent<Text>();
		
		castTimeText.text = count.ToString();
	}

	public IEnumerator StartCountdown(float count) {
		while(count >= 0) {
			SetCastTime(count);
			count--;
			yield return new WaitForSeconds(1f);
		}
	}
}
