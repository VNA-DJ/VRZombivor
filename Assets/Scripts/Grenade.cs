using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour {

	/*public Rigidbody grenade;
	Transform mc;

	Rigidbody rb;


	void Start()
	{
		rb = GetComponent<Rigidbody> ();
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (2)) {
			rb = Instantiate (grenade, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
			rb.velocity = transform.TransformDirection (Vector3.forward * 20);
		
		}
	}*/

	public GameObject grenade;
	//the point to throw the grenade
	public Transform ThrowPoint;
	//the amount of force we want to pust it forward
	public float ForwardThrowForce;
	//the amount of force we want to push it up
	public float UpwardThrowForce;

	//if you press the right mouse button
	//creates the grenade at the throw point
	//turns it on
	//then adds the force to push it up and forward
	//note you must use AddRelativeForce this adds force to the grenade in non world space
	void Update () {
		if(Input.GetMouseButtonDown(2)){
			GameObject expode;
			expode = Instantiate(grenade,transform.position,transform.rotation);
			expode.transform.position=ThrowPoint.transform.position;
			expode.transform.rotation=ThrowPoint.transform.rotation;
			expode.SetActive(true);
			expode.GetComponent<Rigidbody>().AddRelativeForce(0,UpwardThrowForce,ForwardThrowForce,ForceMode.Impulse);
		}
	}
}
