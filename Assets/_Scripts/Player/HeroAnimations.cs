using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroAnimations : MonoBehaviour {

	public Transform hero;
	public Transform sword;
	private PlayerMovement playerMovement;
	private PlayerHealth playerHealth;

	void Awake ()
	{
		playerMovement = GetComponentInParent<PlayerMovement> ();
		playerHealth = GetComponentInParent<PlayerHealth> ();
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

	void WaterDashAnimationStart ()
	{
		playerHealth.playerInvulnerable = PlayerHealth.PlayerInvulnerable.Yes;
	}

	void WaterDashAnimationEnd ()
	{
		playerHealth.playerInvulnerable = PlayerHealth.PlayerInvulnerable.No;
		hero.position = transform.position;
	}

}
