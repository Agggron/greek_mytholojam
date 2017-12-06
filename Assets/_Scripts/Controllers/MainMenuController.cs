using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour {

	private SceneController sceneController;

	public GameObject playGameButton;
	public GameObject choosePlayersButtons;
	public GameObject mainMenuButton;
	public Text title;
	public Text gameWinText;
	public Text gameOverText;

	public GameObject[] possiblePlayers;
	public GameObject chosenPlayer;

	void Awake() 
	{
		GameObject sceneControllerObject = GameObject.Find ("SceneController");
		if (sceneControllerObject != null) {
			sceneController = sceneControllerObject.GetComponent<SceneController> ();
		} else {
			Debug.Log ("Cannot find SceneController script!");
		}
	}

	void Start () 
	{
		switch (sceneController.menuSceneOption) 
		{
			case SceneController.MenuSceneOptions.Default:
				SetUpDefault ();
				break;
			case SceneController.MenuSceneOptions.Win:
				SetUpGameWin ();
				break;
			case SceneController.MenuSceneOptions.Lose:
				SetUpGameOver ();
				break;
		}
	}
	
	public void SetUpDefault ()
	{
		playGameButton.SetActive (true);
		choosePlayersButtons.SetActive (false);
		mainMenuButton.SetActive (false);
		title.enabled = true;
		title.gameObject.SetActive (true);
		gameWinText.enabled = false;
		gameWinText.gameObject.SetActive (false);
		gameOverText.enabled = false;
		gameOverText.gameObject.SetActive (false);

		sceneController.menuSceneOption = SceneController.MenuSceneOptions.Default;
	}

	public void SetUpChoosePlayer ()
	{
		playGameButton.SetActive (false);
		choosePlayersButtons.SetActive (true);
		mainMenuButton.SetActive (true);
		title.enabled = true;
		title.gameObject.SetActive (true);
		gameWinText.enabled = false;
		gameWinText.gameObject.SetActive (false);
		gameOverText.enabled = false;
		gameOverText.gameObject.SetActive (false);
	}

	public void SetUpGameWin ()
	{
		playGameButton.SetActive (false);
		choosePlayersButtons.SetActive (false);
		mainMenuButton.SetActive (true);
		title.enabled = false;
		title.gameObject.SetActive (false);
		gameWinText.enabled = true;
		gameWinText.gameObject.SetActive (true);
		gameOverText.enabled = false;
		gameOverText.gameObject.SetActive (false);

		sceneController.menuSceneOption = SceneController.MenuSceneOptions.Default;
	}

	public void SetUpGameOver ()
	{
		playGameButton.SetActive (false);
		choosePlayersButtons.SetActive (false);
		mainMenuButton.SetActive (true);
		title.enabled = false;
		title.gameObject.SetActive (false);
		gameWinText.enabled = false;
		gameWinText.gameObject.SetActive (false);
		gameOverText.enabled = true;
		gameOverText.gameObject.SetActive (true);

		sceneController.menuSceneOption = SceneController.MenuSceneOptions.Default;
	}

	public void StartGameFromMainMenu ()
	{
		sceneController.StartAcropolisScene ();
	}

	public void SetPlayer (int playerNum) 
	{
		if (playerNum < possiblePlayers.Length)
		{
			chosenPlayer = possiblePlayers [playerNum];
			PlayerData.player = chosenPlayer;
		}
	}
}
