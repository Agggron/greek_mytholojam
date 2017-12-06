using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour {

	private GameObject player;
	private Transform playerLocation;
	private PlayerHealth playerHealth;
	private NavMeshAgent nav;

	void Awake()
	{
		GameObject playerObject = GameObject.FindGameObjectWithTag ("Player");
		if (playerObject != null) {
			player = playerObject;
			playerLocation = player.transform;
			playerHealth = playerObject.GetComponent<PlayerHealth> ();
		} else {
			Debug.Log ("Cannot find Player and/or its scripts!");
		}

		nav = GetComponent<NavMeshAgent> ();
	}

	void Start()
	{
	}

	void Update()
	{
		if (!playerHealth.playerIsDead) 
		{
			// Sets destination of enemy to a (1.25 unit) radius around the player's position
			Vector3 directionFromPlayer = 1.25f * Vector3.Normalize (gameObject.transform.position - playerLocation.position);
			nav.SetDestination (playerLocation.position + directionFromPlayer);
		}
	}
}
