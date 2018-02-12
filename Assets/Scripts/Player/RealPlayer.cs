using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealPlayer : MonoBehaviour {

	[SerializeField] PlayerUI playerUI;
	[SerializeField] AudioClip[] _maleDamageSounds;
	[SerializeField] AudioClip _maleLoseSound;

	[SerializeField] AudioClip[] _femaleDamageSounds;
	[SerializeField] AudioClip _femaleLoseSound;

	AudioSource _audio;
	GenderManager _genderManager;

	void Start () {
		_audio = GetComponent<AudioSource>();
		_genderManager = GenderManager.Instance;
	}

	void Update() {
		if(Input.GetKeyDown(KeyCode.Alpha1)) {
			_genderManager.SetGender("male");
		}
		if(Input.GetKeyDown(KeyCode.Alpha2)) {
			_genderManager.SetGender("female");
		}
	}

	public void HitDamage() {
		playerUI.UpdateState();
		PlayDamageSound(_genderManager.GetGender());
	}

	void PlayDamageSound(string _gender) {
		int index = (int)Mathf.Floor(Random.Range(0f, 2f));
		switch (_gender){
			case "male":
				_audio.PlayOneShot(_maleDamageSounds[index]);
				break;
			case "female":
				_audio.PlayOneShot(_femaleDamageSounds[index]);
				break;
		}
	}
	

}
