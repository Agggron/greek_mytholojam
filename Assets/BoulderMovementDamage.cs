using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderMovementDamage : MonoBehaviour {

	public float speed = 5.0f;
	public int boulderDamage = 10;
	public bool isShooting = false;

	void Start ()
	{
	}

	void Update ()
	{
		if (isShooting) 
		{
			Vector3 target = transform.position + transform.forward;
			transform.position = Vector3.MoveTowards (transform.position, target, speed * Time.deltaTime);
		}
	}

	public void ShootBoulder () 
	{
		isShooting = true;
	}

	void OnTriggerStay(Collider other) 
	{
		if (isShooting) 
		{
			if (other.gameObject.CompareTag ("Enemy")) 
			{
				EnemyHealth enemyHealth = other.gameObject.GetComponent<EnemyHealth>();
				enemyHealth.TakeDamage (boulderDamage);
				Destroy (gameObject);
			}

			if (other.gameObject.CompareTag ("Environment")) 
			{
				Destroy (gameObject);
			}

		}
	}
}
