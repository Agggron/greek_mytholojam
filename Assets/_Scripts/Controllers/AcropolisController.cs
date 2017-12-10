using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AcropolisController : MonoBehaviour {

	public SceneController sceneController;
	public GameUIController gameUIController;
	public PlayerHealth playerHealth;

	public GameObject PDATA_player;
	public int PDATA_health;
	public int PDATA_progress;

	public int playerStartHealth = 100;
	public int playerStartProgress = 0;

	public Transform playerSpawnPoint;
	public GameObject[] enemies;
	public Transform[] enemySpawnPoints;
	public float spawnFrequency = 10.0f;

	void Awake() 
	{
		GameObject sceneControllerObject = GameObject.FindGameObjectWithTag ("SceneController");
		if (sceneControllerObject != null) {
			sceneController = sceneControllerObject.GetComponent<SceneController> ();
		} else {
			Debug.Log ("Cannot find SceneController script!");
		}

		GameObject gameUIControllerObject = GameObject.FindGameObjectWithTag ("GameUIController");
		if (gameUIControllerObject != null) {
			gameUIController = gameUIControllerObject.GetComponent<GameUIController> ();
		} else {
			Debug.Log ("Cannot find GameUIController script!");
		}

		if (PlayerData.player != null) 
		{
			Instantiate (PlayerData.player, playerSpawnPoint.position, playerSpawnPoint.rotation);
		}

		GameObject playerObject = GameObject.FindGameObjectWithTag ("Player");
		if (playerObject != null) {
			PlayerData.player = playerObject;
			playerHealth = playerObject.GetComponent<PlayerHealth> ();
		} else {
			Debug.Log ("Cannot find Player and/or its scripts!");
		}
	}

	void Start()
	{
		gameUIController.SetPlayerHealth (playerStartHealth);
		gameUIController.SetPlayerProgress (playerStartProgress);

		PDATA_player = PlayerData.player;
		PDATA_health = PlayerData.health;
		PDATA_progress = PlayerData.progress;

		InvokeRepeating ("SpawnEnemy", 1.0f, spawnFrequency);
	}

	void SpawnEnemy () 
	{
		if (playerHealth.playerIsDead == false)
		{
			if ((enemies.Length != 0) && (enemySpawnPoints.Length != 0)) 
			{
				GameObject enemy = enemies [Mathf.FloorToInt (Random.Range (0.0f, enemies.Length))];
				Transform enemySpawnPoint = enemySpawnPoints [Mathf.FloorToInt (Random.Range (0.0f, enemySpawnPoints.Length))];

				Instantiate (enemy, enemySpawnPoint.position, enemySpawnPoint.rotation);
			}
		}
	}

	void Update()
	{
		PDATA_player = PlayerData.player;
		PDATA_health = PlayerData.health;
		PDATA_progress = PlayerData.progress;

		if (Input.GetKeyDown (KeyCode.Escape)) 
		{
			sceneController.menuSceneOption = SceneController.MenuSceneOptions.Default;
			sceneController.StartMenuScene ();
		}

		if (PlayerData.health <= 0) 
		{
			sceneController.menuSceneOption = SceneController.MenuSceneOptions.Lose;
			sceneController.StartMenuScene ();
		}

		if (PlayerData.progress >= 100) 
		{
			sceneController.menuSceneOption = SceneController.MenuSceneOptions.Win;
			sceneController.StartMenuScene ();
		}
	}

}
