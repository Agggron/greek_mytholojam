using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAttack : MonoBehaviour {

	public enum EnemyType {Titanling, StoneGolem, Titan};
	public EnemyType enemyType = EnemyType.StoneGolem;

	private GameObject player;
	private PlayerHealth playerHealth;
	private Animator anim;
	private NavMeshAgent nav;
	private EnemyHealth enemyHealth;

	public bool isAttacking;

	public float timeBetweenAttacks = 5.0f;
	public int attackDamage = 10;
	public float distanceFromPlayer;
	public float attackRangeMin = 2.0f;
	public float attackRangeMax = 4.0f;
	public float attackTimer;
	public float timeBetweenDamageInstances = 0.5f;
	public float damageTimer;

	void Awake()
	{
		GameObject playerObject = GameObject.FindGameObjectWithTag ("Player");
		if (playerObject != null) {
			player = playerObject;
			playerHealth = player.GetComponent<PlayerHealth> ();
		} else {
			Debug.Log ("Cannot find Player and/or its scripts!");
		}


		anim = GetComponentInChildren<Animator> ();
		nav = GetComponent<NavMeshAgent> ();
		enemyHealth = GetComponent<EnemyHealth> ();
	}

	void Start()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = player.GetComponent<PlayerHealth> ();

		if (enemyType == EnemyType.StoneGolem) {
			StartCoroutine ("StoneGolemAttack");
		}
	}

	IEnumerator StoneGolemAttack () 
	{
		yield return new WaitForSeconds (5.0f);
		while (!enemyHealth.isDead) 
		{
			nav.isStopped = true;
			anim.SetBool ("isRunning", false);

			anim.SetTrigger ("stoneGolemAttack");
			yield return new WaitForSeconds (5.0f);
		}
	}

	public void StoneGolemAttackStop ()
	{
		nav.isStopped = false;
		anim.SetBool ("isRunning", true);
	}


	void Update ()
	{
		attackTimer += Time.deltaTime;
		damageTimer += Time.deltaTime;

		distanceFromPlayer = Vector3.Distance (player.transform.position, transform.position);
		if ((playerHealth.playerIsDead == false) && (isAttacking == false) && (distanceFromPlayer >= attackRangeMin)
			&& (distanceFromPlayer <= attackRangeMax) && (attackTimer >= timeBetweenAttacks))
		{
			if (enemyType == EnemyType.Titanling) 
			{
				AttackTitanling ();
			}

			/*if (enemyType == EnemyType.StoneGolem) 
			{
				AttackStoneGolem ();
			}*/
		}
	}

	void AttackTitanling ()
	{
		isAttacking = true;
		nav.isStopped = true;
		anim.SetTrigger ("titanlingBasicAttack");
	}

	void AttackStoneGolem ()
	{
		isAttacking = true;
		nav.isStopped = true;
		anim.SetTrigger ("stoneGolemAttack");
	}

	public void AttackDone ()
	{
		isAttacking = false;
		attackTimer = 0.0f;
		nav.isStopped = false;
	}

	void OnTriggerStay(Collider other) 
	{
		if ((damageTimer >= timeBetweenDamageInstances) && (other.gameObject == player))
		{
			damageTimer = 0.0f;
			playerHealth.TakeDamage (attackDamage);
		}
	}
}
