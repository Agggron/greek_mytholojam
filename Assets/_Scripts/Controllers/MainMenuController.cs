using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour {

	private SceneController sceneController;

	public GameObject playGameButton;
	public GameObject choosePlayersButtons;
	public GameObject mainMenuButton;
	public GameObject instructionsButton;
	public GameObject creditsButton;
	public Text title;
	public Text instructionsText;
	public Text instructionsText2;
	public Text creditsText;
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
		instructionsButton.SetActive (true);
		instructionsText.enabled = false;
		instructionsText.gameObject.SetActive (false);
		instructionsText2.enabled = false;
		instructionsText2.gameObject.SetActive (false);
		creditsButton.SetActive (true);
		creditsText.enabled = false;
		creditsText.gameObject.SetActive (false);

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
		creditsText.enabled = false;
		creditsText.gameObject.SetActive (false);
	}

	public void SetUpInstructions ()
	{
		playGameButton.SetActive (false);
		choosePlayersButtons.SetActive (false);
		mainMenuButton.SetActive (true);
		title.enabled = false;
		title.gameObject.SetActive (false);
		gameWinText.enabled = false;
		gameWinText.gameObject.SetActive (false);
		gameOverText.enabled = false;
		gameOverText.gameObject.SetActive (false);
		instructionsButton.SetActive (false);
		instructionsText.enabled = true;
		instructionsText.gameObject.SetActive (true);
		instructionsText2.enabled = true;
		instructionsText2.gameObject.SetActive (true);
		creditsButton.SetActive (false);
		creditsText.enabled = false;
		creditsText.gameObject.SetActive (false);
	}

	public void SetUpCredits ()
	{
		playGameButton.SetActive (false);
		choosePlayersButtons.SetActive (false);
		mainMenuButton.SetActive (true);
		title.enabled = false;
		title.gameObject.SetActive (false);
		gameWinText.enabled = false;
		gameWinText.gameObject.SetActive (false);
		gameOverText.enabled = false;
		gameOverText.gameObject.SetActive (false);
		instructionsButton.SetActive (false);
		instructionsText.enabled = false;
		instructionsText.gameObject.SetActive (false);
		instructionsText2.enabled = false;
		instructionsText2.gameObject.SetActive (false);
		creditsButton.SetActive (false);
		creditsText.enabled = true;
		creditsText.gameObject.SetActive (true);
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
		instructionsButton.SetActive (false);
		instructionsText.enabled = false;
		instructionsText.gameObject.SetActive (false);
		instructionsText2.enabled = false;
		instructionsText2.gameObject.SetActive (false);
		creditsButton.SetActive (false);
		creditsText.enabled = false;
		creditsText.gameObject.SetActive (false);

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
		instructionsButton.SetActive (false);
		instructionsText.enabled = false;
		instructionsText.gameObject.SetActive (false);
		instructionsText2.enabled = false;
		instructionsText2.gameObject.SetActive (false);
		creditsButton.SetActive (false);
		creditsText.enabled = false;
		creditsText.gameObject.SetActive (false);

		sceneController.menuSceneOption = SceneController.MenuSceneOptions.Default;
	}

	public void StartGameFromMainMenu ()
	{
		PlayerData.player = chosenPlayer;
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
