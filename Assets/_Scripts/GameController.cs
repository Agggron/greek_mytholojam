using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	private SceneController sceneController;
	public GameObject player;
	public Transform spawnPoint;

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
	}



}
