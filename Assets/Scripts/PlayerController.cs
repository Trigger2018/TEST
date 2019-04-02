using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public Rigidbody theRB;
	public float movementSpeed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		theRB.velocity = new Vector3 (Input.GetAxisRaw("Horizontal")*movementSpeed, Input.GetAxisRaw("Vertical")*movementSpeed, 0f);
	}
}
