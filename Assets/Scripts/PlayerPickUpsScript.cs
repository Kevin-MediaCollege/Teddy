using UnityEngine;
using System.Collections;

public class PlayerPickUpsScript : MonoBehaviour {

	enum Weapons{
		test1,
		test2
	}

	GameObject test1Weapon;
	Weapons currentWeapon;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetAxis("Fire1") != 0)
		{
			switch(currentWeapon){
			case Weapons.test1:
				Debug.Log ("boom boom");
				break;
			}
		}
	}

	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag=="PickUp"){
			switch(other.gameObject.name){
			case "test1PickUp":
				currentWeapon = Weapons.test1;
				break;
			case "test2PickUp":
				currentWeapon = Weapons.test2;
				break;
			}
			Destroy(other.gameObject,0.1f);
		}
		Debug.Log (currentWeapon);
	}
}
