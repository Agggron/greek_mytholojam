using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour {

	public bool isAttacking;
	public int swordAttackDamage;

	void Start()
	{
		swordAttackDamage = transform.parent.GetComponent<PlayerAttack> ().basicAttackDamage;
	}

	void OnTriggerStay(Collider other) 
	{
		if (isAttacking) 
		{
			if (other.gameObject.CompareTag ("Enemy")) 
			{
				EnemyHealth enemyHealth = other.gameObject.GetComponent<EnemyHealth>();
				enemyHealth.TakeDamage (swordAttackDamage);
			}
		}
	}
}
