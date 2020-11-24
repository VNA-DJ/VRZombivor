using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAttack : MonoBehaviour {

	public float timeBetweenAttacks = 0.5f;
	public float timer;

	public AudioClip[] attacks;
	private int damage = 4;
	private GameObject player;            
	private PlayerHealth playerHealth;   
	private EnemyHealth enemyHealth;
	private bool playerInRange;

	AudioSource attackAudio;

	Animator anim;

	void Awake ()
	{
		attackAudio = GetComponent<AudioSource> ();
		player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = player.GetComponent <PlayerHealth> ();
	}


	void OnTriggerEnter (Collider other)
	{
		attackAudio.Play ();
		if(other.gameObject == player)
		{
			playerInRange = true;
		}
	}


	void OnTriggerExit (Collider other)
	{
		attackAudio.Stop();
		if(other.gameObject == player)
		{
			playerInRange = false;
		}
	}

	void Update()
	{ 
		timer += Time.deltaTime;
		if (timer >= timeBetweenAttacks && playerInRange) {
				Attack ();
		}
	}

	void Attack()
	{
		timer = 0;
		playerHealth.TakeDamage (damage);
		int i = Random.Range(0, attacks.Length);
		AudioSource.PlayClipAtPoint(attacks[i], transform.position);
	}
}
