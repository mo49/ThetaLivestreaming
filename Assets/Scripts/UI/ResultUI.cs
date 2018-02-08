using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultUI : MonoBehaviour {

	[SerializeField] AudioClip m_winSound;
	[SerializeField] AudioClip m_loseSound;
	[SerializeField] GameObject m_resultUI;

	AudioSource _audio;
	Text _resultText;

	void Awake() {
		_audio = GetComponent<AudioSource>();
		_resultText = m_resultUI.GetComponent<Text>();
	}

	public IEnumerator Win() {
		yield return new WaitForSeconds(2f);
		PlaySound(m_winSound, true);
		DrawText("win");
	}

	public IEnumerator Lose() {
		yield return new WaitForSeconds(2f);
		PlaySound(m_loseSound, false);
		DrawText("lose");
		Time.timeScale = 0.3f;
	}

	void DrawText(string _result) {
		if(_result == "win"){
			_resultText.text = "GAME CLEAR!";
			_resultText.color = Color.yellow;
		}
		else if(_result == "lose") {
			_resultText.text = "GAME OVER...";
			_resultText.color = Color.white;
		}
	}

	void PlaySound(AudioClip _clip, bool _isLoop) {
		BgmManager.Instance.Stop();
		_audio.clip = _clip;
		_audio.loop = _isLoop;
		_audio.Play();
	}
}
