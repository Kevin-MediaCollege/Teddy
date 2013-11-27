using UnityEngine;
using System.Collections;
using Pathfinding;

public class EnemySeeking:MonoBehaviour {
	public bool enabled;

	public float walkSpeed;
	public float runSpeed;

	private bool aggro;

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
		Vector3 dir = Vector3.zero;

		rigidbody.velocity = Vector3.zero;

		if (path == null) {
			Animate(dir);
			return;
		}

		if (Vector3.Distance (player.transform.position, targetPosition) > 2) {
			Repath();
		} else {
			RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x + 0.5f, transform.position.y - 1.1f), -Vector2.up);
			Debug.DrawRay(transform.position, -Vector2.up, Color.green, 100);

			aggro = false;

			if (hit) {
				if(hit.collider.gameObject.name == "Player") {
					aggro = true;
				}
			}
		}

		if(currentWaypoint >= path.vectorPath.Count) {
			Animate(dir);
			return;
		}
		
		dir = (path.vectorPath[currentWaypoint] - transform.position).normalized;
		dir.z = 0;

		transform.LookAt(player.transform.position);
		transform.rotation = new Quaternion(0, 0, transform.rotation.z, transform.rotation.w);

		if(!aggro) {
			rigidbody.AddForce(dir * walkSpeed * Time.deltaTime);

			if (Vector3.Distance(transform.position,path.vectorPath[currentWaypoint]) < nextWaypointDistance) {
				currentWaypoint++;
				Animate(dir);
				return;
			}
		} else {
			rigidbody.AddForce(dir * runSpeed * Time.deltaTime);
		}

		Animate(dir);
	}

	public void Repath() {
		targetPosition = player.transform.position;
		seeker.StartPath(transform.position, targetPosition, OnPathComplete);
	}

	private void Animate(Vector3 dir) {
		if(dir == Vector3.zero) {
			GetComponent<Animator>().Play("EnemyIdle");
		} else {
			GetComponent<Animator>().Play("EnemyWalk");
		}
	}
}