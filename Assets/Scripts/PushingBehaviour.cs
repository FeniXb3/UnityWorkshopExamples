using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushingBehaviour : MonoBehaviour {

	// Use this for initialization
	void Start() {
		var rigidBody = GetComponent<Rigidbody>();
		var forceVector = new Vector3(0f, 0f, 10f);

		rigidBody.AddForce(forceVector, ForceMode.Impulse);		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
