using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatusManager : MonoBehaviour {

	private static GameStatusManager m_instance;
	private string status = "playing";

	public static GameStatusManager Instance {
		get {
			if(m_instance == null) {
				GameObject obj = new GameObject("GameStatusManager");
				m_instance = obj.AddComponent<GameStatusManager>();
			}
			return m_instance;
		}
	}

	public void SetStatus(string _status) {
		this.status = _status;
	}

	public string GetStatus() {
		return this.status;
	}
}