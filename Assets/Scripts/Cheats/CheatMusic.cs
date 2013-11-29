using UnityEngine;
using System.Collections;

public class CheatMusic:MonoBehaviour {
	public string[] cheat;

	public AudioClip clip;

	private AudioManager manager;

	private int index = 0;

	void Start() {
		manager = GameObject.Find("SoundManager").GetComponent<AudioManager>();
	}
	
	void Update() {
		if(Input.anyKeyDown) {
			if(Input.GetKeyDown(cheat[index])) {
				index++;
			} else {
				index = 0;
			}
		}	
		
		if(index == cheat.Length) {
			manager.StopBackgroundAudio();
			manager.PlayBackgroundAudio(clip);

			index = 0;
		}
	}
}
