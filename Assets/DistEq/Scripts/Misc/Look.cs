using UnityEngine;
using System.Collections;

public class Look : MonoBehaviour {
    AudioListener AudioListener;
    // Use this for initialization
    void Start () {
        AudioListener = FindObjectOfType<AudioListener>();
    }
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(AudioListener.transform);
	}
}
