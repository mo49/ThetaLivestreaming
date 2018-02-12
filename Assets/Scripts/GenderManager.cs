using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenderManager : MonoBehaviour {

	private static GenderManager m_instance;
	private string gender = "male";

	public static GenderManager Instance {
		get {
			if(m_instance == null) {
				GameObject obj = new GameObject("GenderManager");
				m_instance = obj.AddComponent<GenderManager>();
			}
			return m_instance;
		}
	}

	public void SetGender(string _gender) {
		this.gender = _gender;
	}

	public string GetGender() {
		return this.gender;
	}
}
