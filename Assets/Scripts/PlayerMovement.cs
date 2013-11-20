using UnityEngine;
using System.Collections;

public class PlayerMovement:MonoBehaviour {
	public float walkSpeed;

	void Start () {
	
	}

	void FixedUpdate () {
		Vector2 speed = Vector2.zero;

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

		rigidbody2D.velocity = speed * Time.deltaTime;
	}
}
