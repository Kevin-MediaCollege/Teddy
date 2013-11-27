using UnityEngine;
using System.Collections;

public class CheatFilter:MonoBehaviour {
	public Sprite negative;
	public Sprite blackWhite;

	private string[] cheat = new string[] {"f", "i", "l", "t", "e", "r"};

	private Sprite normal;

	private int index = 0;
	private int state;

	void Start() {
		normal = GameObject.Find("Level 1").GetComponent<SpriteRenderer>().sprite;
	}

	void Update() {
		if(Input.anyKeyDown) {
			if(Input.GetKeyDown(cheat[index])) {
				index++;
			} else {
				index = 0;
			}
		}	
		
		if(index == cheat.Length) {
			SpriteRenderer sprite = GameObject.Find("Level 1").GetComponent<SpriteRenderer>();

			switch(state) {
			case 0:
				sprite.sprite = negative;
				state = 1;
				break;
			case 1:
				sprite.sprite = blackWhite;
				state = 2;
				break;
			case 2:
				sprite.sprite = normal;
				state = 0;
				break;
			}

			index = 0;
		}
	}
}
