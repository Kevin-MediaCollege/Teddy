using UnityEngine;
using System.Collections;

public class EnemyMovement:MonoBehaviour {
	public float walkSpeed;

	public int hitPoints;
	public int damage;

	private bool hasAggro;
	private bool seesPlayer;

	private GameObject player;

	private Vector3 lastKnownPosition;

	private EnemySearch enemySearch;

	void Start () {
		player = GameObject.Find("Player");

		enemySearch = GetComponent<EnemySearch>();
	}

	void Update() {
		RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x + 0.5f, transform.position.y - 1.1f), -Vector2.up);

		if (hit) {
			if(hit.collider.gameObject.name == "Player") {
				hasAggro = true;
				lastKnownPosition = player.transform.position;
			}
		} else {
			seesPlayer = false;

			if (Vector3.Distance(transform.position, lastKnownPosition) < 1) {
				enemySearch.Search = true;

				if(enemySearch.Found) {
					seesPlayer = true;
					hasAggro = true;
				} else {
					hasAggro = false;
				}
			}
		}
	}

	void FixedUpdate () {
		bool move = false;

		if(hasAggro && seesPlayer) {
			transform.LookAt(player.transform.position);
			move = true;
		} else if(hasAggro && !seesPlayer) {
			transform.LookAt(lastKnownPosition);
			move = true;
		}

		if(move) {
			Vector2 speed = Vector2.zero;

			transform.Rotate(0, 90, 0);
			
			speed = -Vector2.up * walkSpeed;
			
			rigidbody2D.velocity = speed * Time.deltaTime;
		} else {
			rigidbody2D.velocity = Vector2.zero;
		}
	}
}
