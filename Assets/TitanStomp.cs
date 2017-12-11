using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitanStomp : MonoBehaviour {

	public bool isStomping;
	public int stompDamage = 100;

	void OnTriggerStay(Collider other) 
	{
		if (isStomping) 
		{
			if (other.gameObject.CompareTag ("Player")) 
			{
				PlayerHealth playerHealth = other.gameObject.GetComponent<PlayerHealth> ();
				playerHealth.TakeDamage (stompDamage);
			}
		}
	}
}
