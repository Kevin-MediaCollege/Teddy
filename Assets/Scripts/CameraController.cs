using UnityEngine;
using System.Collections;

public class CameraController:MonoBehaviour {
	public Transform target;

	public float distance = 0.0f;
	private float height = 3.0f;
	private float damping = 5.0f;
	
	void FixedUpdate() {
		if(target != null){
			Vector3 wantedPosition;
			wantedPosition = target.TransformPoint(0, height - 2, distance);
			transform.position = Vector3.Lerp (transform.position, wantedPosition, Time.deltaTime * damping);
		}
	}
}