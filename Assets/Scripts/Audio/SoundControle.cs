using UnityEngine;
using System.Collections;

public class SoundControle : MonoBehaviour {
	
	private AudioManager manager;
	
	// Use this for initialization
	void Start () {
		manager = GameObject.Find("Sound Manager").GetComponent<AudioManager>();
		gameObject.SetActive(manager.playSFX);
	}
}
