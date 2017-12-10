using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

	public bool playerIsAttacking;
	public Animator anim;
	private Transform sword;

	public int basicAttackDamage = 10;
	public float timeBetweenBasicAttack = 1.0f;
	public float basicAttackTimer;

	public float timeBetweenSpecialAttack = 1.0f;
	public float specialAttackTimer;


	void Awake()
	{
		anim = GetComponentInChildren<Animator> ();

		playerIsAttacking = false;
		basicAttackTimer = 0.0f;
	}

	void Update() 
	{
		basicAttackTimer += Time.deltaTime;
		specialAttackTimer += Time.deltaTime;
			
		if ((Input.GetKeyDown (KeyCode.Z)) && (playerIsAttacking == false) && (basicAttackTimer > timeBetweenBasicAttack)) 
		{
			PlayerBasicAttack ();
		}

		if ((Input.GetKeyDown (KeyCode.X)) && (playerIsAttacking == false) && (specialAttackTimer > timeBetweenSpecialAttack)) 
		{
			PlayerBoulderSmash ();
		}
	}

	void PlayerBasicAttack() 
	{
		basicAttackTimer = 0.0f;
		anim.SetTrigger ("playerAttack");
	}

	void PlayerBoulderSmash ()
	{
		specialAttackTimer = 0.0f;
		anim.SetTrigger ("boulderSmash");
	}


}
