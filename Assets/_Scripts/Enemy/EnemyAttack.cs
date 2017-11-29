using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {

	public float timeBetweenAttacks = 0.5f;
	public int attackDamage = 10;

	GameObject player;
	PlayerHealth playerHealth;
	bool playerInRangeOfAttack;
	float attackTimer;

	void Start()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = player.GetComponent<PlayerHealth> ();
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject == player) 
		{
			playerInRangeOfAttack = true;
		}
	}

	void OnTriggerExit (Collider other)
	{
		if (other.gameObject == player) 
		{
			playerInRangeOfAttack = false;
		}
	}

	void Update() 
	{
		attackTimer = attackTimer + Time.deltaTime;

		if ((attackTimer > timeBetweenAttacks) && (playerInRangeOfAttack)) {
			Attack ();
		}
	}

	void Attack()
	{
		attackTimer = 0.0f;

		if (playerHealth.currentHealth > 0) 
		{
			playerHealth.TakeDamage (attackDamage);
		}
	}

}
