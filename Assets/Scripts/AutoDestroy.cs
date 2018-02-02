using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour {

	[SerializeField] float m_lifeSpan;

	void Start() {
		Invoke("Destroy", m_lifeSpan);
	}

	void Destroy() {
		Destroy(gameObject);
	}
}
