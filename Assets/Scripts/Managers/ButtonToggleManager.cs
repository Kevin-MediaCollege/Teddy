using UnityEngine;
using System.Collections;

public class ButtonToggleManager:MonoBehaviour {
	public int id;
	public bool enabled;
	
	public bool hasRenderer;
	
	private Color newColor;
	private Color originalColor;

	private Vector3 orignalPos;
	
	void Start(){
		if(hasRenderer){
			newColor = new Color(0.9f, 0.4f, 0.9f);
			originalColor = gameObject.renderer.material.color;
			orignalPos = transform.position;
		}
	}
	
	void OnMouseOver() {
		if(hasRenderer){
			renderer.material.color = newColor;
			transform.position = orignalPos + new Vector3(0, 0.05f, 0);
		}
	}
	
	void OnMouseExit() {
		if(hasRenderer){
			renderer.material.color = originalColor;
			transform.position = orignalPos;
		}
	}
	
	void OnMouseDown() {
		if(GameObject.Find("Sound Manager")) {
			AudioManager audioManager = GameObject.Find("Sound Manager").GetComponent<AudioManager>();

			switch(id) {
			case 0:
				audioManager.musicEnabled = enabled;
				break;
			case 1:
				audioManager.sfxEnabled = enabled;
				break;
			}
		}
	}
}
