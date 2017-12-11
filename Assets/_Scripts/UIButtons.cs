using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIButtons : MonoBehaviour {

	private MainMenuController mainMenuController;

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
		GameObject mainMenuControllerObject = GameObject.Find ("MainMenuController");
		if (mainMenuControllerObject != null) {
			mainMenuController = mainMenuControllerObject.GetComponent<MainMenuController> ();
		} else {
			Debug.Log ("Cannot find MainMenuController script!");
		}
	}

	public void PressPlayGameButton() 
	{
		mainMenuController.StartGameFromMainMenu ();

		FMODUnity.RuntimeManager.PlayOneShot (SoundPlayGameButton, mainMenuController.playGameButton.gameObject.transform.position);
	}

	public void PressInstructionsButton ()
	{
		mainMenuController.SetUpInstructions ();

		FMODUnity.RuntimeManager.PlayOneShot (SoundPlayGameButton, mainMenuController.instructionsButton.gameObject.transform.position);
	}

	public void PressChoosePlayerButton(int playerChoice) 
	{
		switch (playerChoice) 
		{
			case 0:
				FMODUnity.RuntimeManager.PlayOneShot (SoundFirePlayerButton, mainMenuController.playGameButton.gameObject.transform.position);
				break;
			case 1:
				FMODUnity.RuntimeManager.PlayOneShot (SoundWaterPlayerButton, mainMenuController.playGameButton.gameObject.transform.position);
				break;
			case 2:
				FMODUnity.RuntimeManager.PlayOneShot (SoundEarthPlayerButton, mainMenuController.playGameButton.gameObject.transform.position);
				break;
			case 3:
				FMODUnity.RuntimeManager.PlayOneShot (SoundAirPlayerButton, mainMenuController.playGameButton.gameObject.transform.position);
				break;
		}
		mainMenuController.StartGameFromMainMenu ();
	}

	public void PressMainMenuButton ()
	{
		mainMenuController.SetUpDefault ();

		FMODUnity.RuntimeManager.PlayOneShot (SoundPlayGameButton, mainMenuController.mainMenuButton.gameObject.transform.position);
	}

	public void PressCreditsButton ()
	{
		mainMenuController.SetUpCredits ();

		FMODUnity.RuntimeManager.PlayOneShot (SoundPlayGameButton, mainMenuController.creditsButton.gameObject.transform.position);
	}
}
