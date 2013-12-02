using UnityEngine;
using System.Collections;

public class PlayerMovement:MonoBehaviour {
	public float walkSpeed;

	void Start() {
		ScoreManager sm = GameObject.Find("Score Manager").GetComponent<ScoreManager>();

		if(sm.hasSpawned) {
			transform.position = new Vector3(-12.5f, 5.5f, 0);
			sm.hasSpawned = false;
		}
	}

	void FixedUpdate () {
		Vector3 speed = Vector3.zero;
		Vector3 mousePos = Input.mousePosition;
		Vector3 position = Camera.main.WorldToScreenPoint(transform.position);

		mousePos.z = 5.23f;
		mousePos.x = mousePos.x - position.x;
		mousePos.y = mousePos.y - position.y;

		transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg - 90));

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

		if(speed != Vector3.zero) {
			GetComponent<Animator>().Play("PlayerWalk");
		} else {
			GetComponent<Animator>().Play("PlayerIdle");
		}
	}

	void OnTriggerEnter(Collider collider) {
		if(collider.name == "Next Level") {
			Application.LoadLevel(6);
		} else if(collider.name == "Prev Level") {
			GameObject.Find("Score Manager").GetComponent<ScoreManager>().hasSpawned = true;
			Application.LoadLevel(5);
		}
	}
}
