using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {

	public static SceneController instance;

	public GameObject[] possiblePlayers;
	public GameObject chosenPlayer;

	void Awake() 
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

	public void SetPlayer(int playerNum) 
	{
		if (playerNum < possiblePlayers.Length)
		{
			chosenPlayer = possiblePlayers [playerNum];
		}
	}

	void Update()
	{
		if (Input.GetKeyDown (KeyCode.Escape)) 
		{
			SceneManager.LoadScene ("MainMenu");
		}
	}
}
