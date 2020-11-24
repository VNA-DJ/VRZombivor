using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

	public int startingHealth = 100;
	public int currentHealth;
	public Image damageImage;   
	public Image healthImage; 
	public float flashSpeed = 5f;
	public Color flashColourDamage = new Color(1f, 0f, 0f, 0.1f);
	Animator anim;
	public GameObject newLevel;
	GameObject guns;
	private ZombieAttack attack;
	private float damageBloodAmount = 3; 
	private float maxBloodIndication = 0.5f; 
	bool isDead = false;
	bool damaged;
	public Text text;

	void Awake ()
	{
		//StartCoroutine ("addHealth");
		anim = GetComponentInChildren<Animator> ();
		currentHealth = startingHealth;
	}


	void Update ()
	{
		
		if (currentHealth >= 100)
			currentHealth = 100;
		text.text = currentHealth.ToString();
		if(damaged)
		{
			damageImage.color = flashColourDamage;
		}
		else
		{

			damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
		}

		damaged = false;

		if (currentHealth <= 0) {
			anim.Play ("Dead");
			if (Application.loadedLevelName == "First" || Application.loadedLevelName == "Second" || Application.loadedLevelName == "Third") {
				newLevel.SetActive (false);
			}
		}
	}
		
	public void TakeDamage (int amount)
	{
		damaged = true;
		currentHealth -= amount;
		if(currentHealth <= 0 && !isDead)
		{
			currentHealth = 0;
			Death ();
		}
	}

	public void Death ()
	{
		currentHealth = 0;
		isDead = true;
		damageImage.enabled = false;
	}    
}
