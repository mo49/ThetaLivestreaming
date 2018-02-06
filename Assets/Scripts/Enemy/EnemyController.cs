using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	[SerializeField] GameObject devilPrefab;
	[SerializeField] GameObject bossPrefab;
	[SerializeField] Transform goalTrans;
	[SerializeField] Transform enemySpawnAreaTrans;

	[SerializeField] int maxEnemyNum;

	EnemyManager enemyManager;

	private int currentEnemyIndex = 0;

	void Start() {
		enemyManager = EnemyManager.Instance;

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
		while(currentEnemyIndex < maxEnemyNum) {
			var enemyInstance = Instantiate (
				devilPrefab,
				transform.position,
				Quaternion.identity
			);
			Transform enemyTrans = enemyInstance.transform;
			enemyTrans.parent = enemySpawnAreaTrans;
			enemyTrans.localPosition = new Vector3 (
				Mathf.Sin(Random.Range(-1f,1f)) * 5f,
				0f,
				Mathf.Sin(Random.Range(-1f,1f)) * 15f
			);
			enemyTrans.LookAt (goalTrans);
			currentEnemyIndex++;
			yield return new WaitForSeconds (Random.Range(0.5f, 3f));
		}
	}

	public void DestroyAllAtField() {
		for (int i = 0; i < enemySpawnAreaTrans.childCount; i++) {
			enemySpawnAreaTrans.GetChild(i).GetComponent<Enemy>().StartCoroutine("Die");
		}
		StopCreatingEnemy();

		enemyManager.SetAliveCount(maxEnemyNum - currentEnemyIndex);

		// 終了判定
		Debug.Log(string.Format("敵：{0}/{1}", enemyManager.GetAliveCount(), maxEnemyNum));
		if(enemyManager.GetAliveCount() <= 0) {
			Debug.Log("勝ち!!");
			return;
		}
		Invoke ("StartCreatingEnemy", 8f);
	}
}
