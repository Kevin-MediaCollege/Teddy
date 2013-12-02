using UnityEngine;
using System.Collections;
using Pathfinding;

public class EnemySeeking:MonoBehaviour {
	public float walkSpeed;
	public float runSpeed;
	public Path path;
	
	private float nextWaypointDistance = 1;
	private int currentWaypoint = 0;

	private Vector3 targetPosition;
	private GameObject player;
	private Seeker seeker;
	private bool aggro;

	private EnemyCombat combat;
	
	public void Start () {
		seeker = GetComponent<Seeker>();
		combat = GetComponent<EnemyCombat>();

		player = GameObject.Find("Player");

		targetPosition = player.transform.position;
		seeker.StartPath(transform.position, targetPosition, OnPathComplete);
	}
	
	public void OnPathComplete(Path path) {
		if (!path.error) {
			this.path = path;
			currentWaypoint = 0;
		}
	}
	
	public void FixedUpdate () {
		Vector3 velocity = Vector3.zero;

		rigidbody.velocity = velocity;

		if(!combat.dead) {
			Vector3 playerPos = player.transform.position;

			playerPos.x = playerPos.x - transform.position.x;
			playerPos.y = playerPos.y - transform.position.y;
			
			transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(playerPos.y, playerPos.x) * Mathf.Rad2Deg + 90));

			if (path != null) {
				if (Vector3.Distance (player.transform.position, targetPosition) > 2) {
					targetPosition = player.transform.position;
					seeker.StartPath(transform.position, targetPosition, OnPathComplete);
				} else {
					//TODO Check if the player is in the LoS
				}

				if(currentWaypoint < path.vectorPath.Count) {
					velocity = (path.vectorPath[currentWaypoint] - transform.position).normalized;
					velocity.z = 0;

					if (Vector3.Distance(transform.position, path.vectorPath[currentWaypoint]) < nextWaypointDistance) {
						currentWaypoint++;
					}
				}
			}

			if(velocity == Vector3.zero) {
				GetComponent<Animator>().Play("EnemyIdle");
			} else {
				GetComponent<Animator>().Play("EnemyWalk");

				if(aggro) {
					rigidbody.AddForce(velocity * runSpeed * Time.deltaTime);
				} else {
					rigidbody.AddForce(velocity * walkSpeed * Time.deltaTime);
				}
			}
		}
	}
}