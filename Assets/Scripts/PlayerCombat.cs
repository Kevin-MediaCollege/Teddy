using UnityEngine;
using System.Collections;

public class PlayerCombat:MonoBehaviour {
	public WeaponManager.Weapons currentWeapon;

	void Update() {
		if(Input.GetMouseButtonDown(0)) {
			Collider[] hits = Physics.OverlapSphere(transform.position, 1);
			
			foreach (Collider hit in hits)	{
				if (hit.name != "Player") {
					switch(currentWeapon){
					case WeaponManager.Weapons.test1:
						hit.gameObject.GetComponent<EnemyCombat>().Kill();
						break;
					}
				}
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
