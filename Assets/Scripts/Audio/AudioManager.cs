using UnityEngine;
using System.Collections;

public class AudioManager:MonoBehaviour {
	private AudioSource backgroundAudio;
	private AudioSource foregroundAudio;

	void Start() {
		DontDestroyOnLoad(gameObject);

		backgroundAudio = GetComponent<AudioSource>();
		foregroundAudio = GetComponent<AudioSource>();

		Application.LoadLevel(1);
	}

	public void PlayBackgroundAudio(AudioClip audio) {
		if(backgroundAudio.isPlaying) {
			backgroundAudio.Stop();
		}

		backgroundAudio.clip = audio;

		backgroundAudio.Play();
	}

	public void StopBackgroundAudio() {
		if(backgroundAudio.isPlaying) {
			backgroundAudio.Stop();
		}
	}

	public bool IsBackgroundAudioPlaying() {
		return backgroundAudio.isPlaying;
	}
}
