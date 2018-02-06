using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyUI : MonoBehaviour {

	[SerializeField] Text m_enemyUI;

	EnemyManager enemyManager;

	void Start () {
		enemyManager = EnemyManager.Instance;
	}

	public void UpdateState() {
		m_enemyUI.text = "敵：" + enemyManager.GetAliveCount() + " / " + enemyManager.GetMaxCount();
	}
}
