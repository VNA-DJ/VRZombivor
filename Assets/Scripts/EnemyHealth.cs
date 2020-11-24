using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour {

	public int Health = 100;
	public AudioClip[] pain;
	public int currentHealth;
	public int scoreValue = 1;
	public float sinkSpeed = 2.5f;  
	public bool isHit = false;

	bool isSinking;
	zombie_ai ai;
	Zombie_AI2 ai2;
	public AudioClip deathClip;
	private Transform player;

	AudioSource enemyAudio;
	bool isDead;
	bool distance;

	void Awake ()
	{
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		ai = GetComponent<zombie_ai> ();
		ai2 = GetComponent<Zombie_AI2> ();
		enemyAudio = GetComponent <AudioSource> ();
		currentHealth = Health;
	}

	void Update ()
	{
		if (Application.loadedLevelName == "Cage" || Application.loadedLevelName == "PlaneCrash") {
			if (Vector3.Distance (player.position, transform.position) < 2) {
				distance = true;
			}

			if (distance)
				Death ();
		}
		// If the enemy should be sinking...
		if(isSinking)
		{
			// ... move the enemy down by the sinkSpeed per second.
			transform.Translate (-Vector3.up * sinkSpeed * Time.deltaTime);
		}
	}

	public void TakeDamage (int amount)
	{
		if(isDead)
			return;
		int i = Random.Range(0, pain.Length);
		AudioSource.PlayClipAtPoint(pain[i], transform.position);
		currentHealth -= amount;
		if(currentHealth <= 0)
		{
			if (Application.loadedLevelName != "Police") {
				player.GetComponent<PlayerHealth> ().currentHealth += 2;
			}
			Death ();
			Score ();
		}
	}

	void Death ()
	{
		if (Application.loadedLevelName == "Police") {
			ai2.enabled = false;
		} else {
			ai.enabled = false;
		}
		isDead = true;
		enemyAudio.clip = deathClip;
		enemyAudio.Play ();
		GetComponent <NavMeshAgent> ().enabled = false;
		GetComponent <Rigidbody> ().isKinematic = true;
		isSinking = true;
		Destroy (transform.parent.gameObject, 5f);
	}

	void Score()
	{
		ScoreManager.score += scoreValue;
	}
}
