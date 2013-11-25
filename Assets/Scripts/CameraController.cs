using UnityEngine;
using System.Collections;

public class CameraController:MonoBehaviour {
	public Transform target;

	public float distance = 0.0f;
	private float height = 3.0f;
	private float damping = 5.0f;

	public bool shake =false;
	private float shakeTime = 0.0f;
	public float maxShakeTime = 0.3f;
	private Vector3 beforeShakeposs;
	public float shakePower = 0.2f;
	void Start(){
		shakeTime=maxShakeTime;
	}

	void FixedUpdate() {
		transform.position=beforeShakeposs;

		if(target != null){
			Vector3 wantedPosition;
			wantedPosition = target.TransformPoint(0, height - 2, distance);
			transform.position = Vector3.Lerp (transform.position, wantedPosition, Time.deltaTime * damping);
		}

		beforeShakeposs = transform.position;
		if(shake){

			if(shakeTime>0){
				transform.position += new Vector3(1,0,0)*Random.Range(-shakePower,shakePower);
				shakeTime-=Time.deltaTime;
			}
			else
			{
				shake=false;
				shakeTime=maxShakeTime;
			}
		}
	}
}