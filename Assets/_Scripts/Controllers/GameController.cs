using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	private SceneController sceneController;
	public GameObject player;
	public Transform spawnPoint;

	public int playerStartingHealth = 100;
	public int playerCurrentHealth;

	public Slider gameProgressSlider;
	public Slider playerHealthSlider;
	public Image playerDamagedImage;
	public bool playerIsDamaged = false;
	public Color playerDamagedColor;
	public float damagedColorFadeSpeed;

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
			Instantiate (player, spawnPoint.position, spawnPoint.rotation);
		}

		playerCurrentHealth = playerStartingHealth;
		playerIsDamaged = false;
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



}
