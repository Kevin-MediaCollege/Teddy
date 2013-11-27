using UnityEngine;
using System.Collections;

public class CheatTralala:MonoBehaviour {
	private string[] cheat = new string[] {"t", "r", "a", "l", "a", "l", "a", "l", "a"};
	
	public AudioClip song;
	
	private GameObject audio;
	
	private int index = 0;
	private bool started = false;
	
	void Update() {
		if(Input.anyKeyDown) {
			if(Input.GetKeyDown(cheat[index])) {
				index++;
			} else {
				index = 0;
			}
		}	
		
		if(index == cheat.Length) {
			if(!started) {
				AudioSource.PlayClipAtPoint(song, Camera.main.transform.position, 1);
			}
			
			index = 0;
		}
	}
}
