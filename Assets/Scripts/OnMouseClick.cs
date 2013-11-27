using UnityEngine;
using System.Collections;

public class OnMouseClick:MonoBehaviour {
	public int LoadLevel;

	private bool isClicked;
	
	void OnMouseDown() {
		isClicked = true;
	}
	
	void OnMouseUp() {
		isClicked = false;

		Application.LoadLevel(LoadLevel);
	}
}
