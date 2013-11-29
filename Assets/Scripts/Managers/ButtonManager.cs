using UnityEngine;
using System.Collections;

public class ButtonManager:MonoBehaviour {
	public bool ExitGame = false;

	public int LoadLevel;

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
		if(!ExitGame){
			Application.LoadLevel(LoadLevel);
		} else{
			if(!Application.isEditor && !Application.isWebPlayer) {
				Application.Quit();
			}
		}
	}
}
