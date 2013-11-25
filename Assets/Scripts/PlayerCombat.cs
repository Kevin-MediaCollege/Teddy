using UnityEngine;
using System.Collections;

public class PlayerCombat:MonoBehaviour {
	void Start () {

	}

	void FixedUpdate () {
		if(Input.GetMouseButtonDown(0)) {
			Collider[] hits = Physics.OverlapSphere(transform.position, 1);
			
			foreach (Collider hit in hits)	{
				if (hit.name == "Player") {
					continue;
				}
				
				hit.gameObject.GetComponent<EnemyCombat>().Kill();
			}
		}
	}

	public void Kill() {
		Application.LoadLevel(Application.loadedLevel);
	}
}
