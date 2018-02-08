using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultUI : MonoBehaviour {

	[SerializeField] AudioClip _winSound;
	[SerializeField] AudioClip _loseSound;

	AudioSource _audio;

	void Awake() {
		_audio = GetComponent<AudioSource>();
	}

	public void Win() {
		BgmManager.Instance.Stop();
		_audio.clip = _winSound;
		_audio.loop = true;
		_audio.Play();
	}

	public void Lose() {
		BgmManager.Instance.Stop();
		_audio.clip = _loseSound;
		_audio.loop = false;
		_audio.Play();
	}
}
