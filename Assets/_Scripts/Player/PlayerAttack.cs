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


	void Awake()
	{
		anim = GetComponent<Animator> ();

		sword = gameObject.transform.Find ("Sword");
		if (sword == null) 
		{
			Debug.Log ("PlayerAttack script cannot find child object 'Sword'");
		}

		playerIsAttacking = false;
		basicAttackTimer = 0.0f;
	}

	void Update() 
	{
		basicAttackTimer += Time.deltaTime;
			
		if ((Input.GetKeyDown (KeyCode.Space)) && (playerIsAttacking == false) && (basicAttackTimer > timeBetweenBasicAttack)) 
		{
			PlayerBasicAttack ();
		}
	}

	void PlayerBasicAttack() 
	{
		basicAttackTimer = 0.0f;
		anim.SetTrigger ("playerBasicAttack");
	}

	void PlayerBasicAttackSwingStart()
	{
		sword.GetComponent<SwordAttack> ().isAttacking = true;
	}

	void PlayerBasicAttackSwingEnd()
	{
		sword.GetComponent<SwordAttack> ().isAttacking = false;
	}
}
