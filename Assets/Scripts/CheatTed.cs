using UnityEngine;
using System.Collections;

public class CheatTed:MonoBehaviour {
	public Sprite texture;

	private string[] cheat = new string[] {"t", "e", "d"};
	
	private int index = 0;
	
	void Update() {
		if(Input.anyKeyDown) {
			if(Input.GetKeyDown(cheat[index])) {
				index++;
			} else {
				index = 0;
			}
		}	
		
		if(index == cheat.Length) {
			GameObject player = GameObject.Find("Player");

			player.GetComponent<SpriteRenderer>().sprite = texture;
			player.GetComponent<PlayerMovement>().walkAnimation.StopPlayback();

			index = 0;
		}
	}
}
