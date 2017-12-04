using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AcropolisLevelController : MonoBehaviour {

	private GameController gameController;
	private GameObject chosenPlayer;

	public Transform playerSpawnPoint;
	public GameObject[] enemies;
	public Transform[] enemySpawnPoints;

	void Awake() 
	{
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
		if (gameControllerObject != null) 
		{
			gameController = gameControllerObject.GetComponent<GameController> ();
			chosenPlayer = gameController.chosenPlayer;
		} 
		else 
		{
			Debug.Log ("Cannot find GameController script!");
		}

		if (chosenPlayer != null) 
		{
			Instantiate (chosenPlayer, playerSpawnPoint.position, playerSpawnPoint.rotation);
		}
	}

	void Start()
	{
		InvokeRepeating ("SpawnEnemy", 1.0f, 3.0f);
	}

	void SpawnEnemy() 
	{
		if (gameController.playerIsDead == false) 
		{
			GameObject enemy = enemies [Mathf.FloorToInt (Random.Range (0.0f, enemies.Length))];
			Transform enemySpawnPoint = enemySpawnPoints [Mathf.FloorToInt (Random.Range (0.0f, enemySpawnPoints.Length))];

			Instantiate (enemy, enemySpawnPoint.position, enemySpawnPoint.rotation);
		}
	}
}
