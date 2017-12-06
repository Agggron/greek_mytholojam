using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFootsteps : MonoBehaviour {

	[FMODUnity.EventRef]
	public string inputSound;
	public bool playerIsMoving;
	public float walkingSpeed;

	private PlayerHealth playerHealth;

	void Awake()
	{
		playerHealth = GetComponent<PlayerHealth> ();
	}

	void Start ()
	{
		InvokeRepeating ("CallFootsteps", 0, walkingSpeed);
	}
		
	void CallFootsteps ()
	{
		if ((!playerHealth.playerIsDead) && (playerIsMoving))
		{
			FMODUnity.RuntimeManager.PlayOneShot (inputSound);
		}
	}

	void OnDisable ()
	{
		playerIsMoving = false;
	}
}