//
//  VR-Studies
//  Created by miuccie miurror on 11/04/2016.
//  Copyright 2016 Yumemi.Inc / miuccie miurror
//

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class StartButton : MonoBehaviour, EyeController.IEyeControllerTarget {
	
	[SerializeField] AudioClip m_selectedSound;
	[SerializeField] GameObject[] m_hiddenItems;
	[SerializeField] EnemyController enemyController;
	[SerializeField] RealPlayerController realPlayerController;
	[SerializeField] GameObject m_intro;

	AudioSource m_audio;
	Slider m_slider;
	Image m_indicator;
	
	void Awake() {
		m_audio = GetComponent<AudioSource> ();
		m_slider = GetComponent<Slider>();
		m_indicator = GameObject.Find("Indicator").GetComponent<Image>();

		Hover(false);
	}

	void Start() {
		BgmManager.Instance.TargetVolume = 0.5f;
		BgmManager.Instance.Play("Opening");
	}

	void Update() {
		m_slider.value = m_indicator.fillAmount;
	}

	public void OnEyeContollerHit( bool isOn ) {
		// 視線マーカーがヒットしたら
		Hover(isOn);
	}

	public void OnEyeContollerClick() {
		// 視線マーカーでクリック
		// 消す
		foreach (Transform childTrans in transform) {
			childTrans.gameObject.SetActive(false);
		}
		realPlayerController.HideGuide();
		m_intro.SetActive(false);

		// 出す
		m_audio.PlayOneShot(m_selectedSound);
		BgmManager.Instance.TargetVolume = 0.3f;
		BgmManager.Instance.Play("Battle01");
		enemyController.GameStart();
		foreach (var item in m_hiddenItems) {
			item.SetActive(true);
		}

		Invoke("End", 1f);
	}

	public void OnTriggerClick(bool isClick) {
		
	}

	void Hover(bool isOn, float color=0.7f) {
		gameObject.GetComponent<Renderer> ().material.color
				= isOn 
				? new Color (1f, 1f, 1f)
				: new Color (color, color, color);
	}

	void End() {
		Destroy(gameObject);
	}

}
