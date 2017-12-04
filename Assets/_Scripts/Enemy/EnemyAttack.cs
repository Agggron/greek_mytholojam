using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {

	public float timeBetweenAttacks = 0.5f;
	public int attackDamage = 10;

	private GameController gameController;
	private GameObject player;
	private PlayerHealth playerHealth;

	bool playerInRangeOfAttack;
	float attackTimer;

	void Awake()
	{
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
		if (gameControllerObject != null) 
		{
			gameController = gameControllerObject.GetComponent<GameController> ();
		} 
		else 
		{
			Debug.Log ("Cannot find GameController script!");
		}
	}

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

		if (gameController.playerHealth > 0) 
		{
			playerHealth.TakeDamage (attackDamage);
		}
	}

}
