using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class zombie_ai : MonoBehaviour {

	public float distance;
	public AudioClip[] moaning;
	public float sec = 3;

	private Transform player;
	private PlayerHealth playerHealth;
	private EnemyHealth enemyHealth;
	private ZombieAttack attack;
	private NavMeshAgent nav;
	private Animator anim;
	private float timer;
	private float sum;

	bool play = true;

	AudioSource moanAudio;

	void Start () {
		moanAudio = GetComponent<AudioSource> ();
		player = GameObject.FindGameObjectWithTag("Player").transform;
		enemyHealth = GetComponentInChildren<EnemyHealth> ();
		playerHealth = player.GetComponent<PlayerHealth> ();
		anim = GetComponent<Animator> ();
		nav = GetComponent<NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (play) {
			StartCoroutine ("Sound");
		}
		if (enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0) {
			nav.SetDestination (player.position);
		} else {
			nav.enabled = false;
			anim.SetTrigger ("Eating");
		}

		if (Vector3.Distance (player.position, transform.position) <= distance) {
			Debug.Log ("Attacking");	
			anim.SetTrigger ("Attack");
		}
		else {
			anim.Play ("Zombie_Walk");
		}

	}

	IEnumerator Sound()
	{
		play = false;
		sum += sec;
		int i = Random.Range(0, moaning.Length);
		Debug.Log ("caldi");
		AudioSource.PlayClipAtPoint(moaning[i], transform.position);
		yield return new WaitForSeconds (sec);
		play = true;
	}

}
