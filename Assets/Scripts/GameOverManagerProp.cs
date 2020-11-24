using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOverManagerProp : MonoBehaviour {

	public PropHealth propHealth;       // Reference to the player's health.
	public float restartDelay = 5f;         // Time to wait before restarting the level
	public GameObject gunText;

	Animator anim;                          // Reference to the animator component.
	float restartTimer;                     // Timer to count up to restarting the level


	void Awake ()
	{
		// Set up the reference.
		anim = GetComponent <Animator> ();
	}


	void Update ()
	{
		if (propHealth.currentHealth <= 0) {
			// ... tell the animator the game is over.
			anim.SetTrigger ("GameOver");
			// .. increment a timer to count up to restarting.
			restartTimer += Time.deltaTime;
			gunText.SetActive (false);
			// .. if it reaches the restart delay...
			if (restartTimer >= restartDelay) {
				// .. then reload the currently loaded level.
				SceneManager.LoadScene("Menu");
			}
		}
	}

}
