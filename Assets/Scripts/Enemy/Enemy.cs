using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	[SerializeField] GameObject attackEffectPrefab;
	[SerializeField] GameObject dieEffectPrefab;
	[SerializeField] int attackPower = 5;
	private Animator _animator;
	private Rigidbody _rb;

	private HitPointManager hpManager;

	private PlayerUI playerUI;
	private EnemyUI enemyUI;

	void Start() {
		_animator = GetComponent<Animator>();
		_rb = GetComponent<Rigidbody>();

		hpManager = HitPointManager.Instance;

		playerUI = GameObject.Find("GameUI").GetComponent<PlayerUI>();
		enemyUI = GameObject.Find("GameUI").GetComponent<EnemyUI>();

		Invoke("StartMoving", 2f);
	}

	void StartMoving() {
		_rb.AddForce (
			transform.forward * Random.Range(0.1f, 1f),
			ForceMode.VelocityChange
		);
	}

	void OnTriggerEnter(Collider other) {
		if(other.tag == "RealPlayer") {
			_rb.velocity = Vector3.zero;

			// 攻撃開始
			InvokeRepeating("Attack", 1f, 5f);
		}
	}

	public IEnumerator Die() {
		yield return new WaitForSeconds(Random.Range(0f, 2f));

		CancelInvoke("Attack");
		_rb.velocity = Vector3.zero;
		_animator.SetTrigger("Death");
		Instantiate(dieEffectPrefab, transform.position, Quaternion.identity);
	}

	void Attack() {
		string attackParam = Random.Range(-1f,1f) > 0 ? "Attack1" : "Attack2";
		_animator.SetTrigger(attackParam);
	}

	void AttackHit() {
		// 攻撃が当たった瞬間
		hpManager.SetHP(hpManager.GetHP() - attackPower);
		Instantiate(attackEffectPrefab, transform.position, Quaternion.identity);
		playerUI.UpdateState();
	}

	void End() {
		// 死亡アニメーションが終了した瞬間
		enemyUI.UpdateState();
		Destroy(gameObject);
	}
}
