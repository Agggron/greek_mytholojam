using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

	private GameUIController gameUIController;
	private PlayerMovement playerMovement;
	private PlayerAttack playerAttack;

	public GameObject PDATA_player;
	public int PDATA_health;
	public int PDATA_progress;

	public bool playerIsDamaged;
	public bool playerIsDead;

	void Awake () 
	{
		GameObject gameUIControllerObject = GameObject.FindGameObjectWithTag ("GameUIController");
		if (gameUIControllerObject != null) {
			gameUIController = gameUIControllerObject.GetComponent<GameUIController> ();
		} else {
			Debug.Log ("Cannot find GameUIController script!");
		}

		playerMovement = GetComponent<PlayerMovement> ();
		playerAttack = GetComponent<PlayerAttack> ();
	}

	void Start ()
	{
		PDATA_player = PlayerData.player;
		PDATA_health = PlayerData.health;
		PDATA_progress = PlayerData.progress;

		playerIsDamaged = false;
		playerIsDead = false;


	}

	void Update ()
	{
		PDATA_player = PlayerData.player;
		PDATA_health = PlayerData.health;
		PDATA_progress = PlayerData.progress;
	}

	public void TakeDamage (int damage) 
	{
		int newHealth = PlayerData.health - damage;

		PlayerData.health = newHealth;
		gameUIController.SetPlayerHealth (newHealth);

		playerIsDamaged = true;

		if ((PlayerData.health <= 0) && (!playerIsDead)) 
		{
			PlayerDeath ();
		}
	}

	void PlayerDeath()
	{
		playerIsDead = true;
		playerMovement.enabled = false;
		playerAttack.enabled = false;
	}
}
