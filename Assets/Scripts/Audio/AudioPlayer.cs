using UnityEngine;
using System.Collections;

public class AudioPlayer:MonoBehaviour {
	public AudioClip clip;
	public bool schedule;
	public bool endCurrent;

	private AudioManager manager;

	void Start() {
		if(GameObject.Find("Sound Manager") != null) {
			manager = GameObject.Find("Sound Manager").GetComponent<AudioManager>();

			if(endCurrent) {
				manager.StopBackgroundAudio();
			}

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
