using UnityEngine;
using System.Collections;

public class PlayerMovement:MonoBehaviour {
	public float _walk_speed;

	void Start () {
	
	}

	void FixedUpdate () {
		Vector3 _speed = Vector3.zero;
		Vector3 _mousePos = Input._mouse_position;
		Vector3 _position = Camera.main.WorldToScreenPoint(transform._position);

		_mousePos.z = 5.23f;
		_mousePos.x = _mousePos.x - _position.x;
		_mousePos.y = _mousePos.y - _position.y;

		transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(_mousePos.y, _mousePos.x) * Mathf.Rad2Deg - 90));

		if(Input.GetKey("w")) {
			_speed.y = _walk_speed;
		} else if(Input.GetKey("s")) {
			_speed.y = -_walk_speed;
		}

		if(Input.GetKey("d")) {
			_speed.x = _walk_speed;
		} else if(Input.GetKey("a")) {
			_speed.x = -_walk_speed;
		}

		rigidbody.velocity = _speed * Time.deltaTime;
	}
}
