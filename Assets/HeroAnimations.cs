using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroAnimations : MonoBehaviour {

	public Transform hero;
	public Transform sword;
	private PlayerMovement playerMovement;

	void Awake ()
	{
		playerMovement = GetComponentInParent<PlayerMovement> ();
	}
		

	void FreezeMovementStart ()
	{
		playerMovement.enabled = false;
	}

	void FreezeMovementEnd ()
	{
		playerMovement.enabled = true;
	}

	void PlayerAttackSwingStart ()
	{
		sword.GetComponent<SwordAttack> ().isAttacking = true;
	}

	void PlayerAttackSwingEnd ()
	{
		sword.GetComponent<SwordAttack> ().isAttacking = false;
	}

	void WaterDashAnimationEnd ()
	{
		hero.position = transform.position;
	}
}
