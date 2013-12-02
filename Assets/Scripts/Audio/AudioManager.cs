using UnityEngine;
using System.Collections;

public class AudioManager:MonoBehaviour {
	public bool musicEnabled = true;
	public bool sfxEnabled = true;

	private AudioSource backgroundAudio;

	void Start() {
		DontDestroyOnLoad(gameObject);

		backgroundAudio = GetComponent<AudioSource>();

		Application.LoadLevel(1);
	}

	void Update() {
		if(!musicEnabled) {
			if(backgroundAudio.isPlaying) {
				backgroundAudio.Stop();
			}
		} else {
			if(backgroundAudio != null) {
				if(!backgroundAudio.isPlaying) {
					backgroundAudio.Play();
				}
			}
		}
	}

	public void PlayBackgroundAudio(AudioClip audio) {
		if(musicEnabled){
			if(backgroundAudio.isPlaying) {
				backgroundAudio.Stop();
			}

			backgroundAudio.clip = audio;

			backgroundAudio.Play();
		}
	}

	public void StopBackgroundAudio() {
		if(backgroundAudio.isPlaying) {
			backgroundAudio.Stop();
		}
	}

	public void StopAndRemoveBackgroundAudio() {
		if(backgroundAudio.isPlaying) {
			backgroundAudio.Stop();
		}

		backgroundAudio.clip = null;
	}

	public void PlaySfx(AudioClip audio, Vector3 position) {
		if(sfxEnabled) {
			AudioSource.PlayClipAtPoint(audio, position);
		}
	}

	public bool IsBackgroundAudioPlaying() {
		return backgroundAudio.isPlaying;
	}
}
