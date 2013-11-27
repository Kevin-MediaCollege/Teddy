using UnityEngine;
using System.Collections;

public class CheatJolene:MonoBehaviour {
	private string[] cheat = new string[] {"j", "o", "l", "e", "n", "e"};

	public AudioClip song;

	private GameObject audio;

	private int index = 0;
	private bool started = false;
	
	void Update() {
		if(started) {
			audio = GameObject.Find("One shot audio");
			audio.transform.position = Camera.main.transform.position;
		}

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
