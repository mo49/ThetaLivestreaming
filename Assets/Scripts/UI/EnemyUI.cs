using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyUI : MonoBehaviour {

	// [SerializeField] Text m_enemyUI;
	[SerializeField] GameObject m_EnemyUI;

	EnemyManager enemyManager;

	void Start () {
		enemyManager = EnemyManager.Instance;
	}

	public void UpdateState() {
		// m_enemyUI.text = "敵：" + enemyManager.GetAliveCount() + " / " + enemyManager.GetMaxCount();
		m_EnemyUI.GetComponent<TMPro.TextMeshPro>().text = "敵：" + enemyManager.GetAliveCount() + " / " + enemyManager.GetMaxCount();
	}
}
