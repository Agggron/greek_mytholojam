using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSystemController : MonoBehaviour {

	public static EventSystemController instance;

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
}
