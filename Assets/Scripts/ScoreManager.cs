using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ScoreManager : MonoBehaviour {

	public static int score;        // The player's score.
	public int limit;

	NewLevelManager Hud;
	Text text;                      // Reference to the Text component.


	void Awake ()
	{
		Hud = GameObject.Find("HUDCanvas").GetComponent<NewLevelManager> ();
		// Set up the reference.
		text = GetComponent <Text> ();
		score = 0;
	}


	void Update ()
	{
		// Set the displayed text to be the word "Score" followed by the score value.
		text.text = "ZOMBIES: " + score;
		if (score == limit) {
			Hud.end = true;
			if (Application.loadedLevel == 5)
				PlayerPrefs.SetInt ("level5", 1);
			
			if (Application.loadedLevel == 6)
				PlayerPrefs.SetInt ("level6", 1);
		}
	}
}
