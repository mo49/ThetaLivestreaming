using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	[SerializeField] GameObject spawnEffectPrefab;
	[SerializeField] GameObject dieEffectPrefab;
	private Animator _animator;
	private Rigidbody _rb;

	void Start() {
		_animator = GetComponent<Animator>();
		_rb = GetComponent<Rigidbody>();
	}

	void OnTriggerEnter(Collider other) {
		if(other.tag == "RealPlayer") {
			_rb.velocity = Vector3.zero;

			// attack
		}
	}

	public IEnumerator Die() {
		yield return new WaitForSeconds(Random.Range(0f, 2f));

		_rb.velocity = Vector3.zero;
		_animator.SetTrigger("Death");
		Instantiate(dieEffectPrefab, transform.position, Quaternion.identity);
	}

	void End() {
		Destroy(gameObject);
	}
}
