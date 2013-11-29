using UnityEngine;
using System.Collections;

public class EnemyCombat:MonoBehaviour {
	public GameObject weapon;
	
	void OnCollisionStay(Collision col) {
		if (col.collider.gameObject.name == "Player") {
			col.collider.GetComponent<PlayerCombat>().Kill();
		}
	}

	public void Kill() {
		Destroy(gameObject);
	}
}
