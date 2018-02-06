using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitPointManager : MonoBehaviour {

	private static HitPointManager m_instance;
	private int hp;

	public static HitPointManager Instance {
		get {
			if(m_instance == null) {
				GameObject obj = new GameObject("HitPointManager");
				m_instance = obj.AddComponent<HitPointManager>();
			}
			return m_instance;
		}
	}

	public void SetHP(int num) {
		this.hp = num <= 0 ? 0 : num ;
	}

	public int GetHP() {
		return this.hp;
	}
}
