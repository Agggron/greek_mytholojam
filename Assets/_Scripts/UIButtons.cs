using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtons : MonoBehaviour {

	public GameObject playGameButton;
	public GameObject choosePlayersButtons;
	public SceneController sceneController;

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
		sceneController.SetPlayer (playerChoice);
		SceneManager.LoadScene ("Game");
	}
}
