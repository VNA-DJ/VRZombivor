using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropHealth : MonoBehaviour {

	public int startingHealth = 100;                            // The amount of health the player starts the game with.
	public int currentHealth;
	public int damage = 10;
	//public EnergyBar bar;

	private ZombieAttack attack;
	private GameObject[] guns;

	bool isDead = false;

	AudioSource crack;

	void Awake ()
	{
		guns = GameObject.FindGameObjectsWithTag ("Guns");
		crack = GetComponent<AudioSource> ();
		currentHealth = startingHealth;
	}

	public void TakeDamage (int amount)
	{
		currentHealth -= amount;
		//bar.valueCurrent = currentHealth;
		if(currentHealth <= 0 && !isDead)
		{
			Death ();
		}
	}


	public void Death ()
	{
		foreach(GameObject go in guns)
		{
			go.SetActive (false);
		}
		crack.Play();
		currentHealth = 0;
		isDead = true;
	}   
}
