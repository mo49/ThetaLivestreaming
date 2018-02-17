using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	float ry;
	Quaternion _rot;

	void Awake() {
		_rot = transform.rotation;
		ry = _rot.y;
	}

	void Update () {
		if(Input.GetKey(KeyCode.RightArrow)){
			ry++;
		}
		if(Input.GetKey(KeyCode.LeftArrow)){
			ry--;
		}
		transform.rotation = Quaternion.Euler (_rot.x, ry, _rot.z);
	}
}
