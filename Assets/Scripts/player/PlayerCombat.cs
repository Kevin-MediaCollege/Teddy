using UnityEngine;
using System.Collections;

public class PlayerCombat:MonoBehaviour {
	public AudioClip attackSound;

	private int score;
	private int kills;

	private GUIText scoreDisplay;
	private GUIText killsDisplay;

	private GameObject currentWeaponGo;

	void Start() {
		score = 0;
		kills = 0;

		scoreDisplay = GameObject.Find("Score Display").GetComponent<GUIText>();
		killsDisplay = GameObject.Find("Kills Display").GetComponent<GUIText>();

		scoreDisplay.text = "Score: " + this.score.ToString("0");
		killsDisplay.text = "Kills: " + kills.ToString("0");
	}

	void Update() {
		if(currentWeaponGo != null) {
			currentWeaponGo.transform.position = transform.position;
			currentWeaponGo.transform.rotation = transform.rotation;

			if(Input.GetMouseButtonDown(0)) {
				AudioSource.PlayClipAtPoint(attackSound, transform.position);

				Collider[] hits = Physics.OverlapSphere(transform.position, 1);
				
				foreach (Collider hit in hits)	{
					if (hit.name == "Enemy") {
						hit.gameObject.GetComponent<EnemyCombat>().Kill();
					}
				}
			}
		}
	}

	void OnTriggerStay(Collider collider) {
		if(collider.gameObject.tag == "PickUp") {
			if(Input.GetKeyDown(KeyCode.E)) {
				Sprite sprite = collider.GetComponent<SpriteRenderer>().sprite;

				currentWeaponGo = collider.gameObject;
			}
		}
	}

	public void Kill() {
		Application.LoadLevel(Application.loadedLevel);
	}

	public void addScore(int score) {
		this.score += score;
		kills++;

		scoreDisplay.text = "Score: " + this.score.ToString("0");
		killsDisplay.text = "Kills: " + kills.ToString("0");
	}
}
