using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EnemyEyeControllerTarget : MonoBehaviour, EyeController.IEyeControllerTarget {
	
	Enemy _enemy;
	
	void Awake() {
		_enemy = GetComponent<Enemy> ();
	}
		
	public void OnEyeContollerClick() {
		// 視線マーカーでクリック
		// die
		_enemy.StartCoroutine("Die", false);
	}

	public void OnTriggerClick(bool isClick) {
		
	}

	public void OnEyeContollerHit(bool isOn){
		
	}

}
