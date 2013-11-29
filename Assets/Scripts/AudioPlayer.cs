using UnityEngine;
using System.Collections;

public class AudioPlayer:MonoBehaviour {
	public AudioClip clip;
	public bool schedule;

	private AudioManager manager;

	void Start() {
		if(GameObject.Find("SoundManager") != null) {
			manager = GameObject.Find("SoundManager").GetComponent<AudioManager>();

			if(!manager.IsBackgroundAudioPlaying()) {
				manager.PlayBackgroundAudio(clip);
			}
		}
	}

	void Update() {
		if(schedule && manager != null) {
			if(!manager.IsBackgroundAudioPlaying()) {
				manager.PlayBackgroundAudio(clip);
				schedule = false;
			}
		}
	}
}
