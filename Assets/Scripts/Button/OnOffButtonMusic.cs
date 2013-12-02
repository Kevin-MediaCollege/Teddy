using UnityEngine;
using System.Collections;

public class OnOffButtonMusic : MonoBehaviour {

	public GameObject listenObject;
	public bool Inverted;

	private Color newColor;
	private Color originalColor;

	private MusicToggle listenScript;
	// Use this for initialization
	void Start () {
		listenScript = listenObject.GetComponent<MusicToggle>();
		newColor = new Color(0.5f, 0.0f, 0.5f);
		originalColor = gameObject.renderer.material.color;
	}

	// Update is called once per frame
	void Update () {
		bool state = listenScript.state;
		if(Inverted){
			if(state){
				renderer.material.color = originalColor;
			}
			else{
				renderer.material.color = newColor;
			}
		}
		else{
			if(state){
				renderer.material.color = newColor;
			}
			else{
				renderer.material.color = originalColor;
			}
		}
	}
}
