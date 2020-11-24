using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAttackToProp : MonoBehaviour {


	public float timeBetweenAttacks = 0.5f;
	public float timer;

	public AudioClip[] attacks;
	private int damage = 3;
	private GameObject prop;            
	private PropHealth propHealth;   
	private EnemyHealth enemyHealth;
	private bool playerInRange;

	AudioSource attackAudio;

	Animator anim;

	void Awake ()
	{
		attackAudio = GetComponent<AudioSource> ();
		prop = GameObject.FindGameObjectWithTag ("Prop");
		propHealth = prop.GetComponent <PropHealth> ();
	}

	void OnTriggerEnter (Collider other)
	{
		attackAudio.Play ();
		if(other.gameObject == prop)
		{
			playerInRange = true;
		}
	}


	void OnTriggerExit (Collider other)
	{
		attackAudio.Stop();
		if(other.gameObject == prop)
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
		propHealth.TakeDamage (damage);
		int i = Random.Range(0, attacks.Length);
		AudioSource.PlayClipAtPoint(attacks[i], transform.position);
	}
}
