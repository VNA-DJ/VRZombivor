using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class CrosshairDisable : MonoBehaviour {

	public Image img;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton ("Fire2")) {
			img.enabled = false;
		} else {
			img.enabled = true;
		}
	}
}
