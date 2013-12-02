using UnityEngine;
using System.Collections;

public class PlayerCombat:MonoBehaviour {
	public AudioClip attackSound;
	public GameObject weapon;

	private GUIText scoreDisplay;
	private GUIText killsDisplay;

	private GameObject currentWeaponGo;
	private bool playSound = true;

	private ScoreManager scoreManager;

	void Start() {
		scoreManager = GameObject.Find("Score Manager").GetComponent<ScoreManager>();

		scoreDisplay = GameObject.Find("Score Display").GetComponent<GUIText>();
		killsDisplay = GameObject.Find("Kills Display").GetComponent<GUIText>();

<<<<<<< HEAD
=======
<<<<<<< HEAD
		scoreDisplay.text = "Score: " + this.score.ToString("0");
		killsDisplay.text = "Kills: " + kills.ToString("0");

		AudioManager manage= GameObject.Find("Sound Manager").GetComponent<AudioManager>();

		playSound=manage.playSFX;
=======
>>>>>>> 2a1363e24fb34a9e1047c17cf27e25d1c98f411e
		scoreDisplay.text = "Score: " + scoreManager.score.ToString("0");
		killsDisplay.text = "Kills: " + scoreManager.kills.ToString("0");
		
>>>>>>> Added second level
	}

	void Update() {
		if(currentWeaponGo != null) {
			currentWeaponGo.transform.position = transform.position;
			currentWeaponGo.transform.rotation = transform.rotation;

			if(Input.GetMouseButtonDown(0)) {
				if(playSound){
				AudioSource.PlayClipAtPoint(attackSound, transform.position);
				}

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
				if(currentWeaponGo!=null){currentWeaponGo.renderer.enabled=true;}
				
				currentWeaponGo = collider.gameObject;
				weapon.GetComponent<SpriteRenderer>().sprite=sprite;
				currentWeaponGo.renderer.enabled=false;
			}
		}
	}

	public void Kill() {
		Application.LoadLevel(Application.loadedLevel);
	}

	public void addScore(int score) {
		scoreManager.score += score;
		scoreManager.kills++;

		scoreDisplay.text = "Score: " + scoreManager.score.ToString("0");
		killsDisplay.text = "Kills: " + scoreManager.kills.ToString("0");
	}
}
