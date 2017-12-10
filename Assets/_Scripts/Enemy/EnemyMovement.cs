using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour {

	private GameObject player;
	private Transform playerLocation;
	private PlayerHealth playerHealth;
	private NavMeshAgent nav;
	private Animator anim;

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
		anim = GetComponentInChildren<Animator> ();
	}

	void Start()
	{
		anim.SetBool ("isRunning", true);
	}

	void Update()
	{
		Debug.Log (nav.isStopped);
		if (!playerHealth.playerIsDead) 
		{
			if (!nav.isStopped) 
			{
				if (anim.GetBool ("isRunning") == false) {
					//anim.SetBool ("isRunning", true);
				}
				// Sets destination of enemy to a (1.25 unit) radius around the player's position
				Vector3 directionFromPlayer = 1.25f * Vector3.Normalize (gameObject.transform.position - playerLocation.position);
				nav.SetDestination (playerLocation.position + directionFromPlayer);
			} 
			else 
			{
				//anim.SetBool ("isRunning", false);
			}
		}
	}
}
