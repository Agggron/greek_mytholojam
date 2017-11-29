using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

	private GameController gameController;

	PlayerMovement playerMovement;
	public bool isDead;
	public int currentHealth;


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
	}

	void Start()
	{
		currentHealth = gameController.playerCurrentHealth;
	}
		

	public void TakeDamage (int damage) 
	{
		currentHealth -= damage;

		gameController.SetPlayerHealth (currentHealth);

		gameController.playerIsDamaged = true;

		if ((currentHealth <= 0) && (isDead == false)) 
		{
			PlayerDeath ();
		}
	}

	void PlayerDeath()
	{
		isDead = true;

		playerMovement.enabled = false;
	}
}
