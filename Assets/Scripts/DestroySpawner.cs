using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySpawner : MonoBehaviour {

	void OnTriggerEnter(Collider coll){
		if (coll.tag == "Player")
			Destroy(GameObject.Find("Spawner"));
	}
}
