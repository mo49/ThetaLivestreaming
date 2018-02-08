using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeguminController : MonoBehaviour {

	Animator _animator;
	void Start () {
		_animator = GetComponent<Animator>();
	}
	
	public void Idle() {
		_animator.SetTrigger("Idle");
	}
	public void Explosion() {
		_animator.SetTrigger("Explosion");
	}
	public void Casting() {
		_animator.SetTrigger("Casting");
	}
}
