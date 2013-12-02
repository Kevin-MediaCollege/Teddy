using UnityEngine;
using System.Collections;

public class KeyManager:MonoBehaviour {
	public AudioClip clip;

	void Update() {
		if(Input.GetKeyDown(KeyCode.Escape)) {
			GameObject.Find("Sound Manager").GetComponent<AudioManager>().PlayBackgroundAudio(clip);

			Application.LoadLevel(1);
		}
	}
}
