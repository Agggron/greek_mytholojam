using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderShards : MonoBehaviour {

	public int shardDamage = 10;

	void OnTriggerStay(Collider other) 
	{
		if (other.gameObject.CompareTag ("Enemy")) 
		{
			EnemyHealth enemyHealth = other.gameObject.GetComponent<EnemyHealth>();
			enemyHealth.TakeDamage (shardDamage);
			Destroy (gameObject);
		}

		if (other.gameObject.CompareTag ("Environment")) 
		{
			Destroy (gameObject);
		}
	}
}
