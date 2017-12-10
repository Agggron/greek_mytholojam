using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderShards : MonoBehaviour {

	public int shardDamage = 10;
	private BoulderMovementDamage boulderMovementDamage;

	void Awake ()
	{
		boulderMovementDamage = GetComponentInParent<BoulderMovementDamage> ();
	}

	void OnTriggerStay(Collider other) 
	{

		if (other.gameObject.CompareTag ("Environment")) 
		{
			Destroy (gameObject);
		}

		if (boulderMovementDamage.boulderUser == BoulderMovementDamage.BoulderUser.Player) 
		{
			if (other.gameObject.CompareTag ("Enemy")) {
				EnemyHealth enemyHealth = other.gameObject.GetComponent<EnemyHealth> ();
				enemyHealth.TakeDamage (shardDamage);
				Destroy (gameObject);
			}
		}

		if (boulderMovementDamage.boulderUser == BoulderMovementDamage.BoulderUser.StoneGolem) 
		{
			if (other.gameObject.CompareTag ("Player")) {
				PlayerHealth playerHealth = other.gameObject.GetComponent<PlayerHealth> ();
				playerHealth.TakeDamage (shardDamage);
				Debug.Log ("dealt damage");
				Destroy (gameObject);
			}
		}
	}
}
