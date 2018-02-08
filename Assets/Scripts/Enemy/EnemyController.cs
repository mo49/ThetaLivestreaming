using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	[SerializeField] GameObject devilPrefab;
	[SerializeField] GameObject bossPrefab;
	[SerializeField] Transform goalTrans;
	[SerializeField] Transform enemySpawnAreaTrans;
	[SerializeField] EnemyUI enemyUI;
	[SerializeField] ResultUI resultUI;

	[SerializeField] int maxEnemyNum;

	EnemyManager enemyManager;

	private int currentEnemyIndex = 0;

	public void GameStart() {
		enemyManager = EnemyManager.Instance;

		enemyManager.SetMaxCount(maxEnemyNum);
		enemyManager.SetAliveCount(maxEnemyNum);

		enemyUI.UpdateState();

		StartCreatingEnemy ();
	}

	void Update() {
		if(Input.GetKeyDown(KeyCode.R)) {
			StartCreatingEnemy ();
		}
		if(Input.GetKeyDown(KeyCode.S)) {
			StopCreatingEnemy ();
		}
		if(Input.GetKeyDown(KeyCode.D)) {
			DestroyAllAtField ();
		}
	}

	public void StartCreatingEnemy() {
		StartCoroutine ("CreateEnemy");
	}
	public void StopCreatingEnemy() {
		StopCoroutine ("CreateEnemy");
	}

	IEnumerator CreateEnemy() {
		while(currentEnemyIndex < enemyManager.GetMaxCount()) {
			var enemyInstance = Instantiate (
				devilPrefab,
				transform.position,
				Quaternion.identity
			);
			Transform enemyTrans = enemyInstance.transform;
			enemyTrans.parent = enemySpawnAreaTrans;
			enemyTrans.localPosition = new Vector3 (
				Mathf.Sin(Random.Range(-1f,1f)) * 5f,
				Random.Range(-2f,0.5f),
				Mathf.Sin(Random.Range(-1f,1f)) * 15f
			);
			enemyTrans.LookAt (new Vector3(
				goalTrans.position.x,
				enemyTrans.position.y,
				goalTrans.position.z
			));
			currentEnemyIndex++;
			yield return new WaitForSeconds (Random.Range(0.5f, 3f));
		}
	}

	public void DestroyAllAtField() {
		int enemyCountAtField = enemySpawnAreaTrans.childCount;

		for (int i = 0; i < enemyCountAtField; i++) {
			enemySpawnAreaTrans.GetChild(i).GetComponent<Enemy>().StartCoroutine("Die");
		}
		StopCreatingEnemy();

		enemyManager.SetAliveCount(enemyManager.GetAliveCount() - enemyCountAtField);

		// 終了判定
		if(enemyManager.GetAliveCount() <= 0) {
			resultUI.Win();
			return;
		}
		Invoke ("StartCreatingEnemy", 8f);
	}
}
