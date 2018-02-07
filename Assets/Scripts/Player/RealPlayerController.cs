using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealPlayerController : MonoBehaviour {

	[SerializeField] MeshRenderer m_playerRenderer;

	void Update () {
		if(Input.GetKeyDown(KeyCode.Alpha1)) {
			m_playerRenderer.enabled = !m_playerRenderer.enabled;
		}
	}

}
