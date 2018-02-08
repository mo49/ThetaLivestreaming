//
//  VR-Studies
//  Created by miuccie miurror on 11/04/2016.
//  Copyright 2016 Yumemi.Inc / miuccie miurror
//

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class EyeControllerTarget : MonoBehaviour, EyeController.IEyeControllerTarget {

	[SerializeField] GameObject m_disasterPrefab;
	[SerializeField] GameObject m_castChargePrefab;
	[SerializeField] AudioClip m_castingSound;
	[SerializeField] AudioClip m_selectedSound;
	[SerializeField] AudioMixerSnapshot m_noCastingShot;
    [SerializeField] AudioMixerSnapshot m_castingShot;

	DisasterManager disasterManager;
	AudioSource m_audio;
	EnemyController m_enemyController;
	SwitchUI m_switchUI;
	
	void Awake() {
		disasterManager = DisasterManager.Instance;
		m_audio = GetComponent<AudioSource> ();
		m_enemyController = GameObject.Find("Enemy").GetComponent<EnemyController>();
		m_switchUI = transform.parent.Find("SwitchCanvas").GetComponent<SwitchUI>();

		m_switchUI.SetCastTime(Mathf.Floor(m_castingSound.length).ToString());

		Hover(false);
	}

	public void OnEyeContollerHit( bool isOn ) {
		// 視線マーカーがヒットしたら
		Hover(isOn);
	}

	public void OnEyeContollerClick() {
		// 視線マーカーでクリック
		m_audio.PlayOneShot(m_selectedSound);

		// 詠唱開始
		disasterManager.SetIsCasting(true);
		m_audio.PlayOneShot(m_castingSound);
		// m_castingShot.TransitionTo(.5f);
		BgmManager.Instance.CurrentAudioSource.volume = 0.05f;

		var chargeInstance = Instantiate(m_castChargePrefab, transform.position, Quaternion.identity);
		chargeInstance.transform.parent = transform;
		Invoke ("Explosion", m_castingSound.length - 2f);
	}

	public void OnTriggerClick(bool isClick) {
		
	}

	void Hover(bool isOn, float color=0.7f) {
		gameObject.GetComponent<Renderer> ().material.color
				= isOn 
				? new Color (1f, 1f, 1f)
				: new Color (color, color, color);
	}

	void Explosion() {
		Instantiate (m_disasterPrefab, Vector3.zero, Quaternion.identity);
		m_enemyController.DestroyAllAtField();

		Invoke("End", 8f);
	}

	void End() {
		disasterManager.SetIsCasting(false);
		// m_noCastingShot.TransitionTo(.5f);
		BgmManager.Instance.CurrentAudioSource.volume = 0.3f;
		Destroy(transform.parent.gameObject);
	}

}
