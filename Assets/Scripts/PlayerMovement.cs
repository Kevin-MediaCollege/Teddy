using UnityEngine;
using System.Collections;

public class PlayerMovement:MonoBehaviour {
	public float walkSpeed;

	void Start () {
	
	}

	void FixedUpdate () {
		Vector3 speed = Vector3.zero;

		if(Input.GetKey("w")) {
			speed.y = walkSpeed;
		} else if(Input.GetKey("s")) {
			speed.y = -walkSpeed;
		}

		if(Input.GetKey("d")) {
			speed.x = walkSpeed;
		} else if(Input.GetKey("a")) {
			speed.x = -walkSpeed;
		}

		rigidbody.velocity = speed * Time.deltaTime;
	}
}
