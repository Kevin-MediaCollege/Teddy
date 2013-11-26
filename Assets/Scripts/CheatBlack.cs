using UnityEngine;
using System.Collections;

public class CheatBlack:MonoBehaviour {
	public Sprite black;
	
	private string[] lights = new string[] {"b", "l", "a", "c", "k"};
	
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
				sprite.sprite = black;
			} else {
				sprite.sprite = normal;
			}
			
			enabled = !enabled;
			index = 0;
		}
	}
}
