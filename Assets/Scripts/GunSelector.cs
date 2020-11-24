using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GunSelector : MonoBehaviour {
	public GameObject panel;
	public GameObject messageBox;

	private GameObject[] selectors;

	// Use this for initialization
	void Start () {
		messageBox.SetActive (false);
		panel.SetActive (false);
		selectors = GameObject.FindGameObjectsWithTag ("Selector");

	}
	
	// Update is called once per frame
	public void M4A1 () {
		foreach(GameObject go in selectors)
		{
			go.SetActive (false);
		}
		PlayerPrefs.SetInt ("GunSelected", 0);
		panel.SetActive (true);
	}

	public void SMG () {
		foreach(GameObject go in selectors)
		{
			go.SetActive (false);
		}
		PlayerPrefs.SetInt ("GunSelected", 1);
		panel.SetActive (true);
	}

	public void HandGun () {
		foreach(GameObject go in selectors)
		{
			go.SetActive (false);
		}
		PlayerPrefs.SetInt ("GunSelected", 2);
		panel.SetActive (true);
	}

	public void Beretta () {

		foreach(GameObject go in selectors)
		{
			go.SetActive (false);
		}
		PlayerPrefs.SetInt ("GunSelected", 3);
		panel.SetActive (true);
	}

	public void MachineGun () {
		PlayerPrefs.SetInt ("GunSelected", 4);
		panel.SetActive (true);
		foreach (GameObject go in selectors) {
			go.SetActive (false);
		}
	}

	public void Kalashnikov () {
		PlayerPrefs.SetInt ("GunSelected", 5);
		panel.SetActive (true);
		foreach (GameObject go in selectors) {
			go.SetActive (false);
		}
	}

	public void AssaultRifle () {
		PlayerPrefs.SetInt ("GunSelected", 6);
		panel.SetActive (true);
		foreach (GameObject go in selectors) {
			go.SetActive (false);
		}
	}

	public void AssaultRifle2 () {
		PlayerPrefs.SetInt ("GunSelected", 7);
		panel.SetActive (true);
		foreach (GameObject go in selectors) {
			go.SetActive (false);
		}
	}

	public void SMG2 () {
		PlayerPrefs.SetInt ("GunSelected", 8);
		panel.SetActive (true);
		foreach (GameObject go in selectors) {
			go.SetActive (false);
		}
	}

	public void Shotgun () {
		PlayerPrefs.SetInt ("GunSelected", 9);
		panel.SetActive (true);
		foreach (GameObject go in selectors) {
			go.SetActive (false);
		}
	}

	public void SawnOff () {
		PlayerPrefs.SetInt ("GunSelected", 10);
		panel.SetActive (true);
		foreach (GameObject go in selectors) {
			go.SetActive (false);
		}
	}

	public void Revolver () {
		PlayerPrefs.SetInt ("GunSelected", 11);
		panel.SetActive (true);
		foreach (GameObject go in selectors) {
			go.SetActive (false);
		}
	}

	public void MessageBox()
	{
		messageBox.SetActive (false);
		foreach(GameObject go in selectors)
		{
			go.SetActive (true);
		}
	}
}
