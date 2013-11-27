using UnityEngine;
using System.Collections;

public class OnMouseClick : MonoBehaviour {

	private bool wasClicked;
	public int LoadLevel;
	
	void OnMouseDown() {
		wasClicked = true;
	}
	
	void OnMouseUp() {
		wasClicked = false;
		Application.LoadLevel(LoadLevel);
	}
	/*
	void OnMouseEnter() {
		if (wasClicked) {
			Activate();
		}
	}
	
	void OnMouseExit() {
		Deactivate();
	}
	
	void Activate() {
		renderer.material.color = Color.red;
	}
	
	void Deactivate() {
		renderer.material.color = Color.white;
	}*/
}
