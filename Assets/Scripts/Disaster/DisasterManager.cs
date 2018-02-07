using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisasterManager : MonoBehaviour {

	private static DisasterManager m_instance;
	private bool isCasting = false;

	public static DisasterManager Instance {
		get {
			if(m_instance == null) {
				GameObject obj = new GameObject("DisasterManager");
				m_instance = obj.AddComponent<DisasterManager>();
			}
			return m_instance;
		}
	}

	public void SetIsCasting(bool tmp) {
		this.isCasting = tmp;
	}

	public bool GetIsCasting() {
		return this.isCasting;
	}
}
