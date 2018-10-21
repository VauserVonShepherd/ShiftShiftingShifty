using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour {
    public float turnSpeed = 1;
	
	// Update is called once per frame
	void FixedUpdate () {
        GetComponent<Rigidbody>().AddTorque(new Vector3(0, 0, turnSpeed));
    }
}
