using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayButton : MonoBehaviour {

	public void Play()
	{
		SceneManager.LoadScene (1);
	}

	public void Quit()
	{
		Application.Quit();
	}

	void Update()
	{
		if (Input.GetKey (KeyCode.Escape)) {
			Application.Quit();
		}
	}
}
