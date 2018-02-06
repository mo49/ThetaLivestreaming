using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRotate : MonoBehaviour {

	float _tumble = 0.3f;

	void Start() {
		GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * _tumble;
	}
}
