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
	
	public void Start () {
		seeker = GetComponent<Seeker>();
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
		Quaternion rotation = Quaternion.identity;
		Vector3 velocity = Vector3.zero;

		transform.LookAt(player.transform.position);

		rotation = transform.rotation;
		rotation.z = rotation.y;
		rotation.y = 0;

		transform.rotation = rotation;

		if (path != null) {
			if (Vector3.Distance (player.transform.position, targetPosition) > 2) {
				targetPosition = player.transform.position;
				seeker.StartPath(transform.position, targetPosition, OnPathComplete);
			} else {
				//TODO charge
			}

			if(currentWaypoint < path.vectorPath.Count) {
				velocity = (path.vectorPath[currentWaypoint] - transform.position).normalized;
				velocity.z = 0;
			}

			if (Vector3.Distance(transform.position, path.vectorPath[currentWaypoint]) < nextWaypointDistance) {
				currentWaypoint++;
			}
		}

		rigidbody.velocity = velocity;

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