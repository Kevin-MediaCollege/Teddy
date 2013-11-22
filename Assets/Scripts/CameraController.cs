using UnityEngine;
using System.Collections;

public class CameraController:MonoBehaviour {
	public Transform _target;

	public float _distance = 0.0f;
	private float _height = 3.0f;
	private float _damping = 5.0f;
	
	void FixedUpdate() {
		if(_target != null){
			Vector3 wantedPosition;
			wantedPosition = _target.TransformPoint(0, _height - 2, _distance);
			transform.position = Vector3.Lerp (transform.position, wantedPosition, Time.deltaTime * _damping);
		}
	}
}