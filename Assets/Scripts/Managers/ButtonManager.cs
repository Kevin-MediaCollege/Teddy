using UnityEngine;
using System.Collections;

public class ButtonManager:MonoBehaviour {
	public bool ExitGame = false;

	public int LoadLevel;

	public bool hasRenderer;

	private Color newColor;
	private Color originalColor;
	private Vector3 orignalPos;

	void Start(){
		if(hasRenderer){
			newColor = new Color(0.9f, 0.4f, 0.9f);
			originalColor = gameObject.renderer.material.color;
			orignalPos=transform.position;
		}
	}

	void OnMouseOver() {
		if(hasRenderer){
			renderer.material.color = newColor;
			transform.position=orignalPos+new Vector3(0,0.05f);
		}
	}

	void OnMouseExit() {
		if(hasRenderer){
			renderer.material.color = originalColor;
			transform.position=orignalPos;
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
