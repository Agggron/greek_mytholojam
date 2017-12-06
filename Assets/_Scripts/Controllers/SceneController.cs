using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {

	public static SceneController instance;

	public enum CurrentScene {Menu, Acropolis, Parthenon};

	public enum MenuSceneOptions {Default, Win, Lose};
	public MenuSceneOptions menuSceneOption;

	public CurrentScene currentScene;

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
		switch (currentScene) {
			case CurrentScene.Menu:
				StartMenuScene ();
				break;
			case CurrentScene.Acropolis:
				StartAcropolisScene ();
				break;
			case CurrentScene.Parthenon:
				StartParthenonScene ();
				break;
		}
	}

	public void StartMenuScene ()
	{
		currentScene = CurrentScene.Menu;
		SceneManager.LoadScene ("MainMenu");
	}

	public void StartAcropolisScene ()
	{
		currentScene = CurrentScene.Acropolis;
		SceneManager.LoadScene ("Acropolis");
	}

	public void StartParthenonScene ()
	{
		currentScene = CurrentScene.Parthenon;
		SceneManager.LoadScene ("Parthenon");
	}
}
