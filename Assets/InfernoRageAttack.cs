using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfernoRageAttack : MonoBehaviour {

	public int infernoRageDamage = 10;

	void OnTriggerStay(Collider other) 
	{
		if (other.gameObject.CompareTag ("Enemy")) {
			EnemyHealth enemyHealth = other.gameObject.GetComponent<EnemyHealth> ();
			enemyHealth.TakeDamage (infernoRageDamage);
		}
	}
}
