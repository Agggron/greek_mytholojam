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
	public GameObject titanling;
	public GameObject stoneGolem;
	public GameObject boss;
	public Transform[] titanlingSpawnPoints;
	public Transform[] stoneGolemSpawnPoints;
	public Transform bossSpawnPoint;
	public float titanlingSpawnFrequency = 1.0f;
	public float stoneGolemSpawnFrequency = 5.0f;

	public bool bossBattleStarted;

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

		bossBattleStarted = false;

		StartCoroutine (ControlGame ());
		InvokeRepeating ("SpawnTitanling", 1.0f, titanlingSpawnFrequency);
		InvokeRepeating ("SpawnStoneGolem", 5.0f, stoneGolemSpawnFrequency);
	}
		
	void SpawnTitanling () 
	{
		if (playerHealth.playerIsDead == false)
		{
			Transform spawnPoint = titanlingSpawnPoints [Mathf.FloorToInt (Random.Range (0.0f, titanlingSpawnPoints.Length))];
			Instantiate (titanling, spawnPoint.position, spawnPoint.rotation);
		}
	}

	void SpawnStoneGolem () 
	{
		if (playerHealth.playerIsDead == false)
		{
			Transform spawnPoint = stoneGolemSpawnPoints [Mathf.FloorToInt (Random.Range (0.0f, stoneGolemSpawnPoints.Length))];
			Instantiate (stoneGolem, spawnPoint.position, spawnPoint.rotation);
		}
	}

	void BossBattle () 
	{
		Instantiate (boss, bossSpawnPoint.position, bossSpawnPoint.rotation);
	}


	IEnumerator ControlGame ()
	{
		while (true) 
		{
			if (Input.GetKeyDown (KeyCode.Escape)) 
			{
				sceneController.menuSceneOption = SceneController.MenuSceneOptions.Default;
				sceneController.StartMenuScene ();
			}

			if (PlayerData.health <= 0) 
			{
				yield return new WaitForSeconds (10.0f);
				sceneController.menuSceneOption = SceneController.MenuSceneOptions.Lose;
				sceneController.StartMenuScene ();
			
			}

			if ((!bossBattleStarted) && (PlayerData.progress >= 100))
			{
				bossBattleStarted = true;
				StartCoroutine ("BossBattle");
			}

			if (PlayerData.progress >= 1000) 
			{
				playerHealth.playerInvulnerable = PlayerHealth.PlayerInvulnerable.Yes;
				yield return new WaitForSeconds (10.0f);
				sceneController.menuSceneOption = SceneController.MenuSceneOptions.Win;
				sceneController.StartMenuScene ();
			}
			yield return null;
		}
	}

}
