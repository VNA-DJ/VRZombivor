using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SpawningEnemies : MonoBehaviour {

	//public PlayerHealth playerHealth;
	public int limit;
	public GameObject[] enemy;
	public float spawnTime = 3f; 
	public Transform[] spawnPoints;
	public int prefabLimit = 1;

	private GameObject length;
	private int prefabCount;

	void Start ()
	{
		length = GameObject.FindGameObjectWithTag ("Enemy");
		InvokeRepeating ("Spawn", spawnTime, spawnTime);
	}

	void Spawn ()
	{
		if (GameObject.FindGameObjectsWithTag ("Enemy").Length < limit) {
			prefabCount++;
			if (spawnTime > 1.5f)
				spawnTime -= 0.01f;
			int i = 0;
			i = Random.Range (0, enemy.Length);
			/*if(playerHealth.currentHealth <= 0f)
		{
			return;
		}*/
			int spawnPointIndex = Random.Range (0, spawnPoints.Length);
			Instantiate (enemy [i], spawnPoints [spawnPointIndex].position, spawnPoints [spawnPointIndex].rotation);
		}
	}

	void Update()
	{
		if (prefabCount >= prefabLimit) {
			CancelInvoke ("Spawn");
		}
		if (Input.GetButton("Back") || Input.GetKey(KeyCode.Escape))
		{
			SceneManager.LoadScene ("Menu");
		} 
	}
}