using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour {

	private GameController gameController;
	private GameObject player;
	private Transform playerLocation;
	private PlayerHealth playerHealth;
	private NavMeshAgent nav;

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
		playerLocation = player.transform;
		playerHealth = player.GetComponent<PlayerHealth> ();
		nav = GetComponent<NavMeshAgent> ();
	}

	void Update()
	{
		if (gameController.playerIsDead == false) 
		{
			// Sets destination of enemy to a (1.25 unit) radius around the player's position
			Vector3 directionFromPlayer = 1.25f * Vector3.Normalize (gameObject.transform.position - playerLocation.position);
			nav.SetDestination (playerLocation.position + directionFromPlayer);
		}
	}
}
