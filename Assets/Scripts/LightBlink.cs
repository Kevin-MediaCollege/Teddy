using UnityEngine;
using System.Collections;

public class LightBlink:MonoBehaviour {
	public bool randomStart;

	public int onTime;
	public int offTime;

	private bool enabled;
	
	private int tick;

	private Light light;

	void Start() {
		light = GetComponent<Light>();

		if(randomStart) {
			tick -= Random.Range(-200, 0);
		}
	}

	void Update() {
		tick++;

		if(enabled == true) {
			if((tick % onTime) == 0) {
				enabled = false;
				tick = 0;
			}
		} else if(enabled == false) {
			if((tick % offTime) == 0) {
				enabled = true;
				tick = 0;
			}
		}

		light.enabled = enabled;
	}
}
