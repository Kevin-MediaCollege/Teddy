using UnityEngine;
using System.Collections;

public class OnMouseClick:MonoBehaviour {
	public int LoadLevel;
	public bool ExitGame = false;
	public bool hasRenderer;

	private Color newcolor;
	private Color origine;

	void Start(){
		if(hasRenderer){
			newcolor = new Color(0.9f,0.4f,0.4f);
			origine = gameObject.renderer.material.color;
		}
	}
	void OnMouseOver() {
		if(hasRenderer){
			renderer.material.color = newcolor;
		}
	}

	void OnMouseExit()
	{
		if(hasRenderer){
			renderer.material.color = origine;
		}
	}

	void OnMouseDown() {
		
		if(!ExitGame){
			Application.LoadLevel(LoadLevel);
		}
		else{
			if(!Application.isEditor && !Application.isWebPlayer)
				Application.CancelQuit();
		}
	}
}
