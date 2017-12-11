using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pants : MonoBehaviour {

	public GameObject pants;

	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.P))
		{
			if (pants.activeSelf) 
			{
				pants.SetActive (false);
			} 
			else 
			{
				pants.SetActive (true);
			}
		}
	}
}
