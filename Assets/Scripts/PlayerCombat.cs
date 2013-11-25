using UnityEngine;
using System.Collections;

public class PlayerCombat:MonoBehaviour {
	private WeaponManager.Weapons currentWeapon;

	void Start() {

	}

	void Update() {
		if(Input.GetAxis("Fire") != 0) {
			Collider[] hits = Physics.OverlapSphere(transform.position, 1);
			
			foreach (Collider hit in hits)	{
				Debug.Log("yolo");
				//if (hit.name != "Player") {
					switch(currentWeapon){
					case WeaponManager.Weapons.test1:
						hit.gameObject.GetComponent<EnemyCombat>().Kill();
						Debug.Log ("swag");
						break;
					}
				//}
			}
		}
	}

	void OnTriggerEnter(Collider collider) {
		if(collider.gameObject.tag == "PickUp") {
			switch(collider.gameObject.name){
			case "test1PickUp":
				currentWeapon = WeaponManager.Weapons.test1;
				break;
			case "test2PickUp":
				currentWeapon = WeaponManager.Weapons.test2;
				break;
			}

			Destroy(collider.gameObject,0.1f);
		}

		Debug.Log (currentWeapon);
	}

	public void Kill() {
		Application.LoadLevel(Application.loadedLevel);
	}
}
