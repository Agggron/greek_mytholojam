using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParthenonLevelController : MonoBehaviour {

	private GameController gameController;
	private GameObject chosenPlayer;

	public Transform playerSpawnPoint;
	public GameObject titan;
	public Transform titanSpawnPoint;

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
		SpawnTitan ();
	}

	void SpawnTitan ()
	{
		if (gameController.playerIsDead == false) 
		{
			Instantiate (titan, titanSpawnPoint.position, titanSpawnPoint.rotation);
		}
	}
}
