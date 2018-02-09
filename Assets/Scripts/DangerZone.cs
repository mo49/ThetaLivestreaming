using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class DangerZone : MonoBehaviour {
	[SerializeField] GameObject _dangerUI;
	[SerializeField] float _angularFrequency = 5f;
	static readonly float deltaTime = 0.0333f;
	Text _dangerText;
	bool isActive = false;

	void Start() {
		_dangerText = _dangerUI.GetComponent<Text>();
		Frash();
	}

	void OnTriggerEnter(Collider other) {
		if(TagUtility.getParentTagName(other.gameObject) == "Enemy" && !isActive) {
			isActive = true;
			_dangerUI.SetActive(true);
		}
	}

	public void Hide() {
		_dangerUI.SetActive(false);

		Invoke("End", 5f);
	}

	void Frash() {
		float time = 0f;

		Observable.Interval(TimeSpan.FromSeconds(deltaTime)).Subscribe(_ => {
			time += _angularFrequency * deltaTime;
			var color = _dangerText.color;
			color.a = Mathf.Sin(time) * 0.5f + 0.5f;
			_dangerText.color = color;
		}).AddTo(this);
	}

	void End() {
		isActive = false;
	}

}
