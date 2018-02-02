using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {
	
	[SerializeField] GameObject m_ballPrefab;

	Transform m_mainCameraTrans;

	void Start() {
		m_mainCameraTrans = GameObject.Find("Main Camera").transform;
	}
	
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space)) {
			Instantiate(m_ballPrefab, m_mainCameraTrans.position + m_mainCameraTrans.forward * 2f, Quaternion.identity);
		}
	}
}
