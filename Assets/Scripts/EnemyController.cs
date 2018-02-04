using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	[SerializeField] GameObject devilPrefab;
	[SerializeField] GameObject bossPrefab;
	[SerializeField] Transform goalTrans;
	[SerializeField] GameObject enemySpawnArea;

	[SerializeField] int maxEnemyNum;

	private int currentEnemyNum = 0;

	void Start() {
		StartCreatingEnemy ();
	}

	void Update() {

		if(Input.GetKeyDown(KeyCode.R)) {
			StartCreatingEnemy ();
		}
		if(Input.GetKeyDown(KeyCode.S)) {
			StopCreatingEnemy ();
		}
	}

	public void StartCreatingEnemy() {
		StartCoroutine ("CreateEnemy");
	}
	public void StopCreatingEnemy() {
		StopCoroutine ("CreateEnemy");
	}

	IEnumerator CreateEnemy() {
		while(currentEnemyNum < maxEnemyNum) {
			var enemyInstance = Instantiate (
				devilPrefab,
				transform.position,
				Quaternion.identity
			);
			Transform enemyTrans = enemyInstance.transform;
			enemyTrans.parent = enemySpawnArea.transform;
			enemyTrans.localPosition = new Vector3 (
				Mathf.Sin(Random.Range(-1f,1f)) * 5f,
				0f,
				Mathf.Sin(Random.Range(-1f,1f)) * 10f
			);
			//enemyInstance.transform.position.y = 0f;
			enemyInstance.transform.LookAt (goalTrans);
			enemyInstance.GetComponent<Rigidbody> ().AddForce (enemyInstance.transform.forward * 1, ForceMode.VelocityChange);
			currentEnemyNum++;
			yield return new WaitForSeconds (1f);
		}
	}

	public void DestroyAllAtField() {
		Invoke ("StartCreatingEnemy", 8f);
	}
}
