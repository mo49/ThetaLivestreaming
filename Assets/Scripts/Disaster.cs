using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disaster : MonoBehaviour {

	[SerializeField] AudioClip[] audioClips;

	AudioSource _audio;

	void Start () {
		_audio = GetComponent<AudioSource>();

		foreach (var clip in audioClips) {
			_audio.PlayOneShot(clip);
		}
	}
	
}
