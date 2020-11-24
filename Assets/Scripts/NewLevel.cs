using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewLevel : MonoBehaviour {

	NewLevelManager Hud;
	void Awake ()
	{
		Hud = GameObject.Find("HUDCanvas").GetComponent<NewLevelManager> ();
		// Set up the reference.
	}
		
	void OnTriggerEnter(Collider coll){
		Hud.end = true;
		if (Application.loadedLevel == 2)
			PlayerPrefs.SetInt ("level2", 1);

		if (Application.loadedLevel == 3)
			PlayerPrefs.SetInt ("level3", 1);

		if (Application.loadedLevel == 4)
			PlayerPrefs.SetInt ("level4", 1);
	}


}
