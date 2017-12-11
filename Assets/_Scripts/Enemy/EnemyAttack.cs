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

	public GameObject boulder;
	public Transform boulderSpawnPoint;

	public GameObject lava;
	public Transform lavaSpawnPoint;

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

		if (enemyType == EnemyType.Titan) {
			StartCoroutine ("TitanAttack");
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
			GameObject newBoulder = Instantiate (boulder, boulderSpawnPoint.position, boulderSpawnPoint.rotation);
			newBoulder.GetComponent<BoulderMovementDamage> ().ShootBoulder ();
			yield return new WaitForSeconds (5.0f);
		}
	}

	IEnumerator TitanAttack ()
	{

		yield return new WaitForSeconds (4.0f);
		while (!enemyHealth.isDead) 
		{
			nav.isStopped = true;
			anim.SetBool ("isRunning", false);

			anim.SetTrigger ("titanSpit");
			GameObject newLava = Instantiate (lava, lavaSpawnPoint.position, lavaSpawnPoint.rotation);
			newLava.GetComponent<LavaDamage> ().ShootLava ();
			yield return new WaitForSeconds (5.0f);

			if (GetDistanceFromPlayer () <= 5.0f) {
				nav.isStopped = true;
				anim.SetBool ("isRunning", false);
				anim.SetTrigger ("titanStomp");
				yield return new WaitForSeconds (4.0f);
			} else {
				nav.isStopped = true;
				anim.SetBool ("isRunning", false);
		
				anim.SetTrigger ("titanSpit");
				newLava = Instantiate (lava, lavaSpawnPoint.position, lavaSpawnPoint.rotation);
				newLava.GetComponent<LavaDamage> ().ShootLava ();
				yield return new WaitForSeconds (4.0f);
			}

		
		}

	}

	float GetDistanceFromPlayer () 
	{
		return Vector3.Distance (player.transform.position, transform.position);
	}

	public void StoneGolemAttackStop ()
	{
		Debug.Log ("i'm called");
		nav.isStopped = false;
		anim.SetBool ("isRunning", true);
	}

	public void TitanAttackStop ()
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
		if ((!enemyHealth.isDead) && (damageTimer >= timeBetweenDamageInstances) && (other.gameObject == player))
		{
			damageTimer = 0.0f;
			playerHealth.TakeDamage (attackDamage);
		}
	}
}
