using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour {

	[SerializeField] int m_maxHitPoint;
	[SerializeField] Slider m_hpSlider;
	[SerializeField] Image m_hpFillImage;
	ResultUI resultUI;

	HitPointManager hpManager;

	void Start () {
		resultUI = GetComponent<ResultUI>();
		hpManager = HitPointManager.Instance;

		// init
		hpManager.SetHP(m_maxHitPoint);
		m_hpSlider.maxValue = m_maxHitPoint;
		m_hpSlider.value = m_maxHitPoint;
	}
	
	public void UpdateState() {
		int currentHP = hpManager.GetHP();
		m_hpSlider.value = currentHP;

		if((float)currentHP / (float)m_maxHitPoint < 0.3f) {
			m_hpFillImage.color = Color.red;
		}

		if(currentHP <= 0) {
			// lose
			resultUI.Lose();
		}
	}
}
