using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

	private GameController gameController;
	private PlayerMovement playerMovement;
	private PlayerAttack playerAttack;

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
			
		playerMovement = GetComponent<PlayerMovement> ();
		playerAttack = GetComponent<PlayerAttack> ();
	}

	public void TakeDamage (int damage) 
	{
		int newHealth = gameController.playerHealth - damage;
		gameController.SetPlayerHealth (newHealth);

		gameController.playerIsDamaged = true;

		if ((gameController.playerHealth <= 0) && (gameController.playerIsDead == false)) 
		{
			PlayerDeath ();
		}
	}

	void PlayerDeath()
	{
		gameController.playerIsDead = true;
		playerMovement.enabled = false;
		playerAttack.enabled = false;
	}
}
