using UnityEngine;
using System.Collections;

public class Intro:MonoBehaviour {
	public AudioClip[] sounds;

	public float minDelay;
	public float maxDelay;

	private GUIText line;
	private string text;

	private int curLine = 0;

	void Start() {
		if(GameObject.Find("Sound Manager")) {
			GameObject.Find("Sound Manager").GetComponent<AudioManager>().StopBackgroundAudio();
		}

		NextLine();
	}

	void Update() {
		if(Input.GetMouseButtonDown(0)) {
			Application.LoadLevel(5);
		}
	}

	void NextLine() {
		float wait = 0;

		if(curLine > 8) {
			return;
		} else if(curLine == 2) {
			wait = 1;
		} else if(curLine == 6 || curLine == 7 || curLine == 8) {
			wait = 2;
		}

		line = GameObject.Find("Line " + curLine).GetComponent<GUIText>();

		text = line.text;

		line.text = "";
		line.enabled = true;

		curLine++;

		StartCoroutine(WriteText(wait));
	}

	IEnumerator WriteText(float wait) {
		yield return new WaitForSeconds(wait);

		foreach(char letter in text.ToCharArray()) {
			line.text += letter;

			audio.PlayOneShot(sounds[Random.Range(0, sounds.Length)]);
			yield return 0;

			yield return new WaitForSeconds(Random.Range(minDelay, maxDelay));
		}

		NextLine();
	}
}
