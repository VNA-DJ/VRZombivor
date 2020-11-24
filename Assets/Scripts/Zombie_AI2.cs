using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie_AI2 : MonoBehaviour {

	public float distance;
	public AudioClip[] moaning;
	public float sec = 3;

	private Transform prop;
	private PropHealth propHealth;
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
		prop = GameObject.FindGameObjectWithTag ("Prop").transform;
		propHealth = prop.GetComponent<PropHealth> ();
		enemyHealth = GetComponentInChildren<EnemyHealth> ();
		anim = GetComponent<Animator> ();
		nav = GetComponent<NavMeshAgent> ();
	}

	// Update is called once per frame
	void Update () {
		nav.SetDestination (prop.position);
		if (play) {
			StartCoroutine ("Sound");
		}
		if (Vector3.Distance (prop.position, transform.position) <= distance) {
			Debug.Log ("Attacking");	
			anim.SetTrigger ("Attack");
		} else {
			anim.Play ("Zombie_Walk");
		}
	} 


	IEnumerator Sound()
	{
		play = false;
		sum += sec;
		int i = Random.Range(0, moaning.Length);
		AudioSource.PlayClipAtPoint(moaning[i], transform.position);
		yield return new WaitForSeconds (sec);
		play = true;
	}
}
