using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour {

	[FMODUnity.EventRef]
	public string inputsound;
	public bool playerismoving;
	public float walkingspeed;

	PlayerHealth playerHealth;

	void Awake()
	{
		playerHealth = GetComponent<PlayerHealth> ();
	}
	/*void update ()
	{
		if (Input.GetAxis ("Vertical") >= 0.01f || Input.GetAxis ("Horizontal") >= 0.01f || Input.GetAxis ("Vertical") <= 0.01f || Input.GetAxis ("Horizontal") <= 0.01f)
		{
			//Debug.Log ("Player is moving");
			playerismoving = true;
		} 
		else if (Input.GetAxis ("Vertical") == 0 || Input.GetAxis ("Horizontal") == 0)
		{
			//Debug.Log ("Player is not moving");
			playerismoving = false;
		}
	}*/

	void CallFootsteps ()
	{
		if ((playerHealth.isDead == false) && (playerismoving == true))
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