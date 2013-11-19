using UnityEngine;
using System.Collections;

public class EnemySearch:MonoBehaviour {
	public int searchTime;

	private bool isSearching;
	private bool foundPlayer;
	
	void FixedUpdate() {
		if(isSearching) {
			transform.Rotate(0, 0, 1);

			RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x + 0.5f, transform.position.y - 1.0f), -Vector2.up);

			if (hit) {
				if(hit.collider.gameObject.name == "Player") {
					foundPlayer = true;
					isSearching = false;
				}
			} else {
				foundPlayer = false;
			}
		}
	}

	public bool Search {
		get { return isSearching; }
		set { isSearching = value; }
	}

	public bool Found {
		get { return foundPlayer; }
	}
}
