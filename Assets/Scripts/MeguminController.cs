using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeguminController : MonoBehaviour {

	[SerializeField] GameObject _castingEffect;
	[SerializeField] GameObject _shieldEffect;
	Animator _animator;

	GameObject _castingEffectInstance;
	GameObject _shieldEffectInstance;
	void Start () {
		_animator = GetComponent<Animator>();
	}
	
	public void Idle() {
		Destroy(_shieldEffectInstance);
		
		_animator.SetTrigger("Idle");
	}
	public void Explosion() {
		Destroy(_castingEffectInstance);
		_animator.SetTrigger("Explosion");

		_shieldEffectInstance = Instantiate(_shieldEffect, transform.position, Quaternion.identity);
	}
	public void Casting() {
		_animator.SetTrigger("Casting");
		_castingEffectInstance = Instantiate(_castingEffect, transform.position, Quaternion.identity);
	}
	public void Win() {
		Destroy(_shieldEffectInstance);

		_animator.SetTrigger ("Win");
		transform.LookAt (GameObject.FindGameObjectWithTag ("MainCamera").transform);
	}
}
