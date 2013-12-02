using UnityEngine;
using System.Collections;

public class Intro:MonoBehaviour {
	public AudioClip[] sounds;

	public float minDelay;
	public float maxDelay;
	
	private string text;
	private GUIText line;
	private int curLine = 0;

	void Start() {
		NextLine();
	}

	void Update() {
		if(Input.GetMouseButtonDown(0)) {
			Application.LoadLevel(5);
		}
	}

	void NextLine() {
		if(curLine < 8) {
			line = GameObject.Find("Line " + curLine).GetComponent<GUIText>();
		} else if(curLine == 8) {
			line = GameObject.Find("Continue").GetComponent<GUIText>();
		} else {
			return;
		}

		text = line.text;
		line.text = "";
		line.enabled = true;
		
		curLine++;
		
		StartCoroutine(WriteText());
	}

	IEnumerator WriteText() {
		foreach(char letter in text.ToCharArray()) {
			line.text += letter;

			audio.PlayOneShot(sounds[Random.Range(0, sounds.Length)]);
			yield return 0;

			yield return new WaitForSeconds(Random.Range(minDelay, maxDelay));
		}

		NextLine();
	}
}
