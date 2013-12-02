using UnityEngine;
using System.Collections;

public class EnemyCombat:MonoBehaviour {
	public GameObject weapon;

	public bool dead = false;
	
	void OnCollisionStay(Collision col) {
		if (col.collider.gameObject.name == "Player") {
			col.collider.GetComponent<PlayerCombat>().Kill();
		}
	}

	public void Kill() {
		if(dead)
			return;

		dead = true;

		GetComponent<Animator>().Play("EnemyDead");
		GetComponent<SphereCollider>().enabled = false;
		GetComponent<SpriteRenderer>().sortingLayerName = "Enemies Dead";

		GameObject.Find("Player").GetComponent<PlayerCombat>().addScore(100);
	}

	public void StayDead() {
		GetComponent<Animator>().Play("EnemyDeadFinal");
	}
}
