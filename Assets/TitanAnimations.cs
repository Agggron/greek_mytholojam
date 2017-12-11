using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitanAnimations : MonoBehaviour {

	private TitanStomp titanStomp;
	private EnemyAttack enemyAttack;

	void Awake ()
	{
		enemyAttack = GetComponentInParent<EnemyAttack> ();
		titanStomp = GetComponentInChildren<TitanStomp> ();
	}

	void TitanAttackStop ()
	{
		enemyAttack.TitanAttackStop ();
	}

	void StompColliderStart ()
	{
		titanStomp.isStomping = true;
	}

	void StompColliderEnd ()
	{
		titanStomp.isStomping = false;
	}
}
