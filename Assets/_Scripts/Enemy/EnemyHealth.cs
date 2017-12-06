using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

	private GameUIController gameUIController;

	public int startingHealth = 10;
	public int currentHealth;
	public int scoreValue = 10;

	public bool isDead;

	void Awake()
	{
		GameObject gameUIControllerObject = GameObject.FindGameObjectWithTag ("GameUIController");
		if (gameUIControllerObject != null) {
			gameUIController = gameUIControllerObject.GetComponent<GameUIController> ();
		} else {
			Debug.Log ("Cannot find GameUIController script!");
		}
	}

	void Start()
	{
		currentHealth = startingHealth;
	}

	public void TakeDamage (int damage) 
	{
		if (isDead == false) 
		{
			currentHealth -= damage;
			if (currentHealth <= 0) 
			{
				Death ();
			}
		}
	}

	void Death() 
	{
		isDead = true;
		gameUIController.SetPlayerProgress (PlayerData.progress + scoreValue);
		Destroy (this.gameObject);
	}
}
