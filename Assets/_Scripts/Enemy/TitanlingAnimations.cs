using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitanlingAnimations : MonoBehaviour {

	public Transform titanlingPosition;
	private EnemyAttack enemyAttack;

	void Awake ()
	{
		enemyAttack = GetComponentInParent<EnemyAttack> ();
	}

	void AttackDone ()
	{
		titanlingPosition.position = transform.position;
		enemyAttack.AttackDone ();
	}

}
