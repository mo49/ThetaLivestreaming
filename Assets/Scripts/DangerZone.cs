using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerZone : MonoBehaviour {
	[SerializeField] GameObject _dangerUI;

	bool isActive = false;

	void Start() {

	}

	void OnTriggerEnter(Collider other) {
		if(TagUtility.getParentTagName(other.gameObject) == "Enemy" && !isActive) {
			isActive = true;
			_dangerUI.SetActive(true);
		}
	}

	public void Hide() {
		isActive = false;
		_dangerUI.SetActive(false);
	}


}
