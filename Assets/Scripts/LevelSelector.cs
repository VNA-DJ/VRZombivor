using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour {

	public void Forest()
	{
		SceneManager.LoadScene ("First");
	}

	public void City()
	{
		SceneManager.LoadScene ("Second");
	}

	public void Motel()
	{
		SceneManager.LoadScene ("Third");
	}

	public void Cage()
	{
		SceneManager.LoadScene ("Cage");
	}

	public void Police()
	{
		SceneManager.LoadScene ("Police");
	}

	public void Crash()
	{
		SceneManager.LoadScene ("PlaneCrash");
	}
}
