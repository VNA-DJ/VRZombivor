using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireDamage : MonoBehaviour {
	private PlayerHealth playerHealth;  
	private GameObject player;   

	float timeBetweenAttacks = 0.5f;
	float timer;
	int damage = 5;
	bool playerInRange;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = player.GetComponent <PlayerHealth> ();
	}

	void OnTriggerEnter (Collider other)
	{
		if(other.gameObject == player)
		{
			playerInRange = true;
		}
	}

	void OnTriggerExit (Collider other)
	{
		if(other.gameObject == player)
		{
			playerInRange = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if(timer >= timeBetweenAttacks && playerInRange)
			Burn ();
	}



	void Burn()
	{
		timer = 0;
		playerHealth.TakeDamage (damage);
	}
}
