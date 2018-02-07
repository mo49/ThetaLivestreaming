//
//  VR-Studies
//  Created by miuccie miurror on 11/04/2016.
//  Copyright 2016 Yumemi.Inc / miuccie miurror
//

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EyeControllerTarget : MonoBehaviour, EyeController.IEyeControllerTarget {

	[SerializeField] AudioClip m_castingSound;
	[SerializeField] GameObject m_disasterPrefab;

	AudioSource m_audio;
	EnemyController m_enemyController;
	
	void Awake() {
		m_audio = GetComponent<AudioSource> ();
		m_enemyController = GameObject.Find("Enemy").GetComponent<EnemyController>();

		Hover(false);
	}

	public void OnEyeContollerHit( bool isOn ) {
		// 視線マーカーがヒットしたら
		Hover(isOn);
	}

	public void OnEyeContollerClick() {
		// 視線マーカーでクリック
		m_audio.PlayOneShot(m_castingSound);
		Debug.Log ("音源の時間：" + m_castingSound.length);
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

		Invoke("End", 2f);
	}

	void End() {
		Destroy(transform.parent.gameObject);
	}

}
