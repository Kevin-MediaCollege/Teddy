using UnityEngine;
using System.Collections;

public class AudioPlayer:MonoBehaviour {
	public AudioClip clip;

	void Start() {
		AudioManager manager = GameObject.Find("SoundManager").GetComponent<AudioManager>();

		if(!manager.IsBackgroundAudioPlaying()) {
			manager.PlayBackgroundAudio(clip);
		}
	}
}
