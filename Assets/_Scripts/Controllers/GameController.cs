using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	private SceneController sceneController;
	public GameObject player;
	public GameObject[] enemies;
	public Transform playerSpawnPoint;
	public Transform[] enemySpawnPoints;

	public int playerStartingHealth = 100;
	public int playerCurrentHealth;

	public Slider gameProgressSlider;
	public Slider playerHealthSlider;
	public Image playerDamagedImage;
	public bool playerIsDamaged = false;
	public Color playerDamagedColor;
	public float damagedColorFadeSpeed;

	public bool playerIsDead;

	void Awake() 
	{
		GameObject sceneControllerObject = GameObject.Find ("SceneController");
		if (sceneControllerObject != null) 
		{
			sceneController = sceneControllerObject.GetComponent<SceneController> ();
			player = sceneController.chosenPlayer;
		}

		if (player != null) 
		{
			Instantiate (player, playerSpawnPoint.position, playerSpawnPoint.rotation);
		}

		playerCurrentHealth = playerStartingHealth;
		playerIsDamaged = false;
	}

	void Start()
	{
		InvokeRepeating ("SpawnEnemy", 1.0f, 3.0f);
	}

	void Update() 
	{
		if (playerIsDamaged) 
		{
			playerDamagedImage.color = playerDamagedColor;
		} 
		else 
		{
			playerDamagedImage.color = Color.Lerp (playerDamagedImage.color, Color.clear, damagedColorFadeSpeed * Time.deltaTime);
		}

		playerIsDamaged = false;
	}

	void SpawnEnemy() 
	{
		if (playerIsDead == false) 
		{
			GameObject enemy = enemies [Mathf.FloorToInt (Random.Range (0.0f, enemies.Length))];
			Transform enemySpawnPoint = enemySpawnPoints [Mathf.FloorToInt (Random.Range (0.0f, enemySpawnPoints.Length))];

			Instantiate (enemy, enemySpawnPoint.position, enemySpawnPoint.rotation);
		}
	}

	public void SetGameProgress(int progress)
	{
		gameProgressSlider.value = progress;
	}

	public void SetPlayerHealth (int health) 
	{
		playerCurrentHealth = health;
		playerHealthSlider.value = health;
	}
}
