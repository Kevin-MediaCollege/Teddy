using UnityEngine;
using System.Collections;

public class CheatNegative:MonoBehaviour {
	public Sprite negative;

	private string[] lights = new string[] {"n", "e", "g", "a", "t", "i", "v", "e"};

	private Sprite normal;

	private int index = 0;
	private bool enabled;

	void Start() {
		normal = GameObject.Find("Level 1").GetComponent<SpriteRenderer>().sprite;
	}

	void Update() {
		if(Input.anyKeyDown) {
			if(Input.GetKeyDown(lights[index])) {
				index++;
			} else {
				index = 0;
			}
		}	
		
		if(index == lights.Length) {
			SpriteRenderer sprite = GameObject.Find("Level 1").GetComponent<SpriteRenderer>();

			if(!enabled) {
				sprite.sprite = negative;
			} else {
				sprite.sprite = normal;
			}

			enabled = !enabled;
			index = 0;
		}
	}
}
