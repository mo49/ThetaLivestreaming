using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

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
		TextAnimation();
		Confetti();
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


	// debug
	void Update() {
		if(Input.GetKeyDown(KeyCode.Space)){
			TextAnimation();
		}
	}

	void TextAnimation() {
		m_resultUI.transform.localScale = new Vector3(1f,0f,1f);
		m_resultUI.transform
			.DOScale(new Vector3(1f,1f), 1.5f)
			.SetEase(Ease.OutElastic);
	}

	void Confetti() {

	}
}
