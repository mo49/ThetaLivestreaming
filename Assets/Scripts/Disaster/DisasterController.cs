using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisasterController : MonoBehaviour {

	[SerializeField] GameObject[] switchPrefabs;
	[SerializeField] Transform switchesTrans;

	float _radius = 10f;
	
	void Start () {
		foreach (var switchPrefab in switchPrefabs) {
			for (int i = 0; i < 2; i++) {
				var switchInstance = Instantiate(switchPrefab, Random.insideUnitSphere * _radius, Quaternion.identity);
				switchInstance.transform.parent = switchesTrans;
			}
		}
	}

}
