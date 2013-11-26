using UnityEngine;
using System.Collections;

public class PlayerMovement:MonoBehaviour {
	public float walkSpeed;

	private Animator walkAnimation;

	void Start () {
		walkAnimation = GameObject.Find("player").GetComponent<Animator>();
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

		/*if(speed != Vector3.zero && !walkAnimation.animation.isPlaying) {
			Debug.Log ("yolo");
			walkAnimation.StartPlayback();
		} else if(speed == Vector3.zero && walkAnimation.animation.isPlaying) {
			Debug.Log ("swag");
			walkAnimation.StopPlayback();
		}*/
	}
}
