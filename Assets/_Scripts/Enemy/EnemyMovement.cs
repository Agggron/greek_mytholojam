using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour {

	Transform player;
	NavMeshAgent nav;

	void Start()
	{
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		nav = GetComponent<NavMeshAgent> ();
	}

	void Update()
	{
		// Sets destination of enemy to a (1.25 unit) radius around the player's position
		Vector3 directionFromPlayer = 1.25f * Vector3.Normalize(gameObject.transform.position - player.position);
		nav.SetDestination (player.position + directionFromPlayer);
	}
}
