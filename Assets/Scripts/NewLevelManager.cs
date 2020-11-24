using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NewLevelManager : MonoBehaviour {
	public int level;
	public float restartDelay = 5f;         // Time to wait before restarting the level
	public GameObject gunText;
	public GameObject healthBar;
	public bool end = false;

	GameOverManager Hud;
	Animator anim;                    // Reference to the animator component.
	float restartTimer;                     // Timer to count up to restarting the level


	void Awake ()
	{
		Hud = GameObject.Find("HUDCanvas").GetComponent<GameOverManager> ();
		// Set up the reference.
		anim = GetComponent <Animator> ();
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update()
	{
		if (end) {
			anim.Play ("LevelComp");
			gunText.SetActive (false);
			healthBar.SetActive (false);
			// .. increment a timer to count up to restarting.
			restartTimer += Time.deltaTime;
			// .. if it reaches the restart delay...
			if (restartTimer >= restartDelay) {
				// .. then reload the currently loaded level.
				SceneManager.LoadScene (level);
			}
		}
	}
}
