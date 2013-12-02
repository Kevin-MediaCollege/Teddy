using UnityEngine;
using System.Collections;

public class ButtonToggleManager:MonoBehaviour {
	public int id;
	public bool enabled;
	
	public bool hasRenderer;
	
	private Color newColor;
	private Color originalColor;
	
	void Start(){
		if(hasRenderer){
			newColor = new Color(0.9f, 0.4f, 0.4f);
			originalColor = gameObject.renderer.material.color;
		}
	}
	
	void OnMouseOver() {
		if(hasRenderer){
			renderer.material.color = newColor;
		}
	}
	
	void OnMouseExit() {
		if(hasRenderer){
			renderer.material.color = originalColor;
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
