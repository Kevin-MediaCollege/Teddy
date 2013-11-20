using UnityEngine;
using System.Collections;
using Pathfinding;

public class EnemySeeking:MonoBehaviour {
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

		seeker.StartPath(transform.position,targetPosition, OnPathComplete);
	}
	
	public void OnPathComplete (Path p) {
		if (!p.error) {
			path = p;
			currentWaypoint = 0;
		}
	}
	
	public void FixedUpdate () {
		targetPosition = player.transform.position;

		rigidbody2D.velocity = Vector2.zero;

		if (path == null) {
			return;
		}
		
		if (currentWaypoint >= path.vectorPath.Count) {
			return;
		}

		Vector3 dir = (path.vectorPath[currentWaypoint]-transform.position).normalized;
		dir *= walkSpeed * Time.deltaTime;

		rigidbody2D.AddForce(new Vector2(dir.x, dir.y));

		if (Vector3.Distance (transform.position,path.vectorPath[currentWaypoint]) < nextWaypointDistance) {
			currentWaypoint++;
			return;
		}
	}
}