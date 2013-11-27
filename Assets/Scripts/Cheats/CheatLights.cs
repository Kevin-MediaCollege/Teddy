using UnityEngine;
using System.Collections;

public class CheatLights:MonoBehaviour {
	private string[] cheat = new string[] {"l", "i", "g", "h", "t", "s"};

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
			Light light = GameObject.Find("Main Light").GetComponent<Light>();

			switch(light.intensity) {
			case 0.1f:
				light.intensity = 1;
				break;
			case 1f:
				light.intensity = 0.1f;
				break;
			}

			index = 0;
		}
	}
}
