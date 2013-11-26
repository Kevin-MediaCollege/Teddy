using UnityEngine;
using System.Collections;

public class Cheats:MonoBehaviour {
	private string[] lights = new string[] {"l", "i", "g", "h", "t", "s"};

	private int index = 0;

	void Update() {
		if(Input.anyKeyDown) {
			if(Input.GetKeyDown(lights[index])) {
				index++;
			} else {
				index = 0;
			}
		}	

		if(index == lights.Length) {
			Light light = GameObject.Find("Main Light").GetComponent<Light>();

			light.enabled = !light.enabled;
			index = 0;
		}
	}
}
