using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIController : MonoBehaviour {

	private PlayerHealth playerHealth;

	public int currentHealth;
	public int currentProgress;

	public Slider playerHealthSlider;
	public Slider playerProgressSlider;
	public Image playerDamagedImage;
	public Color playerDamagedColor = new Color(255.0f, 0.0f, 0.0f, 100.0f);
	public float damagedColorFadeSpeed;

	void Awake() 
	{
		
	}

	void Start()
	{
		GameObject playerObject = GameObject.FindGameObjectWithTag ("Player");
		if (playerObject != null) {
			playerHealth = playerObject.GetComponent<PlayerHealth> ();
		} else {
			Debug.Log ("Cannot find Player and/or its scripts!");
		}
	}
		
	void Update()
	{
		currentHealth = PlayerData.health;
		currentProgress = PlayerData.progress;

		if (playerHealth.playerIsDamaged) 
		{
			playerDamagedImage.color = playerDamagedColor;
		} 
		else 
		{
			playerDamagedImage.color = Color.Lerp (playerDamagedImage.color, Color.clear, damagedColorFadeSpeed * Time.deltaTime);
		}

		playerHealth.playerIsDamaged = false;
	}

	public void SetPlayerHealth (int health)
	{
		PlayerData.health = health;
		playerHealthSlider.value = health;
	}

	public void SetPlayerProgress (int progress) 
	{
		PlayerData.progress = progress;
		playerProgressSlider.value = progress;
	}
}
