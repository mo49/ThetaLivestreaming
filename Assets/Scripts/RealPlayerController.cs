using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealPlayerController : MonoBehaviour {

	[SerializeField] GameObject m_realPlayer;

	bool isActive = true;

	void Update () {
		if(Input.GetKeyDown(KeyCode.Alpha1)) {
			Toggle();
		}
	}

	void Toggle() {
		if(isActive) {
			m_realPlayer.SetActive(false);
		} else {
			m_realPlayer.SetActive(true);
		}
		isActive = !isActive;
	}
}
