using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIButtons : MonoBehaviour {

	private GameController gameController;
	private CanvasController canvasController;

	public GameObject playGameButton;
	public GameObject choosePlayersButtons;
	public GameObject mainMenuButton;

	public Text title;
	public Text gameWinText;
	public Text gameOverText;


	[FMODUnity.EventRef]
	public string SoundPlayGameButton;
	[FMODUnity.EventRef]
	public string SoundFirePlayerButton;
	[FMODUnity.EventRef]
	public string SoundWaterPlayerButton;
	[FMODUnity.EventRef]
	public string SoundEarthPlayerButton;
	[FMODUnity.EventRef]
	public string SoundAirPlayerButton;

	void Awake() 
	{
		GameObject gameControllerObject = GameObject.Find ("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent<GameController> ();
		} else {
			Debug.Log ("Cannot find GameController script!");
		}

		GameObject canvasControllerObject = GameObject.FindGameObjectWithTag ("CanvasController");
		if (canvasControllerObject != null) {
			canvasController = canvasControllerObject.GetComponent<CanvasController> ();
		} else {
			Debug.Log ("Cannot find CanvasController script!");
		}
	}

	public void PressPlayGameButton() 
	{
		canvasController.SetUpChoosePlayer ();

		FMODUnity.RuntimeManager.PlayOneShot (SoundPlayGameButton, playGameButton.gameObject.transform.position);
	}

	public void PressChoosePlayerButton(int playerChoice) 
	{
		switch (playerChoice) 
		{
			case 0:
				FMODUnity.RuntimeManager.PlayOneShot (SoundFirePlayerButton, playGameButton.gameObject.transform.position);
				break;
			case 1:
				FMODUnity.RuntimeManager.PlayOneShot (SoundWaterPlayerButton, playGameButton.gameObject.transform.position);
				break;
			case 2:
				FMODUnity.RuntimeManager.PlayOneShot (SoundEarthPlayerButton, playGameButton.gameObject.transform.position);
				break;
			case 3:
				FMODUnity.RuntimeManager.PlayOneShot (SoundAirPlayerButton, playGameButton.gameObject.transform.position);
				break;
		}
		gameController.SetPlayer (playerChoice);
		gameController.StartAcropolisScene ();
	}

	public void PressMainMenuButton ()
	{
		canvasController.SetUpDefault ();
	}
}
