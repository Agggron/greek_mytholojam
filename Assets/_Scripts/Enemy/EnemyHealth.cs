using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

	private GameController gameController;

	public int startingHealth = 10;
	public int currentHealth;
	public int scoreValue = 10;

	bool isDead;

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
		gameController.SetGameProgress (Mathf.RoundToInt(gameController.gameProgressSlider.value + scoreValue));
		Destroy (this.gameObject);
	}
}
