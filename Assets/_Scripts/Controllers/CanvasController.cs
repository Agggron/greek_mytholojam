using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour {

	public static CanvasController instance;

	public GameObject playGameButton;
	public GameObject choosePlayersButtons;
	public GameObject mainMenuButton;
	public Text title;
	public Text gameWinText;
	public Text gameOverText;

	void Awake ()
	{
		if (instance == null) 
		{
			instance = this;
		} 

		else if (instance != null) 
		{
			Destroy (gameObject);
		}

		DontDestroyOnLoad (gameObject);
	}

	void Start ()
	{
		SetUpDefault ();
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
	}

	public void SetUpChoosePlayer ()
	{
		playGameButton.SetActive (false);
		choosePlayersButtons.SetActive (true);
		mainMenuButton.SetActive (false);
		title.enabled = true;
		title.gameObject.SetActive (true);
		gameWinText.enabled = false;
		gameWinText.gameObject.SetActive (false);
		gameOverText.enabled = false;
		gameOverText.gameObject.SetActive (false);
	}

	public void SetUpGameWin ()
	{
		Debug.Log ("Win");
		playGameButton.SetActive (false);
		choosePlayersButtons.SetActive (false);
		mainMenuButton.SetActive (true);
		title.enabled = false;
		title.gameObject.SetActive (false);
		gameWinText.enabled = true;
		gameWinText.gameObject.SetActive (true);
		gameOverText.enabled = false;
		gameOverText.gameObject.SetActive (false);
	}

	public void SetUpGameOver ()
	{
		Debug.Log ("Lose");
		playGameButton.SetActive (false);
		choosePlayersButtons.SetActive (false);
		mainMenuButton.SetActive (true);
		title.enabled = false;
		title.gameObject.SetActive (false);
		gameWinText.enabled = false;
		gameWinText.gameObject.SetActive (false);
		gameOverText.enabled = true;
		gameOverText.gameObject.SetActive (true);
	}
}
