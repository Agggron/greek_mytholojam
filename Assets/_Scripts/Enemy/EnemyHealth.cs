using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour {

	public enum EnemyType {Titanling, StoneGolem, Titan};
	public EnemyType enemyType = EnemyType.StoneGolem;

	private GameUIController gameUIController;
	private Animator anim;
	private NavMeshAgent nav;

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

		anim = GetComponentInChildren<Animator> ();
		nav = GetComponent<NavMeshAgent> ();
	}

	void Start()
	{
		currentHealth = startingHealth;
	}

	void Update ()
	{
		// Move this function over to when take damage works
		if ((currentHealth <= 0) && (!isDead))
		{
			if (enemyType == EnemyType.StoneGolem) 
			{
				nav.isStopped = true;
				isDead = true;
				anim.SetTrigger ("stoneGolemDeath");
				Destroy (gameObject, 5.0f);
			}
		}
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
