using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreText : MonoBehaviour {

	public static int score;

	Text text;
	// Use this for initialization
	void Start () {
		score = PlayerPrefs.GetInt ("score");
		text = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		text.text = "ZOMBIES: " + score;

	}
		
}
