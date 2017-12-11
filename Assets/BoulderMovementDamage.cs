using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderMovementDamage : MonoBehaviour {

	public enum BoulderUser {Player, StoneGolem};
	public BoulderUser boulderUser;


	public float speed = 5.0f;
	public int boulderDamage = 10;
	public bool isShooting = false;

	public Vector3 target;

	private GameObject player;
	private Animator anim;
	private MeshRenderer meshRenderer;

	void Awake ()
	{
		GameObject playerObject = GameObject.FindGameObjectWithTag ("Player");
		if (playerObject != null) {
			player = playerObject;
		} else {
			Debug.Log ("Cannot find Player and/or its scripts!");
		}

		anim = GetComponent<Animator>();
		meshRenderer = GetComponent<MeshRenderer> ();
	}

	void Start ()
	{
	}

	void Update ()
	{
		if (isShooting) 
		{
			if (boulderUser == BoulderUser.Player) 
			{
				target = transform.position + transform.forward;
			}
	
			transform.position = Vector3.MoveTowards (transform.position, target, speed * Time.deltaTime);
		}
	}

	public void ShootBoulder () 
	{
		isShooting = true;

		if (boulderUser == BoulderUser.StoneGolem) 
		{
			target = player.transform.position + new Vector3 (0.0f, 0.25f, 0.0f);
		}
	}

	void OnTriggerStay(Collider other) 
	{
		if (isShooting) 
		{
			if (other.gameObject.CompareTag ("Environment")) 
			{
				anim.SetTrigger ("boulderSplinter");
				isShooting = false;
				meshRenderer.enabled = false;
			}

			if (boulderUser == BoulderUser.Player) 
			{
				if (other.gameObject.CompareTag ("Enemy")) 
				{
					EnemyHealth enemyHealth = other.gameObject.GetComponent<EnemyHealth>();
					enemyHealth.TakeDamage (boulderDamage);
					anim.SetTrigger ("boulderSplinter");
					isShooting = false;
					meshRenderer.enabled = false;
				}
			}

			if (boulderUser == BoulderUser.StoneGolem) 
			{
				if (other.gameObject.CompareTag ("Player")) 
				{
					PlayerHealth playerHealth = other.gameObject.GetComponent<PlayerHealth>();
					playerHealth.TakeDamage (boulderDamage);
					anim.SetTrigger ("boulderSplinter");
					isShooting = false;
					meshRenderer.enabled = false;
				}
			}



		}
	}

	public void DestroyBoulderAndShards ()
	{
		Destroy (gameObject);
	}
}
