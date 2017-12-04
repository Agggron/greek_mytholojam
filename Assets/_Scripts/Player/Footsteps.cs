using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour {

	[FMODUnity.EventRef]
	public string inputsound;
	public bool playerismoving;
	public float walkingspeed;

	private GameController gameController;
	private PlayerHealth playerHealth;

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

		playerHealth = GetComponent<PlayerHealth> ();
	}
		

	void CallFootsteps ()
	{
		if ((gameController.playerIsDead == false) && (playerismoving == true))
		{
			FMODUnity.RuntimeManager.PlayOneShot (inputsound);
		}
	}

	void Start ()
	{
		
		InvokeRepeating ("CallFootsteps", 0, walkingspeed);
	}

	void OnDisable ()
	{
		playerismoving = false;
	}
}