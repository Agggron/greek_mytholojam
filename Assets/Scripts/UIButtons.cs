using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtons : MonoBehaviour {

	public GameObject playGameButton;
	public GameObject choosePlayersButtons;
	public SceneController sceneController;

	void Awake() 
	{
		GameObject sceneControllerObject = GameObject.Find ("SceneController");
		if (sceneControllerObject != null) 
		{
			sceneController = sceneControllerObject.GetComponent<SceneController> ();
		}
	}

	public void PressPlayGameButton() 
	{
		playGameButton.SetActive (false);
		choosePlayersButtons.SetActive (true);
	}

	public void PressChoosePlayerButton(int playerChoice) 
	{
		sceneController.SetPlayer (playerChoice);
		SceneManager.LoadScene ("Game");
	}
}
