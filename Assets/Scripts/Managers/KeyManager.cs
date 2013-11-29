using UnityEngine;
using System.Collections;

public class KeyManager:MonoBehaviour {
	void Update() {
		if(Input.GetKeyDown(KeyCode.Escape)) {
			Application.LoadLevel(1);
		}
	}
}
