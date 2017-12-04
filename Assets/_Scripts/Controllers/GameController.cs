using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public static GameController instance;

	private CanvasController canvasController;

	public GameObject[] possiblePlayers;
	public GameObject chosenPlayer;
	public GameObject[] possibleEnemies;

	public GameObject canvasMenu;
	public GameObject canvasGame;
	public enum CanvasType {Menu, Game};
	public CanvasType currentCanvasType;

	public int playerHealthMax = 100;
	public int playerHealth;
	public Slider playerHealthSlider;
	public int playerProgress;
	public Slider playerProgressSlider;

	public bool playerIsDamaged = false;
	public Image playerDamagedImage;
	public Color playerDamagedColor;
	public float damagedColorFadeSpeed;

	public bool playerIsDead = false;

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

		GameObject canvasControllerObject = GameObject.FindGameObjectWithTag ("CanvasController");
		if (canvasControllerObject != null) {
			canvasController = canvasControllerObject.GetComponent<CanvasController> ();
		} else {
			Debug.Log ("Cannot find CanvasController script!");
		}
	}

	void Start ()
	{

		currentCanvasType = CanvasType.Menu;
		playerHealth = 0;
		playerProgress = 0;
		canvasController.SetUpDefault ();
	}
		
	void Update()
	{
		if (Input.GetKeyDown (KeyCode.Escape)) 
		{
			StartMainMenuScene ();
		}

		if (currentCanvasType == CanvasType.Game) 
		{
			if (playerIsDamaged) 
			{
				playerDamagedImage.color = playerDamagedColor;
			} 
			else 
			{
				playerDamagedImage.color = Color.Lerp (playerDamagedImage.color, Color.clear, damagedColorFadeSpeed * Time.deltaTime);
			}

			playerIsDamaged = false;
		}

	}
		
	public void StartMainMenuScene ()
	{
		SceneManager.LoadScene ("MainMenu");
		canvasMenu.SetActive (true);
		canvasGame.SetActive (false);
		currentCanvasType = CanvasType.Menu;
	}

	public void StartAcropolisScene ()
	{
		SetPlayerHealth(playerHealthMax);
		SetPlayerProgress (0);
		playerIsDead = false;

		SceneManager.LoadScene ("Acropolis"); // Automatically starts AcropolisLevelController script
		canvasMenu.SetActive (false);
		canvasGame.SetActive (true);
		currentCanvasType = CanvasType.Game;
	}

	public void StartParthenonScene ()
	{
		SceneManager.LoadScene ("Parthenon"); // Automatically starts ParthenonLevelController script
		canvasMenu.SetActive (false);
		canvasGame.SetActive (true);
		currentCanvasType = CanvasType.Game;
	}

	public void SetPlayer (int playerNum) 
	{
		if (playerNum < possiblePlayers.Length)
		{
			chosenPlayer = possiblePlayers [playerNum];
		}
	}
		
	public void SetPlayerHealth (int health)
	{
		playerHealth = health;
		playerHealthSlider.value = health;

		if (playerHealth <= 0) {
			StartMainMenuScene ();
			canvasController.SetUpGameOver ();
		}
	}

	public void SetPlayerProgress (int progress) 
	{
		playerProgress = progress;
		playerProgressSlider.value = progress;

		if ((playerProgress >= 100) && (playerProgress < 200))
		{
			StartParthenonScene ();
		}

		if (playerProgress >= 200) 
		{
			StartMainMenuScene ();
			canvasController.SetUpGameWin ();
		}
	}

}
