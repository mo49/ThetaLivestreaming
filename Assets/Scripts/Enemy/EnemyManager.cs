using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

	private static EnemyManager m_instance;
	private int maxCount;
	private int currentIndex;
	private int aliveCount;
	

	public static EnemyManager Instance {
		get {
			if(m_instance == null) {
				GameObject obj = new GameObject("EnemyManager");
				m_instance = obj.AddComponent<EnemyManager>();
			}
			return m_instance;
		}
	}

	public void SetMaxCount(int num) {
		this.maxCount = num <= 0 ? 0 : num ;
	}

	public int GetMaxCount() {
		return this.maxCount;
	}

	public void SetCurrentIndex(int num) {
		this.currentIndex = num <= 0 ? 0 : num ;
	}

	public int GetCurrentIndex() {
		return this.currentIndex;
	}

	public void SetAliveCount(int num) {
		this.aliveCount = num <= 0 ? 0 : num ;
	}

	public int GetAliveCount() {
		return this.aliveCount;
	}


}
