using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiveStreamingSphereController : MonoBehaviour {

	[SerializeField] GameObject m_hitEnemyExplosionPrefab;

	void OnTriggerExit(Collider other) {
		Instantiate(m_hitEnemyExplosionPrefab, other.transform.position, Quaternion.identity);

		Destroy(other.gameObject);
	}
}
