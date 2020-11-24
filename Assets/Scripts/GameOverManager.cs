using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOverManager : MonoBehaviour {

	public PlayerHealth playerHealth;       // Reference to the player's health.
	public float restartDelay = 5f;         // Time to wait before restarting the level
	public GameObject gunText;
	public GameObject healthBar;
	Animator anim;                          // Reference to the animator component.
	float restartTimer;                     // Timer to count up to restarting the level

	void Awake ()
	{
		// Set up the reference.
		anim = GetComponent <Animator> ();
	}


	void Update ()
	{
		if (playerHealth.currentHealth <= 0) {
					// ... tell the animator the game is over.
					anim.SetTrigger ("GameOver");
					gunText.SetActive (false);
					// .. increment a timer to count up to restarting.
					restartTimer += Time.deltaTime;
					healthBar.SetActive (false);
					// .. if it reaches the restart delay...
					if (restartTimer >= restartDelay) {
						// .. then reload the currently loaded level.
					SceneManager.LoadScene(0);
					}
		}
	}

}
	
