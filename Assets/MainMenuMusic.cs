using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuMusic : MonoBehaviour {

	public AudioSource src;
	public AudioClip mainMenuClip;
	public AudioClip winClip;
	public AudioClip loseClip;

	public bool changedMusic;

	void Awake() 
	{

		src = GetComponent<AudioSource> ();
	}

	void Start () 
	{
		changedMusic = false;
	}

	void Update ()
	{
		if (changedMusic == false) {
			if (PlayerData.health <= 0) {
				src.clip = loseClip;
				src.Play ();
				changedMusic = true;
			}
			if (PlayerData.progress >= 1000) {
				src.clip = loseClip;
				src.Play ();
				changedMusic = true;
			}
		}
	}
}
