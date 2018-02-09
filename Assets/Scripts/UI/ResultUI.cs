using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ResultUI : MonoBehaviour {

	[SerializeField] AudioClip m_winSound;
	[SerializeField] AudioClip m_loseSound;
	[SerializeField] GameObject m_resultUI;
	[SerializeField] GameObject m_winTextConfetti;
	[SerializeField] GameObject m_winConfettiShapes;
	[SerializeField] GameObject m_winConfettiStarsMoons;
	[SerializeField] int m_aroundConfettiCount = 10;
	[SerializeField] float confettiRadius = 10f;

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
		StartCoroutine("Confetti");
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

	IEnumerator Confetti() {
		yield return new WaitForSeconds(1f);
		Instantiate(m_winTextConfetti, m_resultUI.transform.position, Quaternion.identity);
		yield return new WaitForSeconds(0.5f);
		for (int i = 0; i < m_aroundConfettiCount; i++) {
			float rad = Random.Range(0f,360f);
			Vector3 targetPos = new Vector3(
				Mathf.Sin(rad) * confettiRadius,
				0f,
				Mathf.Cos(rad) * confettiRadius
			);
			if(i%2==0) {
				Instantiate(m_winConfettiShapes, targetPos, m_winConfettiShapes.transform.rotation);
			} else {
				Instantiate(m_winConfettiStarsMoons, targetPos, m_winConfettiShapes.transform.rotation);
			}
			yield return new WaitForSeconds(Random.Range(0f,1f));
		}
	}
}
