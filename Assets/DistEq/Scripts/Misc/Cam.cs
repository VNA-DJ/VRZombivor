using UnityEngine;
using System.Collections;

public class Cam : MonoBehaviour {
    GameObject AudioSource;
    public float speed = 10f;
	// Use this for initialization
	void Start () {
        speed = -speed;
        AudioSource = GameObject.Find("Turret");
    }
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(AudioSource.transform);
        if(transform.position.z <= -100 || transform.position.z >= 300)
        {
            speed = -speed;
        }
        transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.World);
	}
}
