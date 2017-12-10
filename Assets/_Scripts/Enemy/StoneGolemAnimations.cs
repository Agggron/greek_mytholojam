using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneGolemAnimations : MonoBehaviour {

	private EnemyAttack enemyAttack;

	void Awake ()
	{
		enemyAttack = GetComponentInParent<EnemyAttack> ();
	}

	void StoneGolemAttackStop ()
	{
		enemyAttack.StoneGolemAttackStop ();
	}
}
