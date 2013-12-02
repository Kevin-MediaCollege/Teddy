using UnityEngine;
using System.Collections;

public class MusicToggle : MonoBehaviour {

	public bool state = false;
	private AudioManager manager;

	private Color newColor;
	private Color originalColor;

	// Use this for initialization
	void Start () {
		manager = GameObject.Find("Sound Manager").GetComponent<AudioManager>();

		state = manager.playMusic;
		newColor = new Color(0.9f, 0.4f, 0.4f);
		originalColor = gameObject.renderer.material.color;
	}
	
	void OnMouseOver() {
		if(state){
			renderer.material.color = originalColor;
		}
		else{
			renderer.material.color = newColor;
		}
	}

	void OnMouseExit() {
		if(state){
			renderer.material.color = newColor;
		}
		else{
			renderer.material.color = originalColor;
		}
	}

		void OnMouseDown() {
		state=!state;
		manager.playMusic=state;
		if(!state){
			manager.StopBackgroundAudio();
		}
	}
}
