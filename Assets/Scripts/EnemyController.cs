using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	[SerializeField] GameObject devilPrefab;
	[SerializeField] GameObject bossPrefab;
	[SerializeField] Transform goalTrans;

	[SerializeField] int maxEnemyNum;

	private int currentEnemyNum = 0;

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
			var enemyInstance = Instantiate (devilPrefab, transform.position, Quaternion.identity);
			enemyInstance.transform.LookAt (goalTrans);
			currentEnemyNum++;
			yield return new WaitForSeconds (1f);
		}
	}

	public void DestroyAllAtField() {
		Invoke ("StartCreatingEnemy", 8f);
	}
}
