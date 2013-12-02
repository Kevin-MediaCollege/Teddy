using UnityEngine;
using System.Collections;

public class WeaponAnimation:MonoBehaviour {
	private float animationLenght = 0.8f;

	private float animationTimeLeft;
	private Quaternion startRot;
	private bool animationDone;
	
	void Start() {
		startRot = transform.rotation;
	}

	void Update () {
		if(Input.GetMouseButtonDown(0)) {
			animationTimeLeft = animationLenght; 
			transform.localRotation = startRot;
			animationDone = false;
		}

		if(animationTimeLeft > 0 && animationTimeLeft < ((animationLenght / 2) * 1.9f)) {
			animationTimeLeft -= Time.deltaTime;
			transform.Rotate(0f, 0f, 7.5f);
		}

		if(animationTimeLeft > 0 && animationTimeLeft > ((animationLenght / 2) * 1.9f)) {
			animationTimeLeft -= Time.deltaTime;
			transform.Rotate(0f, 0f, -80f);
		}

		if(animationTimeLeft <= 0 && !animationDone) {
			transform.localRotation = startRot;
			animationDone = true;
		}
	}
}
