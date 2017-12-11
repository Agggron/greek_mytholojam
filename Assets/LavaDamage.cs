using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaDamage : MonoBehaviour {

	public int lavaDamage = 10;
	public float timeBetweenDamageInstances = 1.0f;
	private float damageTimer;
	public float speed = 5.0f;

	public bool isShooting = false;
	public Vector3 target;
	public GameObject player;


	void Awake ()
	{
		GameObject playerObject = GameObject.FindGameObjectWithTag ("Player");
		if (playerObject != null) {
			player = playerObject;
		} else {
			Debug.Log ("Cannot find Player and/or its scripts!");
		}
	}

	void Start ()
	{
		damageTimer = 0.0f;
	}

	void Update ()
	{
		damageTimer += Time.deltaTime;

		if (isShooting) 
		{
			transform.position = Vector3.MoveTowards (transform.position, target, speed * Time.deltaTime);
		}
	}

	public void ShootLava ()
	{
		isShooting = true;
		target = player.transform.position + new Vector3 (0.0f, 0.05f, 0.0f);
	}

	void OnTriggerStay (Collider other) 
	{
		if ((damageTimer >= timeBetweenDamageInstances) && (other.gameObject.CompareTag("Player")))
		{
			damageTimer = 0.0f;
			PlayerHealth playerHealth = other.gameObject.GetComponent<PlayerHealth> ();
			playerHealth.TakeDamage (lavaDamage);
		}
	}
}
