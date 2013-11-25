using UnityEngine;
using System.Collections;
using Pathfinding;

public class EnemySeeking:MonoBehaviour {
	public bool enabled;

	public float walkSpeed;
	public float runSpeed;

	private Vector3 targetPosition;
	
	private Seeker seeker;
	private GameObject player;

	public Path path;

	private float nextWaypointDistance = 1;
	private int currentWaypoint = 0;
	
	public void Start () {
		seeker = GetComponent<Seeker>();
		player = GameObject.Find("Player");

		Repath();
	}
	
	public void OnPathComplete(Path p) {
		if (!p.error) {
			path = p;
			currentWaypoint = 0;
		}
	}
	
	public void FixedUpdate () {
		rigidbody.velocity = Vector3.zero;

		if(enabled) {
			if (path == null) {
				return;
			}

			if(currentWaypoint >= path.vectorPath.Count) {
				return;
			}

			if (Vector3.Distance (player.transform.position, targetPosition) > 5) {
				Repath();
				return;
			}

			Vector3 dir = (path.vectorPath[currentWaypoint]-transform.position).normalized;
			dir.z = 0;

			rigidbody.AddForce(dir * walkSpeed * Time.deltaTime);

			if (Vector3.Distance(transform.position,path.vectorPath[currentWaypoint]) < nextWaypointDistance) {
				currentWaypoint++;
				return;
			}
		}
	}

	public void Repath() {
		targetPosition = player.transform.position;
		seeker.StartPath(transform.position, targetPosition, OnPathComplete);
	}
}