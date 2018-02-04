using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
		if(other.tag == "RealPlayer") {
			GetComponent<Rigidbody> ().velocity = Vector3.zero;

			// attack
		}
	}
}
