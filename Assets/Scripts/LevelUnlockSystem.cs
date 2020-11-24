using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
public class LevelUnlockSystem : MonoBehaviour {

	public Button[] leveller;

	// Use this for initialization
	void Start () {
		if (PlayerPrefs.GetInt ("level1") == 0)
			leveller [0].interactable = true;
		else
			leveller [0].interactable = true;

		if (PlayerPrefs.GetInt ("level2") == 1)
			leveller [1].interactable = true;
		else
			leveller [1].interactable = false;

		if (PlayerPrefs.GetInt ("level3") == 1)
			leveller [2].interactable = true;
		else
			leveller [2].interactable = false;
		
		if (PlayerPrefs.GetInt ("level4") == 1)
			leveller [3].interactable = true;
		else
			leveller [3].interactable = false;
		
		if (PlayerPrefs.GetInt ("level5") == 1)
			leveller [4].interactable = true;
		else
			leveller [4].interactable = false;
		
		if (PlayerPrefs.GetInt ("level6") == 1)
			leveller [5].interactable = true;
		else
			leveller [5].interactable = false;
	}
	
	// Update is called once per frame
	public void levelAc(int level)
	{
			SceneManager.LoadScene (2);
		if (level == 3) {
			SceneManager.LoadScene (3);
		}
		 else {
			Debug.Log ("açık değil.");
		}
		if (level == 4) {
			SceneManager.LoadScene (4);
		}
		else {
			Debug.Log ("açık değil.");
		}
		if (level == 5) {
			SceneManager.LoadScene (5);
		}
		else {
			Debug.Log ("açık değil.");
		}

		if (level == 6) {
			SceneManager.LoadScene (6);
		}
		else {
			Debug.Log ("açık değil.");
		}

		if (level == 7) {
			SceneManager.LoadScene (7);
		}
		else {
			Debug.Log ("açık değil.");
		}
	}
}
